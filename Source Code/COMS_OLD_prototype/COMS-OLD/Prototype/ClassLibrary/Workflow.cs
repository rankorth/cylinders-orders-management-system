using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ClassLibrary
{
    public class Workflow
    {
        private ArrayList listOfSteps_;
        private String name_;

        public String Name
        {
            get { return name_; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Workflow()
        {
            listOfSteps_ = new ArrayList();
        }

        /// <summary>
        /// Adds a step to the workflow
        /// </summary>
        /// <param name="step"></param>
        /// <returns>Index at which step is added, int</returns>
        public int addStep(Step step)
        {
            return listOfSteps_.Add(step);
        }

        /// <summary>
        /// Saves the workflow to database
        /// </summary>
        /// <returns>Returns the ID of workflow, int</returns>
        public int saveWorkflow()
        {
            return 0;
        }
    }
}
