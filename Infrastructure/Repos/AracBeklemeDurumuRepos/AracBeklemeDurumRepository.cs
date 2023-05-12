using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos.AracBeklemeDurumuRepos
{
    public class AracBeklemeDurumRepository : Repository<AracBeklemeDurum>, IAracBeklemeDurumRepository
    {
        public AracBeklemeDurumRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
