namespace Rusty.ObservationLog.WinForms
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
