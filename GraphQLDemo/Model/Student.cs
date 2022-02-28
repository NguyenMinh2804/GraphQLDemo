using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Model
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
