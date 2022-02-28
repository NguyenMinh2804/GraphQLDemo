using GraphQLDemo.Model;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;

namespace GraphQLDemo.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(DatabaseContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Class> GetClasses ([ScopedService] DatabaseContext databaseContext)
        {
            return databaseContext.Classes;
        }
        [UseDbContext(typeof(DatabaseContext))]
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Student> GetStudents([ScopedService] DatabaseContext databaseContext)
        {
            return databaseContext.Students;
        }
    }
}
