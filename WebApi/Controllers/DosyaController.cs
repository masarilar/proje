using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    public class DosyaController : ApiControllerBase {
        private readonly IDosyaApp _dosyaApp;
        public DosyaController(IDosyaApp dosyaApp) {
            _dosyaApp = dosyaApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> DosyaGetir([FromBody] int id) {
            return Ok(await _dosyaApp.DosyaGetir(id));
        }
        
        [HttpPost("[action]")]
        public async Task<IActionResult> DosyaSil([FromBody] int id) {
            return Ok(await _dosyaApp.DosyaSil(id));
        }
    }
}
