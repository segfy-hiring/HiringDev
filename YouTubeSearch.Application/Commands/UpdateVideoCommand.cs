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
    public class UpdateVideoCommand : IRequest<VideoResponse>
    {
        [Required]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Thumb { get; set; }
    }
}
