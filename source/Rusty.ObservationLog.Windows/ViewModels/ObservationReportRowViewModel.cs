using System;

namespace Rusty.ObservationLog.Windows.ViewModels
{
    public class ObservationReportRowViewModel
    {
        public string UserName { get; set; } 
        public DateTime ObservationDate { get; set; }
        public string ObservationText { get; set; }
    }
}