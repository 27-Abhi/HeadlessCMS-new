namespace HeadlessCMS.Models
{
    public class Page
    {
        public int id { get; set; }
        public string name { get; set; }

        public string CreatedOn { get; set; }

        public int websiteID { get; set; } // foreign key

        public string url { get; set; }
        


    }
}
