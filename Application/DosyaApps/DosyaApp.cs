using Application.Interfaces;
using Application.Interfaces.Apps;
using Application.Interfaces.Repositories;
using Domain.Entities;
using ModelDto.Dtos.Dosya;
using ModelDto.General;

namespace Application.DosyaApps
{
    public class DosyaApp : GenericService<Dosya>, IDosyaApp {
        private readonly IDosyaRepository _dosyaRepository;

        public DosyaApp(IRepository<Dosya> repository, IDosyaRepository dosyaRepository) : base(repository) {
            _dosyaRepository = dosyaRepository;
        }

        public async Task<DtoDosya> DosyaGetir(int id) {
            var dosya = await _dosyaRepository.GetByIdAsync(id);
            return dosya.Map<DtoDosya>();
        }
        public async Task<int> DosyaSil(int id) => await _dosyaRepository.RemoveAsync(id);
    }
}
