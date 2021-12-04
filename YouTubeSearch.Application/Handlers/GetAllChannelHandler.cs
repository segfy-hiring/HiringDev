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
    public class GetAllChannelHandler : IRequestHandler<GetAllChannelRequest, PaginatedChannelResponse>
    {
        private readonly IChannelRepository _channelRepository;
        public GetAllChannelHandler(IChannelRepository channelRepository)
        {
            _channelRepository = channelRepository;
        }
        public async Task<PaginatedChannelResponse> Handle(GetAllChannelRequest request, CancellationToken cancellationToken)
        {
            var response = new PaginatedChannelResponse
            {
                Page = request.Page,
                PageSize = request.PageSize,
            };

            var channels = await _channelRepository.GetAllAsync();

            var paginated = channels.Skip((request.Page - 1) * request.PageSize).Take(request.PageSize);

            foreach(var channel in paginated)
            {
                response.Channels.Add(ChannelMapper.Mapper.Map<ChannelResponse>(channel));
            }

            response.Total = channels.Count();

            return response;
        }
    }

}
