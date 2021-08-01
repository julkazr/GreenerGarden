using GreenerGarden.Domain.Interfaces;
using GreenerGarden.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Domain.Services
{
    public class HomeService : IHomeService
    {
        public Task<SeasonDomainModel> CreateSeason(SeasonDomainModel newSeason)
        {
            throw new NotImplementedException();
        }

        public Task<SeasonDomainModel> DeleteSeason(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CurrentSeasonDomainModel>> GetCurrentSeason(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
