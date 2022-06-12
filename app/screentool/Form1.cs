using System;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace screentool
{
    public partial class Form1 : Form
    {
        private Settings settings;
        private Files files;
        private Language language;
        private Thread thListen;
        public Form1()
        {
            InitializeComponent();
            this.settings = new Settings("", Language.English, false, "",false);
            this.files = new Files(settings);

            updateLabels();

            Screenshot ss = new Screenshot(this.settings, this.files);

            Thread thListen = new Thread(ss.run);
            thListen.SetApartmentState(ApartmentState.STA);
            thListen.Start();

            this.thListen = thListen;
        }

        /// <summary>
        /// It saves the settings.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">This is a class that contains the event data.</param>
        private void saveSettingsBtn_Click(object sender, EventArgs e)
        {
            if (
                String.IsNullOrWhiteSpace(this.usernameBox.Text) ||
                this.usernameBox.Text.Length == 0 ||
                this.usernameBox.Text == ""

            )
            {
                MessageBox.Show("Invalid name please choose a new one and try again.", "Invalid username");
                return;
            }

            if (this.usernameBox.Text.Length > 20)
            {
                MessageBox.Show("Username too long limit is 20 characters", "Invalid username");
                return;
            }

            if (
                (
                String.IsNullOrWhiteSpace(this.localPathBox.Text) ||
                this.localPathBox.Text.Length == 0) &&
                this.localSavesCheckBox.Checked == true
            )
            {
                MessageBox
                    .Show("Invalid local path either turn local saves off or enter valid path",
                    "Invalid path");
                return;
            }

            Language tmp = Language.English;

            if (!this.languageEnglishRadio.Checked)
            {
                tmp = Language.English_better;
            }
            this.changesNotSavedLabel.Visible = false;
            this.settings.updateSettings(this.usernameBox.Text, tmp, this.localSavesCheckBox.Checked, this.localPathBox.Text,this.openAfterUpload.Checked);
            this.files.serializeSettings(this.settings);
            MessageBox.Show("Saved", "Noti");
        }

        /// <summary>
        /// A function that is called when the checkbox is checked or unchecked.
        /// </summary>
        /// <param name="sender">The object that called the event.</param>
        /// <param name="EventArgs">The event arguments.</param>
        private void localSavesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.localSavesCheckBox.Checked)
            {
                this.localPathBox.Visible = false;
                this.localPathBtn.Visible = false;
            }
            else
            {
                this.localPathBox.Visible = true;
                this.localPathBtn.Visible = true;
            }
            onChange();
        }

        /// <summary>
        /// When the user clicks on the link label, the program will open the default browser and
        /// navigate to the URL specified in the link label
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="LinkLabelLinkClickedEventArgs">This is the event arguments class that contains
        /// the information about the link that was clicked.</param>
        private void siteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://cwute.systems/");
            }
            catch (Exception)
            {
                MessageBox.Show("Unable to open link that was clicked.");
            }
        }

        /// <summary>
        /// A function that is called when the localPathBtn is clicked.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">This is a class that contains information about the event.</param>
        private void localPathBtn_Click(object sender, EventArgs e)
        {
            using (var fldDlg = new FolderBrowserDialog())
            {
                if (fldDlg.ShowDialog() == DialogResult.OK)
                {
                    this.localPathBox.Text = fldDlg.SelectedPath + "\\";
                }
            }
            onChange();
        }

        /// <summary>
        /// A callback function that is called when the user changes the language.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">The event arguments.</param>
        private void changeLanguageCallBack(object sender, EventArgs e)
        {
            changeLanguage();
        }

        /// <summary>
        /// It changes the language of the program.
        /// </summary>
        private void changeLanguage()
        {
            string json;
            if (this.languageEnglishRadio.Checked)
            {
                json = Requests.getMethod("https://cwute.systems/langs/default");
                this.Width = 826;
                this.Height = 493;
                language = Language.English;
            }
            else
            {
                language = Language.English_better;
                json = Requests.getMethod("https://cwute.systems/langs/uwu");
            }
            try
            {
                langTexts lang = JsonConvert.DeserializeObject<langTexts>(json);
                this.titleLabel.Text = lang.titleLabel;
                this.usernameLabel.Text = lang.usernameLabel;
                this.selectLanguageLabel.Text = lang.selectLanguageLabel;
                this.localSavesCheckBox.Text = lang.localSavesCheckBox;
                this.changesNotSavedLabel.Text = lang.changesNotSavedLabel;
                this.saveSettingsBtn.Text = lang.saveSettingsBtn;
                this.siteLinkLabel.Text = lang.siteLinkLabel;
                this.openAfterUpload.Text = lang.siteOpenCheck;
                this.siteOpenLabel.Text = lang.siteOpenLabel;
            }
            catch (System.ArgumentNullException)
            {
                MessageBox.Show("Please connect to internet. App will now exit", "error");
                Thread.Sleep(2000);
                Environment.Exit(1);
            }
            onChange();
        }

        /// <summary>
        /// Another part of changing language.
        /// </summary>
        private void updateLabels()
        {
            this.localSavesCheckBox.Checked = settings.bLocalSaves;
            this.localPathBox.Text = settings.pLocalSaves;
            this.usernameBox.Text = settings.username;
            this.openAfterUpload.Checked = settings.bOpenUpload;

            switch (settings.language)
            {
                case Language.English:
                    this.languageEnglishRadio.Checked = true;
                    break;
                case Language.English_better:
                    this.languageEnglish_uwufiedRadio.Checked = true;
                    break;
            }
            changeLanguage();
            onChange();
        }

        /// <summary>
        /// A function that is called when some settings are changed.
        /// Basically it shows label when some settings are changed.
        /// </summary>
        private void onChange()
        {
            if (
                this.localSavesCheckBox.Checked != settings.bLocalSaves ||
                this.language != settings.language ||
                this.usernameBox.Text != settings.username ||
                this.localPathBox.Text != settings.pLocalSaves ||
                this.openAfterUpload.Checked != settings.bOpenUpload
                )
            {
                this.changesNotSavedLabel.Show();
            }
            else
            {
                this.changesNotSavedLabel.Hide();
            }
        }   
        /// <summary>
        /// A function that is called when the text in the usernameBox is changed.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="EventArgs">This is a class that contains information about the event.</param>
        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            onChange();
        }
        //need to be overriden due to the second form being weird
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (e.CloseReason == CloseReason.WindowsShutDown) return;
            this.thListen.Abort();
        }
        private void openAfterUpload_CheckedChanged(object sender, EventArgs e)
        {
            onChange();

        }
    }
}