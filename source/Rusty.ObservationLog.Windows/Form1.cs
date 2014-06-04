using System;
using System.Windows.Forms;

namespace Rusty.ObservationLog.Windows
{
    public partial class Form1 : Form
    {
        private KeyboardHook hook = new KeyboardHook();

        public Form1()
        {
            InitializeComponent();

            Register();
        }

        private void Register()
        {
// register the event that is fired after the key press.
            hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            hook.RegisterHotKey(
                Rusty.ObservationLog.Windows.ModifierKeys.Control | Rusty.ObservationLog.Windows.ModifierKeys.Shift,
                Keys.F12);
        }

        private void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // show the keys pressed in a label.
            if (WindowState == FormWindowState.Minimized)
            {
                WindowState = FormWindowState.Normal;
            }

            Activate();

            label1.Text = e.Modifier.ToString() + "" + "" + e.Key.ToString();
        }
    }
}