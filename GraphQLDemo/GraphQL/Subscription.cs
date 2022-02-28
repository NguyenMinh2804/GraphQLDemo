using GraphQLDemo.Model;
using HotChocolate;
using HotChocolate.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Class OnListAdded([EventMessage] Class Class) => Class;
    }
}
