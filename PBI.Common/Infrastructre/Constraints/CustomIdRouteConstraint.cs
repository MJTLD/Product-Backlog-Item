using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Text;

namespace PBI.Common.Infrastructre.Constraints
{
    public class CustomIdRouteConstraint : RegexRouteConstraint
    {
        public CustomIdRouteConstraint() : base(@"([A-Za-z]{3})([0-9]{3})$")
        {
        }
    }
}
