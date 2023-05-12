using Application.Interfaces;
using Application.Interfaces.Apps;
using Domain.Entities;
using MapsterMapper;
using ModelDto.Dtos.Gorev;
using ModelDto.General;

namespace Application.GorevApps
{
    public class GorevApp : GenericService<Gorev>, IGorevApp
    {
        private readonly IMapper _mapper;
        public GorevApp(IRepository<Gorev> repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
        }
        public async Task<int> GorevKaydet(DtoGorevKaydet model) => await AddAsync(model.Map<Gorev>());
        public async Task<int> GorevGuncelle(DtoGorevGuncelle model)
        {
            var gorev = await GetByIdAsync(model.Id);
            var sonuc = _mapper.Map(model, gorev);
            return await UpdateAsync(sonuc);
        }
        public async Task<int> GorevSil(int id) => await RemoveAsync(id);
        public async Task<Gorev> GorevGetir(int id) => await GetByIdAsync(id);
        public async Task<List<Gorev>> GorevListesiGetir()
        {
            var sonuc = await GetAllAsync();
            return sonuc.ToList();
        }
    }
}
