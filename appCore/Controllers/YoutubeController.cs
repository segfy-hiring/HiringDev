using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using appcore.Models;
using appcore.Services;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;

namespace appcore.Controllers 
    {
    
    [ApiController]
    [Route("[controller]")]
    public class YoutubeController : ControllerBase 
    {

        private readonly YoutubeService _ytService;

        public YoutubeController(YoutubeService ytService)
        {
            _ytService = ytService;
        }

        [EnableCors("MyPolicy")]
        [HttpGet]
        public ActionResult<List<YoutubeModel>> Get() =>
            _ytService.Get();

        [HttpGet("{id:length(24)}", Name = "GetYt")]
        public ActionResult<YoutubeModel> Get(string id)
        {
            var yt = _ytService.Get(id);

            if (yt == null)
            {
                return NotFound();
            }

            return yt;
        }

        [HttpPost]
        public ActionResult<YoutubeModel> Create(YoutubeModel yt)
        {
            _ytService.Create(yt);

            return CreatedAtRoute("Getyt", new { id = yt._id.ToString() }, yt);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, YoutubeModel ytIn)
        {
            var yt = _ytService.Get(id);

            if (yt == null)
            {
                return NotFound();
            }

            _ytService.Update(id, ytIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var yt = _ytService.Get(id);

            if (yt == null)
            {
                return NotFound();
            }

            _ytService.Remove(yt._id);

            return NoContent();
        }

    }
}