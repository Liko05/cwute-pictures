using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace screentool
{
    class Files
    {
        private Settings settings;
        public Files(Settings settings)
        {
            this.settings = settings;
        }
        
        /// <summary>
        /// It takes a Settings object and saves it to a file
        /// </summary>
        /// <param name="Settings">The settings class</param>
        public void serializeSettings(Settings updatedSettings)
        {
            this.settings = updatedSettings;

            try
            {
                FileStream fileStream = new FileStream(settings.pCfg, FileMode.OpenOrCreate);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, settings);
                fileStream.Close();
                Console.WriteLine("[Debug] settings saved");
            }
            catch (System.UnauthorizedAccessException)
            {
                MessageBox.Show("Error code 04", "Error");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Error code 05", "Error");
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong and  i have no clue why","error");
            }
        }
        
        /// <summary>
        /// It takes a path to a file and returns the file in base64 format
        /// </summary>
        /// <param name="PathToFile">The path to the file you want to convert to base64.</param>
        /// <returns>
        /// A string of the image in base64
        /// </returns>
        public string getImageInBase64(string PathToFile)
        {
            try{
                byte[] byteData = File.ReadAllBytes(PathToFile);
                return Convert.ToBase64String(byteData);
            }
            catch{
                MessageBox.Show("Error code 02", "error");
                return null;
            }
        }
    }
}
