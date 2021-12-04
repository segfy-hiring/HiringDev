using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YouTubeSearch.Application.Commands;
using YouTubeSearch.Application.Mappers;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories;

namespace YouTubeSearch.Application.Handlers
{
    public class DeleteChannelHandler : IRequestHandler<DeleteChannelCommand, bool>
    {
        private readonly IChannelRepository _channelRepository;
        public DeleteChannelHandler(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }
        public async Task<bool> Handle(DeleteChannelCommand request, CancellationToken cancellationToken)
        {
            var channel = await _channelRepository.GetByIdAsync(request.Id);

            if (channel == null)
                throw new KeyNotFoundException("Channel Not Found.");

            await _channelRepository.DeleteAsync(channel);

            return true;
        }
    }
}
