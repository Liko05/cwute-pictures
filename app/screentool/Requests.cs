using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace screentool
{
    class Requests
    {
        private static readonly HttpClient client = new HttpClient();
        private static  string POST_URL = "https://cwute.systems/v1/upload-img";
        
        /// <summary>
        /// It returns the method of the request.
        /// </summary>
        /// <param name="url">The URL to be requested.</param>
        public static string getMethod(string url)
        {
            try{
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
            }catch (Exception){
                MessageBox.Show("Error code 08", "error");
            }

            return null;
        }
        
        /// <summary>
        /// It posts an image to the server.
        /// </summary>
        /// <param name="Image">The image to post.</param>
        public static void postImage(Image img, bool open)
        {
            try {

                string data = JsonConvert.SerializeObject(img);
                byte[] dataBytes = Encoding.UTF8.GetBytes(data);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(POST_URL);
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                request.ContentLength = dataBytes.Length;
                request.ContentType = "application/json";
                request.Method = "POST";

                using (Stream requestBody = request.GetRequestStream())
                {
                    requestBody.Write(dataBytes, 0, dataBytes.Length);
                }

                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    string resString = reader.ReadToEnd();
                    Response resObj = JsonConvert.DeserializeObject<Response>(resString);
                    if(resObj.status != "true") {
                        MessageBox.Show("Error code 09", "error");
                        return;
                    }   
                    string clipBoardText = $"https://cwute.systems/viewer/{resObj.message}";
                    System.Windows.Forms.Clipboard.SetText(clipBoardText);
                    MessageBox.Show("Success your link is copied in your clipboard!", "Done");
                    if (!open) return;
                    try
                    {
                        System.Diagnostics.Process.Start(clipBoardText);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Unable to open link.");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error code 08", "error");
            }
        }
    }

    /// <summary>
    /// This class is used to deserialize the response from the server. 
    ///</summary>
    class Response {
        public string status { get; set; }
        public string message { get; set; }
    }
}