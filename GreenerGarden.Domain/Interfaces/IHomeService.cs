using GreenerGarden.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GreenerGarden.Domain.Interfaces
{
    public interface IHomeService
    {
        ///<summary>
        ///Get current season with cultures, expences, crop, and profit
        ///</summary>
        ///<param name="date"></param>
        ///<returns></returns>
        Task<IEnumerable<CurrentSeasonDomainModel>> GetCurrentSeason(DateTime date);

        ///<summary>
        ///Create new season
        ///</summary>
        ///<param name="newSeason"></param>
        ///<returns></returns>
        Task<SeasonDomainModel> CreateSeason(SeasonDomainModel newSeason);

        ///<summary>
        ///Delete season by id
        ///</summary>
        ///<param name="id"></param>
        ///<returns></returns>
        Task<SeasonDomainModel> DeleteSeason(int id);
    }
}
