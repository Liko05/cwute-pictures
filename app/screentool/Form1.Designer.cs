namespace screentool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.titleLabel = new System.Windows.Forms.Label();
            this.siteLinkLabel = new System.Windows.Forms.LinkLabel();
            this.usernameBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.localSavesCheckBox = new System.Windows.Forms.CheckBox();
            this.localPathBox = new System.Windows.Forms.TextBox();
            this.localPathBtn = new System.Windows.Forms.Button();
            this.selectLanguageLabel = new System.Windows.Forms.Label();
            this.languageEnglishRadio = new System.Windows.Forms.RadioButton();
            this.languageEnglish_uwufiedRadio = new System.Windows.Forms.RadioButton();
            this.saveSettingsBtn = new System.Windows.Forms.Button();
            this.changesNotSavedLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openAfterUpload = new System.Windows.Forms.CheckBox();
            this.siteOpenLabel = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(30, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(755, 24);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "welcome to cwute app here you can change settings regarding your client and uploa" +
    "ding";
            // 
            // siteLinkLabel
            // 
            this.siteLinkLabel.AutoSize = true;
            this.siteLinkLabel.Location = new System.Drawing.Point(636, 428);
            this.siteLinkLabel.Name = "siteLinkLabel";
            this.siteLinkLabel.Size = new System.Drawing.Size(158, 13);
            this.siteLinkLabel.TabIndex = 1;
            this.siteLinkLabel.TabStop = true;
            this.siteLinkLabel.Text = "For more info visit our cwute site";
            this.siteLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.siteLinkLabel_LinkClicked);
            // 
            // usernameBox
            // 
            this.usernameBox.Location = new System.Drawing.Point(9, 32);
            this.usernameBox.Name = "usernameBox";
            this.usernameBox.Size = new System.Drawing.Size(130, 20);
            this.usernameBox.TabIndex = 2;
            this.usernameBox.TextChanged += new System.EventHandler(this.usernameBox_TextChanged);
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Location = new System.Drawing.Point(6, 16);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(133, 13);
            this.usernameLabel.TabIndex = 3;
            this.usernameLabel.Text = "Enter ur desired username:";
            // 
            // localSavesCheckBox
            // 
            this.localSavesCheckBox.AutoSize = true;
            this.localSavesCheckBox.Location = new System.Drawing.Point(6, 12);
            this.localSavesCheckBox.Name = "localSavesCheckBox";
            this.localSavesCheckBox.Size = new System.Drawing.Size(259, 17);
            this.localSavesCheckBox.TabIndex = 4;
            this.localSavesCheckBox.Text = "Do you want to enable storing images locally too?";
            this.localSavesCheckBox.UseVisualStyleBackColor = true;
            this.localSavesCheckBox.CheckedChanged += new System.EventHandler(this.localSavesCheckBox_CheckedChanged);
            // 
            // localPathBox
            // 
            this.localPathBox.Enabled = false;
            this.localPathBox.HideSelection = false;
            this.localPathBox.Location = new System.Drawing.Point(6, 29);
            this.localPathBox.Name = "localPathBox";
            this.localPathBox.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.localPathBox.ShortcutsEnabled = false;
            this.localPathBox.Size = new System.Drawing.Size(190, 20);
            this.localPathBox.TabIndex = 5;
            this.localPathBox.TabStop = false;
            this.localPathBox.Visible = false;
            this.localPathBox.WordWrap = false;
            // 
            // localPathBtn
            // 
            this.localPathBtn.Location = new System.Drawing.Point(202, 29);
            this.localPathBtn.Name = "localPathBtn";
            this.localPathBtn.Size = new System.Drawing.Size(63, 20);
            this.localPathBtn.TabIndex = 6;
            this.localPathBtn.Text = "Browse...";
            this.localPathBtn.UseVisualStyleBackColor = true;
            this.localPathBtn.Visible = false;
            this.localPathBtn.Click += new System.EventHandler(this.localPathBtn_Click);
            // 
            // selectLanguageLabel
            // 
            this.selectLanguageLabel.AutoSize = true;
            this.selectLanguageLabel.Location = new System.Drawing.Point(6, 13);
            this.selectLanguageLabel.Name = "selectLanguageLabel";
            this.selectLanguageLabel.Size = new System.Drawing.Size(147, 13);
            this.selectLanguageLabel.TabIndex = 10;
            this.selectLanguageLabel.Text = "Select your desired language:";
            // 
            // languageEnglishRadio
            // 
            this.languageEnglishRadio.AutoSize = true;
            this.languageEnglishRadio.Checked = true;
            this.languageEnglishRadio.Location = new System.Drawing.Point(9, 32);
            this.languageEnglishRadio.Name = "languageEnglishRadio";
            this.languageEnglishRadio.Size = new System.Drawing.Size(59, 17);
            this.languageEnglishRadio.TabIndex = 11;
            this.languageEnglishRadio.TabStop = true;
            this.languageEnglishRadio.Text = "English";
            this.languageEnglishRadio.UseVisualStyleBackColor = true;
            this.languageEnglishRadio.CheckedChanged += new System.EventHandler(this.changeLanguageCallBack);
            // 
            // languageEnglish_uwufiedRadio
            // 
            this.languageEnglish_uwufiedRadio.AutoSize = true;
            this.languageEnglish_uwufiedRadio.Location = new System.Drawing.Point(9, 55);
            this.languageEnglish_uwufiedRadio.Name = "languageEnglish_uwufiedRadio";
            this.languageEnglish_uwufiedRadio.Size = new System.Drawing.Size(90, 17);
            this.languageEnglish_uwufiedRadio.TabIndex = 12;
            this.languageEnglish_uwufiedRadio.Text = "Better English";
            this.languageEnglish_uwufiedRadio.UseVisualStyleBackColor = true;
            this.languageEnglish_uwufiedRadio.CheckedChanged += new System.EventHandler(this.changeLanguageCallBack);
            // 
            // saveSettingsBtn
            // 
            this.saveSettingsBtn.Location = new System.Drawing.Point(261, 398);
            this.saveSettingsBtn.Name = "saveSettingsBtn";
            this.saveSettingsBtn.Size = new System.Drawing.Size(300, 43);
            this.saveSettingsBtn.TabIndex = 13;
            this.saveSettingsBtn.Text = "Save changes";
            this.saveSettingsBtn.UseVisualStyleBackColor = true;
            this.saveSettingsBtn.Click += new System.EventHandler(this.saveSettingsBtn_Click);
            // 
            // changesNotSavedLabel
            // 
            this.changesNotSavedLabel.AutoSize = true;
            this.changesNotSavedLabel.Location = new System.Drawing.Point(363, 382);
            this.changesNotSavedLabel.Name = "changesNotSavedLabel";
            this.changesNotSavedLabel.Size = new System.Drawing.Size(99, 13);
            this.changesNotSavedLabel.TabIndex = 14;
            this.changesNotSavedLabel.Text = "Changes not saved";
            this.changesNotSavedLabel.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectLanguageLabel);
            this.groupBox2.Controls.Add(this.languageEnglishRadio);
            this.groupBox2.Controls.Add(this.languageEnglish_uwufiedRadio);
            this.groupBox2.Location = new System.Drawing.Point(240, 49);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.localPathBtn);
            this.groupBox3.Controls.Add(this.localPathBox);
            this.groupBox3.Controls.Add(this.localSavesCheckBox);
            this.groupBox3.Location = new System.Drawing.Point(446, 49);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(348, 100);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.usernameLabel);
            this.groupBox4.Controls.Add(this.usernameBox);
            this.groupBox4.Location = new System.Drawing.Point(34, 49);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 100);
            this.groupBox4.TabIndex = 22;
            this.groupBox4.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.siteOpenLabel);
            this.groupBox1.Controls.Add(this.openAfterUpload);
            this.groupBox1.Location = new System.Drawing.Point(34, 155);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 100);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // openAfterUpload
            // 
            this.openAfterUpload.AutoSize = true;
            this.openAfterUpload.Location = new System.Drawing.Point(9, 50);
            this.openAfterUpload.Name = "openAfterUpload";
            this.openAfterUpload.Size = new System.Drawing.Size(59, 17);
            this.openAfterUpload.TabIndex = 0;
            this.openAfterUpload.Text = "Enable";
            this.openAfterUpload.UseVisualStyleBackColor = true;
            this.openAfterUpload.CheckedChanged += new System.EventHandler(this.openAfterUpload_CheckedChanged);
            // 
            // siteOpenLabel
            // 
            this.siteOpenLabel.AutoSize = true;
            this.siteOpenLabel.Location = new System.Drawing.Point(6, 16);
            this.siteOpenLabel.Name = "siteOpenLabel";
            this.siteOpenLabel.Size = new System.Drawing.Size(268, 13);
            this.siteOpenLabel.TabIndex = 1;
            this.siteOpenLabel.Text = "Do you want to automatically open site after uploading?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(806, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.changesNotSavedLabel);
            this.Controls.Add(this.saveSettingsBtn);
            this.Controls.Add(this.siteLinkLabel);
            this.Controls.Add(this.titleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "cwute";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.LinkLabel siteLinkLabel;
        private System.Windows.Forms.TextBox usernameBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.CheckBox localSavesCheckBox;
        private System.Windows.Forms.TextBox localPathBox;
        private System.Windows.Forms.Button localPathBtn;
        private System.Windows.Forms.Label selectLanguageLabel;
        private System.Windows.Forms.RadioButton languageEnglishRadio;
        private System.Windows.Forms.RadioButton languageEnglish_uwufiedRadio;
        private System.Windows.Forms.Button saveSettingsBtn;
        private System.Windows.Forms.Label changesNotSavedLabel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label siteOpenLabel;
        private System.Windows.Forms.CheckBox openAfterUpload;
    }
}

