using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Input;

namespace screentool
{
    class Screenshot
    {
        private Settings settings;
        private Files files;
        public Screenshot(Settings settings, Files files)
        {
            this.settings = settings;
            this.files = files;
        }
        
        /// <summary>
        /// It takes a screenshot and saves it to the file system.
        /// </summary>
        public void takeScreenshotAndSave()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                string tmpName = askForName();
                string name = tmpName;

                DateTime now = DateTime.Now;
                string date = now.ToString("d").Replace("/", "-");

                tmpName = tmpName + now.ToString("f") + ".png";
                tmpName = tmpName.Replace("/", "-");
                tmpName = tmpName.Replace(",", "");
                tmpName = tmpName.Replace(":", "");

                bitmap.Save(settings.pTmpFilesPath + tmpName, ImageFormat.Png);
                if (settings.bLocalSaves)
                {
                    bitmap.Save(settings.pLocalSaves + tmpName, ImageFormat.Png);
                }
                Image tmp = new Image(name, date, settings.username, files.getImageInBase64(settings.pTmpFilesPath + tmpName));
                uploadScreenshot(tmp);
            }
        }
        
        /// <summary>
        /// Uploads a screenshot to the server.
        /// </summary>
        /// <param name="Image">The image to upload.</param>
        public void uploadScreenshot(Image img)
        {
            Thread thUpload = new Thread(() =>
            {
                Requests.postImage(img,settings.bOpenUpload);
            });
            thUpload.SetApartmentState(ApartmentState.STA);
            thUpload.Start();
            thUpload.Join();
        }

        /// <summary>
        /// Starts form that asks for a name and returns entered name.
        /// </summary>
        public string askForName()
        {
            string tmpName = null;
            int attempt = 0;
            while (String.IsNullOrEmpty(tmpName) || String.IsNullOrWhiteSpace(tmpName))
            {
                if (attempt >= 1)
                {
                    MessageBox.Show("Invalid name try again", "error");
                }
                UserInputForm userInputForm = new UserInputForm();
                Application.Run(userInputForm);
                tmpName = userInputForm.title;
                if (!String.IsNullOrWhiteSpace(tmpName))
                {
                    userInputForm.Close();
                    return tmpName;
                }
                attempt++;
            }
            return tmpName;
        }
        
        /// <summary>
        /// A function that runs the program.
        /// </summary>
        public void run()
        {
            while (true)
            {
                Thread.Sleep(20);
                if (Keyboard.IsKeyDown(Key.LeftAlt) 
                    )
                {
                    takeScreenshotAndSave();
                    
                }
            }
        }
    }
}