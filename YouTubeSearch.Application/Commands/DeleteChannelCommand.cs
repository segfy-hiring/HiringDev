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
    public class DeleteChannelCommand : IRequest<bool>
    {
        [Required]
        public long Id { get; set; }
    }
}
