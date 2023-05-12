using Application.Interfaces;
using Application.Interfaces.Apps;
using Application.Interfaces.Repositories;
using Domain.Entities;
using MapsterMapper;
using ModelDto.Dtos.AracBeklemeDurum;
using ModelDto.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AracBeklemeDurumApps
{
    public class AracBeklemeDurumApp : GenericService<AracBeklemeDurum>, IAracBeklemeDurumApp
    {
        private readonly IAracBeklemeDurumRepository _aracBeklemeDurumRepository;
        private readonly IMapper _mapper;
        public AracBeklemeDurumApp(IRepository<AracBeklemeDurum> repository, IAracBeklemeDurumRepository aracBeklemeDurumRepository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            _aracBeklemeDurumRepository = aracBeklemeDurumRepository;
        }

        public async Task<AracBeklemeDurum> AracBeklemeDurumGetir(int id) => await GetByIdAsync(id);

        public async Task<int> AracBeklemeDurumGuncelle(DtoAracBeklemeDurumGuncelle model)
        {
            var aracBeklemeDurum = await GetByIdAsync(model.Id);
            var sonuc = _mapper.Map(model, aracBeklemeDurum);
            return await UpdateAsync(sonuc);
        }


        public async Task<int> AracBeklemeDurumSil(int id) => await RemoveAsync(id);

        public async Task<int> AracBeklemeDurumKaydet(DtoAracBeklemeDurumKaydet model) => await AddAsync(model.Map<AracBeklemeDurum>());

        public async Task<List<AracBeklemeDurum>> AracBeklemeDurumListesiGetir()
        {
            var sonuc = await _aracBeklemeDurumRepository.GetAllAsync();
            return sonuc.ToList();
        }
    }
}

