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
    public class UpdateChannelHandler : IRequestHandler<UpdateChannelCommand, ChannelResponse>
    {
        private readonly IChannelRepository _channelRepository;
        public UpdateChannelHandler(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }
        public async Task<ChannelResponse> Handle(UpdateChannelCommand request, CancellationToken cancellationToken)
        {
            var channel = await _channelRepository.GetByIdAsync(request.Id);

            if (channel == null)
                throw new KeyNotFoundException("Channel Not Found.");

            channel.LastUpdated = DateTime.Now;
            channel.Name = request.Name;
            channel.Description = request.Description;
            channel.Thumbnail = request.Thumbnail;

            channel = _channelRepository.Update(channel);

            var channelResponse = ChannelMapper.Mapper.Map<ChannelResponse>(channel);
            return channelResponse;
        }
    }
}
