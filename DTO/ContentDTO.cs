using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RestSharp;

namespace HeadlessCMS.DTO
{
    public class ContentDTO
    {
        public int id { get; set; }
        public string Text { get; set; }
        public int Component_id { get; set; }

        //public JsonO    bject<string[]> MediaJSON { get; set; } // Json storage

        public Media MediaJSON { get; set; }

      //  [Newtonsoft.Json.JsonIgnore] // Optional: Ignore this property during serialization
      //  public Media media => JsonConvert.DeserializeObject<Media>(media);
        public string Title { get; set; }


   
        public class Media
        {
            public string imageurl { get; set; }
            public string alttext { get; set; } 
            public string videourl { get; set; }

        }

        //public Media DeserializeMediaJSON()
        //{
        //    return JsonSerializer.Deserialize<Media>(MediaJSON);
        //}

        //public void SerializeMediaJSON(Media media)
        //{
        //    MediaJSON = JsonSerializer.Serialize(media);
        //}




    }

   

}
        