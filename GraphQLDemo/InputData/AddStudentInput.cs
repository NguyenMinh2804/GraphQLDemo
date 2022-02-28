using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.InputData
{
    public record AddStudentInput(string Name, int ClassId);
}
