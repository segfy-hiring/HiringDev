using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YoutTubeSearch.API.Helpers;
using YoutTubeSearch.API.Models.Requests;
using YoutTubeSearch.Controllers;
using YouTubeSearch.Application.Commands;
using YouTubeSearch.Application.Queries;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Entities;

namespace YoutTubeSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ChannelController : BaseController
    {
        private readonly IMediator _mediator;
        public ChannelController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromQuery] PaginatedRequest request)
        {
            try
            {
                var result = await _mediator.Send(new GetAllChannelRequest { Page = request.Page, PageSize = request.PageSize });

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(new { Message = msg });
            }
        }

        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> Get(long id)
        {
            try
            {
                var result = await _mediator.Send(new GetChannelByIdRequest { Id = id});

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(new { Message = msg });
            }
        }

        [HttpPost]
        [Route("Post")]
        public async Task<IActionResult> Post([FromBody] CreateChannelCommand request)
        {
            try
            {
                var result = await _mediator.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(new { Message = msg });
            }
        }

        [HttpPut]
        [Route("Put")]
        public async Task<IActionResult> Put([FromBody] UpdateChannelCommand request)
        {
            try
            {
                var result = await _mediator.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(new { Message = msg });
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteChannelCommand request)
        {
            try
            {
                var result = await _mediator.Send(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                var msg = ex.InnerException == null ? ex.Message : ex.InnerException.Message;

                return BadRequest(new { Message = msg });
            }
        }
    }
}
