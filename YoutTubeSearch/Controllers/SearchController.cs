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
using YouTubeSearch.Application.Queries;
using YouTubeSearch.Application.Responses;
using YouTubeSearch.Core.Entities;

namespace YoutTubeSearch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : BaseController
    {
        private readonly IMediator _mediator;
        public SearchController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromQuery] SearchRequestPaginated filter)
        {
            try
            {
                var result = await _mediator.Send(new GetSearchResultFilteredRequest { Name = filter.Name, PageSize = filter.PageSize, Page = filter.Page, Type = filter.Type});

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
