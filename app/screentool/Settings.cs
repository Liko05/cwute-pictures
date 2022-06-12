using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace screentool
{
    [Serializable]
    class Settings
    {
        public string username { get; set; }
        public Language language { get; set; }
        public bool bLocalSaves { get; set; }
        public string pLocalSaves { get; set; }
        public string pTmpFilesPath { get; set; }
        public string pCfg { get; set; }
        public string pCfgFolder { get; set; }
        public bool bOpenUpload { get; set; }
        public Settings(string username,Language language,bool bLocalSaves,string pLocalSaves, bool bOpenUpload)
        {
            this.pTmpFilesPath = "C:\\Users\\" +Environment.UserName +"\\AppData\\Local\\cwute\\";
            this.pCfg = "C:\\Users\\" +Environment.UserName +"\\Documents\\cwute\\user.cfg";
            this.pCfgFolder = "C:\\Users\\" + Environment.UserName + "\\Documents\\cwute\\";

            if (!Directory.Exists(pCfgFolder))
            {
                Directory.CreateDirectory (pCfgFolder);
            }

            if (!Directory.Exists(pTmpFilesPath))
            {
                Directory.CreateDirectory (pTmpFilesPath);
            }

            if (File.Exists(pCfg))
            {
                try
                {
                    FileStream stream = new FileStream(pCfg, FileMode.OpenOrCreate);
                    BinaryFormatter formatter = new BinaryFormatter();

                    Settings tmp = (Settings) formatter.Deserialize(stream);

                    this.username = tmp.username;
                    this.language = tmp.language;
                    this.bLocalSaves = tmp.bLocalSaves;
                    this.pLocalSaves = tmp.pLocalSaves;
                    this.bOpenUpload = tmp.bOpenUpload;
                    stream.Close();
                }
                catch (AccessViolationException ex)
                {
                    MessageBox.Show("Application cannot settings write to this location on disk.","Error");
                }
                catch(SerializationException e)
                {
                    MessageBox.Show("Error code 07", "error");
                }
            }
            else
            {
                this.username = username;
                this.language = language;
                this.bLocalSaves = bLocalSaves;
                this.pLocalSaves = pLocalSaves;
                this.bOpenUpload = bOpenUpload;
            }
        }

        /// <summary>
        /// It updates the settings of the user.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="Language">The language you want to use.</param>
        /// <param name="bLocalSaves">Whether or not to save the game locally.</param>
        /// <param name="pLocalSaves">The path to the local saves folder.</param>
        public void updateSettings(string username,Language language,bool bLocalSaves,string pLocalSaves, bool bOpenUpload)
        {
            this.username = username;
            this.language = language;
            this.bLocalSaves = bLocalSaves;
            this.pLocalSaves = pLocalSaves;
            this.bOpenUpload = bOpenUpload;
        }
    }
}