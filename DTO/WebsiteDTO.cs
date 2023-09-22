﻿using HeadlessCMS.Models;

namespace HeadlessCMS.DTO
{
    public class WebsiteDTO
    {
        public string URL { get; set; }
        public string Name { get; set; }

        public string CreatedOn { get; set; }

        public int id { get; set; }

        public static Website MapToModel(WebsiteDTO websiteDTO)
        {
            var response = new Website()
            {
                id = websiteDTO.id,
                Name = websiteDTO.Name,
                URL = websiteDTO.URL,
              //  CreatedOn = DateTime.UtcNow.ToString(),
            };
            return response;
        }



        public static WebsiteDTO MapToDTO(Website website)
        {
            var response = new WebsiteDTO()
            {
                id = website.id,
                Name = website.Name,
                URL = website.URL,
              //  CreatedOn = website.CreatedOn,
            };
            return response;
        }

    }
}
