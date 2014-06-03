using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rusty.ObservationLog.Windows
{
    static class Program
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static bool _lastKeyWasLetter = false;
        private static Queue<Keys> _keyBuffer = new Queue<Keys>();
        private static Form1 _mainForm;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _hookID = SetHook(_proc);
            _mainForm = new Form1();
            Application.Run(_mainForm);

            UnhookWindowsHookEx(_hookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        //private static void ToggleCapsLock()
        //{
        //    const int KEYEVENTF_EXTENDEDKEY = 0x1;
        //    const int KEYEVENTF_KEYUP = 0x2;

        //    UnhookWindowsHookEx(_hookID);
        //    keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr)0);
        //    keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, (UIntPtr)0);
        //    _hookID = SetHook(_proc);
        //}

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                Keys key = (Keys)Marshal.ReadInt32(lParam);
                if (key == Keys.Space) { }

                //var sc = Shortcut.CtrlShiftF1;
                var txt = new KeysConverter().ConvertToString((Keys)key);
                Console.WriteLine(txt);

                _keyBuffer.Enqueue(key);
                if (_keyBuffer.Count > 3)
                    _keyBuffer.Dequeue();
                var keyCombo = _keyBuffer.ToArray();
                if (keyCombo[0] == Keys.ControlKey && keyCombo[1] == Keys.Shift && keyCombo[2] == Keys.O)
                {
                    if (_mainForm.WindowState == FormWindowState.Minimized)
                    {
                        _mainForm.WindowState = FormWindowState.Normal;
                    }

                    _mainForm.Activate();

                }


            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
    }
}
