using BibleTreasure.Models;

namespace BibleTreasure.Repository
{
    public interface ITreasure
    {
        Task<Treasures> GetTodayTreasure();
    }
}
