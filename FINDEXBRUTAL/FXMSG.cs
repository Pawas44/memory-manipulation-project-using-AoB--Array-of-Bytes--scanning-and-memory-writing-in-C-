using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KeyAuth.api;

namespace Falcon_X_Cheat
{
    public partial class FXMSG : Form
    {
        public FXMSG()
        {
            InitializeComponent();
        }
        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Applying,
            Applied,
            Error,
            Info
        }
        private FXMSG.enmAction action;

        private int x, y;

        private void timer1_Tick(object sender, EventArgs e)
        {
            {
                switch (this.action)
                {
                    case enmAction.wait:
                        timer1.Interval = 1000;
                        action = enmAction.close;
                        break;
                    case FXMSG.enmAction.start:
                        this.timer1.Interval = 1;
                        this.Opacity += 0.1;
                        if (this.x < this.Location.X)
                        {
                            this.Left--;
                        }
                        else
                        {
                            if (this.Opacity == 1.0)
                            {
                                action = FXMSG.enmAction.wait;
                            }
                        }
                        break;
                    case enmAction.close:
                        timer1.Interval = 1;
                        this.Opacity -= 0.1;

                        this.Left -= 3;
                        if (base.Opacity == 0.0)
                        {
                            base.Close();
                        }
                        break;
                }
            }
        }

        private void FXMSG_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void showAlert(string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                FXMSG frm = (FXMSG)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }
            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Applying:
                    FXLBL.ForeColor = Color.WhiteSmoke;
                    this.FXLBL.Text = msg;
                    break;
                case enmType.Applied:
                    FXLBL.ForeColor = Color.DarkGreen;
                    this.FXLBL.Text = msg;
                    break;
                case enmType.Error:
                    FXLBL.ForeColor = Color.Red;
                    this.FXLBL.Text = msg;
                    break;
            }

            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}