namespace HeadlessCMS.Models
{
    public class Content
    {
        public int id { get; set; }
        public string Text { get; set; }
        public int Component_id { get; set; }

        public Media mediaJSON { get; set; }

        public string Title { get; set; }
        public class Media
        {
            public string Imageurl { get; set; }
            public string AltText { get; set; }
            public string VideoUrl { get; set; }

        }
    }
}
        