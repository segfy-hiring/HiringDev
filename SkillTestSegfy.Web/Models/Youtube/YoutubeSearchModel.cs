using Microsoft.AspNetCore.Mvc.Rendering;
using SkillTestSegfy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SkillTestSegfy.Web.Models.Youtube
{
    public class YoutubeSearchModel
    {
        public YoutubeSearchModel()
        {
            ResponseItems = Enumerable.Empty<YoutubeSearchItemModel>();
        }

        public string Term { get; set; }
        public YoutubeItemType? Type { get; set; }
        public int? MaxResults { get; set; }

        public IEnumerable<YoutubeSearchItemModel> ResponseItems { get; set; }
        public string ResponseMessage { get; set; }

        public IEnumerable<SelectListItem> AvailableTypes { get; set; }
        public IEnumerable<SelectListItem> AvailableMaxResults { get; set; }
    }

    public class YoutubeSearchItemModel
    {
        public YoutubeSearchItemModel(YoutubeItem item)
        {
            SearchDateTime = item.SearchDateTime.ToString("g");
            Type = GetTypeStr(item);
            Title = item.Title;
            Description = item.Description;
            Url = item.GetUrl();
            ThumbnailUrl = item.ThumbnailUrl;
            Action = GetActionStr(item);
        }

        public string SearchDateTime { get; }
        public string Type { get; }
        public string Title { get; }
        public string Description { get; }
        public string Url { get; }
        public string ThumbnailUrl { get; }
        public string Action { get; }

        private static string GetTypeStr(YoutubeItem item)
        {
            return item.Type switch
            {
                YoutubeItemType.Video => "VIDEO",
                YoutubeItemType.Channel => "CANAL",
                YoutubeItemType.Playlist => "PLAYLIST",

                _ => throw new InvalidOperationException($"Type {item.Type} does not have a case."),
            };
        }

        private static string GetActionStr(YoutubeItem item)
        {
            return item.Type switch
            {
                YoutubeItemType.Video => "Assistir",
                YoutubeItemType.Channel => "Ver Canal",
                YoutubeItemType.Playlist => "Ver Playlist",

                _ => throw new InvalidOperationException($"Type {item.Type} does not have a case."),
            };
        }
    }
}
