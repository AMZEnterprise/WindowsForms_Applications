using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        public void ToggleTaskManager()
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
        @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (objRegistryKey.GetValue("DisableTaskMgr") == null)
                objRegistryKey.SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord);
            else
                objRegistryKey.DeleteValue("DisableTaskMgr");
            objRegistryKey.Close();
        }

        public void DisableTaskManager()
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
       @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (objRegistryKey.GetValue("DisableTaskMgr") == null)
                objRegistryKey.SetValue("DisableTaskMgr", "1", RegistryValueKind.DWord);
        }

        public void EnableTaskManager()
        {
            RegistryKey objRegistryKey = Registry.CurrentUser.CreateSubKey(
        @"Software\Microsoft\Windows\CurrentVersion\Policies\System");
            if (objRegistryKey.GetValue("DisableTaskMgr") != null)
                objRegistryKey.DeleteValue("DisableTaskMgr");
        }

        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);
        [DllImport("user32.dll")]
        private static extern int ShowWindow(int hwnd, int command);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;



        // Structure contain information about low-level keyboard input event 
        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public Keys key;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr extra;
        }
        //System level functions
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int id, LowLevelKeyboardProc callback, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hook, int nCode, IntPtr wp, IntPtr lp);
        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string name);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern short GetAsyncKeyState(Keys key);
        //Declaring Global objects     
        private IntPtr ptrHook;
        private LowLevelKeyboardProc objKeyboardProcess;

        private IntPtr captureKey(int nCode, IntPtr wp, IntPtr lp)
        {
            if (nCode >= 0)
            {
                KBDLLHOOKSTRUCT objKeyInfo = (KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lp, typeof(KBDLLHOOKSTRUCT));

                // Disabling Windows keys 

                if (objKeyInfo.key == Keys.RWin || objKeyInfo.key == Keys.LWin || objKeyInfo.key == Keys.Tab && HasAltModifier(objKeyInfo.flags) || objKeyInfo.key == Keys.Escape && (ModifierKeys & Keys.Control) == Keys.Control || objKeyInfo.key == Keys.ControlKey || objKeyInfo.key == Keys.Delete || objKeyInfo.key == (Keys.Alt & Keys.ControlKey & Keys.Delete))
                {
                    return (IntPtr)1; // if 0 is returned then All the above keys will be enabled
                }
            }
            return CallNextHookEx(ptrHook, nCode, wp, lp);
        }

        bool HasAltModifier(int flags)
        {
            return (flags & 0x20) == 0x20;
        }

        /* Code to Disable WinKey, Alt+Tab, Ctrl+Esc Ends Here */
        int hwnd = FindWindow("Shell_TrayWnd", "");
        private void Form1_Load(object sender, EventArgs e)
        {
            ShowWindow(hwnd, SW_HIDE);

            this.SetVisibleCore(false);
            this.FormBorderStyle = FormBorderStyle.None;
            //this.WindowState = FormWindowState.Maximized;
            this.SetVisibleCore(true);


            ProcessModule objCurrentModule = Process.GetCurrentProcess().MainModule;
            objKeyboardProcess = new LowLevelKeyboardProc(captureKey);
            ptrHook = SetWindowsHookEx(13, objKeyboardProcess, GetModuleHandle(objCurrentModule.ModuleName), 0);


            IconDisabler.ToggleDesktopIcons();

            DisableTaskManager();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(@"data.amz", FileMode.Open, FileAccess.Read, FileShare.None);
            StreamReader sr = new StreamReader(fs);
            bool isLoggedIn = false;

            string line = sr.ReadLine();
            while (line!=null)
            {
                if (txtPassword.Text == line)
                {
                    isLoggedIn = true;
                    sr.Close();

                    ShowWindow(hwnd, SW_SHOW);
                    EnableTaskManager();
                    IconDisabler.ToggleDesktopIcons();
                    break;
                }
                line = sr.ReadLine();
            }
            sr.Close();

            if (isLoggedIn == false)
            {
                MessageBox.Show("Password is incorrect!");
            }
            else
            {
                Application.Exit();
            }

        }



    }

    public struct IconDisabler
    {

        [DllImport("user32.dll", SetLastError = true)] static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)] static extern IntPtr GetWindow(IntPtr hWnd, GetWindow_Cmd uCmd);
        enum GetWindow_Cmd : uint
        {
            GW_HWNDFIRST = 0,
            GW_HWNDLAST = 1,
            GW_HWNDNEXT = 2,
            GW_HWNDPREV = 3,
            GW_OWNER = 4,
            GW_CHILD = 5,
            GW_ENABLEDPOPUP = 6
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)] static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        private const int WM_COMMAND = 0x111;

        public static void ToggleDesktopIcons()
        {
            var toggleDesktopCommand = new IntPtr(0x7402);
            IntPtr hWnd = GetWindow(FindWindow("Progman", "Program Manager"), GetWindow_Cmd.GW_CHILD);
            SendMessage(hWnd, WM_COMMAND, toggleDesktopCommand, IntPtr.Zero);
        }

    }


}
