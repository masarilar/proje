using Application.Interfaces.Apps;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.Calisma;

namespace WebApi.Controllers
{
    public class CalismaController : ApiControllerBase
    {
        private ICalismaApp _calismaApp { get; set; }

        public CalismaController(ICalismaApp calismaApp)
        {
            _calismaApp = calismaApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CalismaKaydet(DtoCalismaTurKaydet model)
        {
            return Ok(await _calismaApp.CalismaKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CalismaSil([FromBody] int id)
        {
            return Ok(await _calismaApp.CalismaSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CalismaGuncelle(DtoCalismaTurGuncelle model)
        {
            return Ok(await _calismaApp.CalismaGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CalismaGetir([FromBody] int id)
        {
            return Ok(await _calismaApp.CalismaGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> CalismaListesiGetir()
        {
            return Ok(await _calismaApp.CalismaListesiGetir());
        }
    }
}
