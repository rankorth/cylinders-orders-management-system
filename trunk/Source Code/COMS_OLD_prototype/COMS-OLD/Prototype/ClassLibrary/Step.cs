using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibrary
{
    public class Step
    {
        private String name_;

        public String Name
        {
            get { return name_; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Step(String name)
        {
            name_ = name;
        }
    }
}
