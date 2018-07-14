using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pasty.Api.Services;
using Pasty.Core;

namespace Pasty.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasteController : ControllerBase
    {
        private readonly IPasteService pastService;

        public PasteController(IPasteService pastService)
        {
            this.pastService = pastService;
        }

        // GET api/paste/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(this.pastService.GetPasteAsync(id));
        }

        // POST api/paste
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PasteDto dto)
        {
            var result = await this.pastService.StorePaste(dto);
            return Ok(result);
        }
    }
}
