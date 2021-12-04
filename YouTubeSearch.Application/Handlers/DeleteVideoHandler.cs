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
    public class DeleteVideoHandler : IRequestHandler<DeleteVideoCommand, bool>
    {
        private readonly IVideoRepository _videoRepository;
        public DeleteVideoHandler(IVideoRepository videoRepository)
        {
            _videoRepository = videoRepository;
        }
        public async Task<bool> Handle(DeleteVideoCommand request, CancellationToken cancellationToken)
        {
            var video = await _videoRepository.GetByIdAsync(request.Id);

            if (video == null)
                throw new KeyNotFoundException("Video Not Found.");

            await _videoRepository.DeleteAsync(video);

            return true;
        }
    }
}
