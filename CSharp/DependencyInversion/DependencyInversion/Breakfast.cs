using System;
using System.Collections.Generic;
using System.Text;

namespace DependencyInversion
{
    public class Breakfast
    {
        public Coffee Coffee { get; set; }

        public Bread Bread { get; set; }
    }
}
