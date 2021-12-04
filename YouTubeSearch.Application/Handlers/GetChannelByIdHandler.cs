using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YouTubeSearch.Application.Mappers;
using YouTubeSearch.Application.Queries;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Entities;
using YouTubeSearch.Core.Repositories;


namespace YouTubeSearch.Application.Handlers
{
    public class GetChannelByIdHandler : IRequestHandler<GetChannelByIdRequest, ChannelResponse>
    {
        private readonly IChannelRepository _channelRepository;
        public GetChannelByIdHandler(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }
        public async Task<ChannelResponse> Handle(GetChannelByIdRequest request, CancellationToken cancellationToken)
        {
            var channel = await _channelRepository.GetByIdAsync(request.Id);

            if (channel == null)
                throw new KeyNotFoundException("Channel not found.");

            return ChannelMapper.Mapper.Map<ChannelResponse>(channel);
        }
    }

}

