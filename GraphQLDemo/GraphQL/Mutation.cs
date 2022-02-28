using GraphQLDemo.InputData;
using GraphQLDemo.Model;
using GraphQLDemo.OutPut;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GraphQLDemo.GraphQL
{
    public class Mutation
    {
        [UseDbContext(typeof(DatabaseContext))]
        public async Task<AddClassPayload> AddClass ([ScopedService] DatabaseContext databaseContext, AddClassInput classInput, [Service] ITopicEventSender eventSender, CancellationToken cancellationToken)
        {
            Class @class = new Class();
            @class.Name = classInput.Name;
            databaseContext.Classes.Add(@class);
            await databaseContext.SaveChangesAsync();
            await eventSender.SendAsync(nameof(Subscription.OnClassAdded), @class, cancellationToken);
            return new AddClassPayload(@class);
        }

        [UseDbContext(typeof(DatabaseContext))]
        public async Task<AddClassPayload> EditClass([ScopedService] DatabaseContext databaseContext, Class classInput)
        {
            databaseContext.Entry(classInput).State = EntityState.Modified;
            await databaseContext.SaveChangesAsync();
            return new AddClassPayload(classInput);
        }

        [UseDbContext(typeof(DatabaseContext))]
        public async Task<bool> DeleteClass([ScopedService] DatabaseContext databaseContext, int id)
        {
            var @class = await databaseContext.Classes.FindAsync(id);
            databaseContext.Classes.Remove(@class);
            await databaseContext.SaveChangesAsync();
            return true;
        }

        [UseDbContext(typeof(DatabaseContext))]
        public async Task<AddStudentPayload> AddStudent([ScopedService] DatabaseContext databaseContext, AddStudentInput studentInput)
        {
            Student student = new Student();
            student.Name = studentInput.Name;
            student.ClassId = studentInput.ClassId;
            databaseContext.Students.Add(student);
            await databaseContext.SaveChangesAsync();
            return new AddStudentPayload(student);
        }

        [UseDbContext(typeof(DatabaseContext))]
        public async Task<AddStudentPayload> EditStudent([ScopedService] DatabaseContext databaseContext, Student studentInput)
        {
            databaseContext.Entry(studentInput).State = EntityState.Modified;
            await databaseContext.SaveChangesAsync();
            return new AddStudentPayload(studentInput);
        }

        [UseDbContext(typeof(DatabaseContext))]
        public async Task<bool> DeleteStudent([ScopedService] DatabaseContext databaseContext, int id)
        {
            var student = await databaseContext.Students.FindAsync(id);
            databaseContext.Students.Remove(student);
            await databaseContext.SaveChangesAsync();
            return true;
        }
    }
}
