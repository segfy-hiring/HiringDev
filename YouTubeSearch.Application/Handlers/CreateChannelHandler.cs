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
    public class CreateChannelHandler : IRequestHandler<CreateChannelCommand, ChannelResponse>
    {
        private readonly IChannelRepository _channelRepository;
        public CreateChannelHandler(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }
        public async Task<ChannelResponse> Handle(CreateChannelCommand request, CancellationToken cancellationToken)
        {
            var channelEntity = ChannelMapper.Mapper.Map<Channel>(request);
            channelEntity.DateCreated = DateTime.Now;
            channelEntity.DateUploaded = DateTime.Now;

            if (channelEntity is null)
                throw new ApplicationException("Issue with mapper");

            if (_channelRepository.GetByYoutubeId(request.YoutubeId) != null || _channelRepository.GetByName(request.Name) != null)
                throw new ArgumentException("This youtube channel already is in the database.");

            var newChannel = _channelRepository.Add(channelEntity);

            var channelResponse = ChannelMapper.Mapper.Map<ChannelResponse>(newChannel);
            return channelResponse;
        }
    }
}
