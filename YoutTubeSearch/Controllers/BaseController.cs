using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace YoutTubeSearch.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }
        public bool IsDev
        {
            get
            {
                return Debugger.IsAttached;
            }
        }
    }
}
