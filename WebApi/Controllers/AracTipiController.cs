using Application.AracTipiApps;
using Application.Interfaces.Apps;
using Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Dtos.AracTipi;
using ModelDto.Dtos.Genel;

namespace WebApi.Controllers
{
    public class AracTipiController : ApiControllerBase
    {
        private IAracTipiApp _aractipiApp { get; set; }
        public AracTipiController(IAracTipiApp aracTipiApp) {
            _aractipiApp = aracTipiApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracTipiKaydet(DtoAracTipiKaydet model)
        {
            return Ok(await _aractipiApp.AracTipiKaydet(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracTipiGuncelle(DtoAracTipiGuncelle model)
        {
            return Ok(await _aractipiApp.AracTipiGuncelle(model));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracTipiSil([FromBody]int id)
        {
            return Ok(await _aractipiApp.AracTipiSil(id));
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> AracTipiGetir([FromBody]int id)
        {
            return Ok(await _aractipiApp.AracTipiGetir(id));
        }

        [HttpGet]
        public async Task<IActionResult> AracTipiListesiGetir()
        {
            return Ok(await _aractipiApp.AracTipiListesiGetir());
        }

    }
}
