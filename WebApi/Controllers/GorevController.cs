using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Gorev;

namespace WebApi.Controllers
{
    public class GorevController : ApiControllerBase
    {
        private IGorevApp _gorevApp { get; set; }

        public GorevController(IGorevApp gorevApp)
        {
            _gorevApp = gorevApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GorevKaydet(DtoGorevKaydet model)
        {
            return Ok(await _gorevApp.GorevKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GorevSil([FromBody] int id)
        {
            return Ok(await _gorevApp.GorevSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GorevGuncelle(DtoGorevGuncelle model)
        {
            return Ok(await _gorevApp.GorevGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GorevGetir([FromBody] int id)
        {
            return Ok(await _gorevApp.GorevGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> GorevListesiGetir()
        {
            return Ok(await _gorevApp.GorevListesiGetir());
        }
    }
}
