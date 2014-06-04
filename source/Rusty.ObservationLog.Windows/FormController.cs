using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rusty.ObservationLog.Windows
{
    public static class FormController
    {
        static FormController()
        {
            ObservationForm = new Observation();
        }
        public static Observation ObservationForm { get; private set; }
    }
}
