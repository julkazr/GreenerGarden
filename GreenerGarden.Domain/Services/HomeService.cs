﻿using GreenerGarden.Data.Entities;
using GreenerGarden.Domain.Interfaces;
using GreenerGarden.Domain.Models;
using GreenerGarden.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Domain.Services
{
    public class HomeService : IHomeService
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly ICultureRepository _cultureRepository;
        private readonly ICropYieldRepository _cropYealdRepository;
        private readonly IExpenceRepository _expenceRepository;

        public HomeService(ISeasonRepository seasonRepository, 
                           ICultureRepository cultureRepository,
                           ICropYieldRepository cropYealdRepository,
                           IExpenceRepository expenceRepository)
        {
            _seasonRepository = seasonRepository;
            _cultureRepository = cultureRepository;
            _cropYealdRepository = cropYealdRepository;
            _expenceRepository = expenceRepository;
        }
        public async Task<SeasonDomainModel> CreateSeason(SeasonDomainModel newSeason)
        {
            Season seasonToCreate = new Season()
            {
                Year = newSeason.Year
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
                Year = data.Year
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
                Year = seasonToDelete.Year
            };

            return domainModel;
        }

        public async Task<CurrentSeasonDomainModel> GetCurrentSeason(int year)
        {
            Season season = await _seasonRepository.GetCurrentSeason(year);
            CurrentSeasonDomainModel currentSeason = new CurrentSeasonDomainModel();

            var cultures =season.Cultures;
            var cultureNames = new List<string>();
            var cropYieldsPerSeason = new List<float>();
            var culturesTotalExpences = new List<float>();
            var culturesProfits = new List<float>();

            foreach (var item in cultures)
            {
                var cultureName = item.Name;
                cultureNames.Add(cultureName);

                var cropYields = _cropYealdRepository.GetByCultureId(item.CultureId);
                var cropsAmountPerCulture = new List<float>();
                foreach (var crop in cropYields)
                {
                    var amount = crop.Amount;
                    cropsAmountPerCulture.Add(amount);
                }
                var totalCropsPerCulture = cropsAmountPerCulture.Sum();
                cropYieldsPerSeason.Add(totalCropsPerCulture);

                var cultureExpences = _expenceRepository.GetByCultureId(item.CultureId);
                var expencesAmountsPerCulture = new List<float>();
                foreach (var expence in cultureExpences)
                {
                    var amount = expence.ExpenceAmount;
                    expencesAmountsPerCulture.Add(amount);
                }
                var totalExpencesAmounts = expencesAmountsPerCulture.Sum();
                culturesTotalExpences.Add(totalExpencesAmounts);

                var cultureProfit = totalCropsPerCulture * item.Price - totalExpencesAmounts;
                culturesProfits.Add(cultureProfit);
            }

            var expencesPerSeason = culturesTotalExpences.Sum();
            var profitPerSeason = culturesProfits.Sum();

            currentSeason.SeasonId = season.Id;
            //currentSeason.Cultures = cultures; TODO translate data model to domain model
            currentSeason.CultureCropYields = cropYieldsPerSeason;
            currentSeason.CultureExpencesAmounts = culturesTotalExpences;
            currentSeason.CultureProfits = culturesProfits;
            currentSeason.SeasonExpence = expencesPerSeason;
            currentSeason.SeasonProfit = profitPerSeason;

            return currentSeason;
        }
    }
}
