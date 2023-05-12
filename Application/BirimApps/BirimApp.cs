using Application.DuyuruApps;
using Application.Interfaces;
using Application.Interfaces.Apps;
using Application.Interfaces.Repositories;
using Domain.Entities;
using ModelDto.Dtos.Birim;
using ModelDto.General;


namespace Application.BirimApps
{
    public class BirimApp : GenericService<Birim>, IBirimApp
    {
        private readonly IBirimRepository _birimRepository;
        public BirimApp(IRepository<Birim> repository, IBirimRepository birimRepository) : base(repository)
        {
            _birimRepository = birimRepository;
        }
        public async Task<int> BirimKaydet(DtoBirimKaydet model) => await AddAsync(model.Map<Birim>());
        public async Task<int> BirimGuncelle(DtoBirimGuncelle model) => await UpdateAsync(model.Map<Birim>());
        public async Task<int> BirimSil(DtoBirimSil model) => await RemoveAsync(model.Id);
        public async Task<List<Birim>> BirimListesiGetir()
        {
            var sonuc = await _birimRepository.GetAllListAsync();
            // var liste = await GetAllAsync();
            return sonuc.ToList();
        }
        public async Task<Birim> BirimGetir(int id) => await GetByIdAsync(id);
        public async Task<int> BirimSil(int id) => await RemoveAsync(id);
    }
}
