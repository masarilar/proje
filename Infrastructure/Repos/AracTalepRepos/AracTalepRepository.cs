using Application.Interfaces;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repos.AracTalepRepos
{
    public class AracTalepRepository : Repository<AracTalep>, IAracTalepRepository
    {
        public AracTalepRepository(IApplicationDbContext applicationDbContext) : base(applicationDbContext)
        {
        }
    }
}
