namespace screentool
{
    internal class Image
    {
        public string name { get; set; }
        public string date { get; set; }
        public string user { get; set; }
        public string imagebase64 { get; set; }
        public Image(string name, string date,string user,string base64)
        {
            this.name = name;
            this.date = date;
            this.user = user;
            this.imagebase64 = base64;
        }
    }
}