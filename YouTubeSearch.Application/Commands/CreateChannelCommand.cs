using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YouTubeSearch.Application.Responses;

namespace YouTubeSearch.Application.Commands
{
    public class CreateChannelCommand : IRequest<ChannelResponse>
    {
        [Required]
        public string YoutubeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Thumbnail { get; set; }
    }
}
