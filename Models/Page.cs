namespace HeadlessCMS.Models
{
    public class page
    {
        public int id { get; set; }
        public string name { get; set; }

        public DateTime created { get; set; }

        public int websiteID { get; set; } // foreign key

        public string url { get; set; }
        


    }
}
