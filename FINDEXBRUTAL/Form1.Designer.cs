namespace FINDEXBRUTAL
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {

            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label13 = new System.Windows.Forms.Label();
            this.password = new Guna.UI2.WinForms.Guna2TextBox();
            this.username = new Guna.UI2.WinForms.Guna2TextBox();
            this.LOGINBTN = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.EXITBTN = new Guna.UI2.WinForms.Guna2ControlBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.guna2CheckBox1 = new Guna.UI2.WinForms.Guna2CheckBox();
            this.MONITOR = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(185, 365);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(154, 15);
            this.label13.TabIndex = 293;
            this.label13.Text = "DEVELOPED BY FINDEX";
            // 
            // password
            // 
            this.password.BorderColor = System.Drawing.Color.Azure;
            this.password.BorderRadius = 8;
            this.password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.password.DefaultText = "";
            this.password.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.password.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.password.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.password.FillColor = System.Drawing.Color.Transparent;
            this.password.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.password.IconLeft = ((System.Drawing.Image)(resources.GetObject("password.IconLeft")));
            this.password.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.password.Location = new System.Drawing.Point(50, 233);
            this.password.Name = "password";
            this.password.PasswordChar = '\0';
            this.password.PlaceholderText = "Password";
            this.password.SelectedText = "";
            this.password.Size = new System.Drawing.Size(241, 38);
            this.password.TabIndex = 296;
            this.password.TextOffset = new System.Drawing.Point(2, 0);
            this.password.TextChanged += new System.EventHandler(this.password_TextChanged);
            // 
            // username
            // 
            this.username.BorderColor = System.Drawing.Color.White;
            this.username.BorderRadius = 8;
            this.username.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.username.DefaultText = "";
            this.username.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.username.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.username.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.username.FillColor = System.Drawing.Color.Transparent;
            this.username.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.username.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.username.IconLeft = ((System.Drawing.Image)(resources.GetObject("username.IconLeft")));
            this.username.IconLeftOffset = new System.Drawing.Point(5, 0);
            this.username.Location = new System.Drawing.Point(50, 187);
            this.username.Name = "username";
            this.username.PasswordChar = '\0';
            this.username.PlaceholderText = "Username";
            this.username.SelectedText = "";
            this.username.Size = new System.Drawing.Size(241, 40);
            this.username.TabIndex = 295;
            this.username.TextOffset = new System.Drawing.Point(2, 0);
            this.username.TextChanged += new System.EventHandler(this.username_TextChanged);
            // 
            // LOGINBTN
            // 
            this.LOGINBTN.Animated = true;
            this.LOGINBTN.BackColor = System.Drawing.Color.Transparent;
            this.LOGINBTN.BorderColor = System.Drawing.Color.White;
            this.LOGINBTN.BorderRadius = 10;
            this.LOGINBTN.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LOGINBTN.CustomBorderColor = System.Drawing.Color.Transparent;
            this.LOGINBTN.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.LOGINBTN.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.LOGINBTN.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.LOGINBTN.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.LOGINBTN.FillColor = System.Drawing.Color.Red;
            this.LOGINBTN.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LOGINBTN.ForeColor = System.Drawing.Color.White;
            this.LOGINBTN.IndicateFocus = true;
            this.LOGINBTN.Location = new System.Drawing.Point(111, 288);
            this.LOGINBTN.Name = "LOGINBTN";
            this.LOGINBTN.PressedColor = System.Drawing.Color.White;
            this.LOGINBTN.ShadowDecoration.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.LOGINBTN.Size = new System.Drawing.Size(110, 32);
            this.LOGINBTN.TabIndex = 294;
            this.LOGINBTN.Text = "LOGIN";
            this.LOGINBTN.UseTransparentBackground = true;
            this.LOGINBTN.Click += new System.EventHandler(this.LOGINBTN_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(2, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 28);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 297;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.BorderColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ControlBoxType = Guna.UI2.WinForms.Enums.ControlBoxType.MinimizeBox;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.guna2ControlBox1.FillColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.ForeColor = System.Drawing.Color.Transparent;
            this.guna2ControlBox1.IconColor = System.Drawing.Color.Silver;
            this.guna2ControlBox1.Location = new System.Drawing.Point(262, 1);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(43, 29);
            this.guna2ControlBox1.TabIndex = 299;
            this.guna2ControlBox1.Click += new System.EventHandler(this.guna2ControlBox1_Click);
            // 
            // EXITBTN
            // 
            this.EXITBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EXITBTN.BackColor = System.Drawing.Color.Transparent;
            this.EXITBTN.BorderColor = System.Drawing.Color.Transparent;
            this.EXITBTN.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EXITBTN.FillColor = System.Drawing.Color.Transparent;
            this.EXITBTN.ForeColor = System.Drawing.Color.Transparent;
            this.EXITBTN.IconColor = System.Drawing.Color.Red;
            this.EXITBTN.Location = new System.Drawing.Point(293, 2);
            this.EXITBTN.Name = "EXITBTN";
            this.EXITBTN.Size = new System.Drawing.Size(46, 28);
            this.EXITBTN.TabIndex = 298;
            this.EXITBTN.Click += new System.EventHandler(this.EXITBTN_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-18, -57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(377, 367);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 300;
            this.pictureBox1.TabStop = false;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 15;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // guna2CheckBox1
            // 
            this.guna2CheckBox1.AutoSize = true;
            this.guna2CheckBox1.CheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2CheckBox1.CheckedState.BorderRadius = 0;
            this.guna2CheckBox1.CheckedState.BorderThickness = 0;
            this.guna2CheckBox1.CheckedState.FillColor = System.Drawing.Color.Black;
            this.guna2CheckBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.guna2CheckBox1.ForeColor = System.Drawing.Color.Red;
            this.guna2CheckBox1.Location = new System.Drawing.Point(40, 331);
            this.guna2CheckBox1.Name = "guna2CheckBox1";
            this.guna2CheckBox1.Size = new System.Drawing.Size(95, 17);
            this.guna2CheckBox1.TabIndex = 301;
            this.guna2CheckBox1.Text = "Remember Me";
            this.guna2CheckBox1.UncheckedState.BorderColor = System.Drawing.Color.Transparent;
            this.guna2CheckBox1.UncheckedState.BorderRadius = 0;
            this.guna2CheckBox1.UncheckedState.BorderThickness = 0;
            this.guna2CheckBox1.UncheckedState.FillColor = System.Drawing.Color.White;
            this.guna2CheckBox1.CheckedChanged += new System.EventHandler(this.guna2CheckBox1_CheckedChanged);
            // 
            // MONITOR
            // 
            this.MONITOR.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(341, 386);
            this.Controls.Add(this.guna2CheckBox1);
            this.Controls.Add(this.guna2ControlBox1);
            this.Controls.Add(this.EXITBTN);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.LOGINBTN);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label13;
        private Guna.UI2.WinForms.Guna2TextBox password;
        private Guna.UI2.WinForms.Guna2TextBox username;
        private Guna.UI2.WinForms.Guna2Button LOGINBTN;
        private System.Windows.Forms.PictureBox pictureBox3;
        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2ControlBox EXITBTN;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private Guna.UI2.WinForms.Guna2CheckBox guna2CheckBox1;
        private System.Windows.Forms.Timer MONITOR;
        private System.Windows.Forms.Timer timer1;
    }
}

