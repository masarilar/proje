using Application.Interfaces;
using Application.Interfaces.Apps;
using Application.Interfaces.Repositories;
using Domain.Entities;
using MapsterMapper;
using ModelDto.Dtos.AracTalep;
using ModelDto.Dtos.Kullanici;
using ModelDto.General;

namespace Application.AracTalepApps
{
    public class AracTalepApp : GenericService<AracTalep>, IAracTalepApp
    {
        private readonly IAracTalepRepository _aracTalepRepository;
        private readonly IMapper _mapper;
        public AracTalepApp(IRepository<AracTalep> repository, IAracTalepRepository aracTalepRepository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            _aracTalepRepository = aracTalepRepository;
        }
        public async Task<AracTalep> AracTalepGetir(int id)
        {
            var aracTalep = await GetByIdAsync(id);
            return aracTalep;
        }
        public async Task<int> AracTalepGuncelle(DtoAracTalepGuncelle model)
        {
            var aracTalep = await GetByIdAsync(model.Id);
            var sonuc = _mapper.Map(model, aracTalep);
            return await UpdateAsync(sonuc);
        }
        public async Task<int> AracTalepKaydet(DtoAracTalepKaydet model)
        {
            var aracTalepId=await AddAsync(model.Map<AracTalep>());
            return aracTalepId;
        }
        public async Task<List<AracTalep>> AracTalepListesiGetir()
        {
            var sonuc = await _aracTalepRepository.GetAllAsync();
            return sonuc.ToList();
        }
        public async Task<int> AracTalepSil(int id) => await RemoveAsync(id);
    }
}
