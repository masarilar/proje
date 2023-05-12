using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Birim;

namespace WebApi.Controllers
{
    public class BirimController : ApiControllerBase
    {
        private IBirimApp _birimApp { get; set; }

        public BirimController(IBirimApp birimApp)
        {
            _birimApp = birimApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> BirimKaydet(DtoBirimKaydet model)
        {
            return Ok(await _birimApp.BirimKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> BirimGuncelle(DtoBirimGuncelle model)
        {
            return Ok(await _birimApp.BirimGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> BirimSil([FromBody] int id)
        {
            return Ok(await _birimApp.BirimSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> BirimGetir([FromBody] int id)
        {
            return Ok(await _birimApp.BirimGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> BirimListesiGetir()
        {
            return Ok(await _birimApp.BirimListesiGetir());
        }
    }
}
