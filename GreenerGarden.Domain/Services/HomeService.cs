using GreenerGarden.Data.Entities;
using GreenerGarden.Domain.Interfaces;
using GreenerGarden.Domain.Models;
using GreenerGarden.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Domain.Services
{
    public class HomeService : IHomeService
    {
        private readonly ISeasonRepository _seasonRepository;

        public HomeService(ISeasonRepository seasonRepository)
        {
            _seasonRepository = seasonRepository;
        }
        public async Task<SeasonDomainModel> CreateSeason(SeasonDomainModel newSeason)
        {
            Season seasonToCreate = new Season()
            {
                SeasonStart = newSeason.SeasonStart,
                SeasonEnd = newSeason.SeasonEnd
            };

            var data = _seasonRepository.Insert(seasonToCreate);
            if(data == null)
            {
                return null;
            }

            _seasonRepository.Save();

            SeasonDomainModel domainModel = new SeasonDomainModel()
            {
                Id = data.Id,
                SeasonStart = data.SeasonStart,
                SeasonEnd = data.SeasonEnd
            };

            return domainModel;

        }

        public async Task<SeasonDomainModel> DeleteSeason(int id)
        {
            Season seasonToDelete = await _seasonRepository.Delete(id);

            if (seasonToDelete == null)
            {
                return null;
            }

            _seasonRepository.Save();

            SeasonDomainModel domainModel = new SeasonDomainModel()
            {
                Id = seasonToDelete.Id,
                SeasonStart = seasonToDelete.SeasonStart,
                SeasonEnd = seasonToDelete.SeasonEnd
            };

            return domainModel;
        }

        public async Task<CurrentSeasonDomainModel> GetCurrentSeason()
        {
            Season season = await _seasonRepository.GetCurrentSeason();
            CurrentSeasonDomainModel currentSeason = new CurrentSeasonDomainModel()
            {
                SeasonId = season.Id,

            };
            return currentSeason;
            // throw new NotImplementedException();
        }
    }
}
