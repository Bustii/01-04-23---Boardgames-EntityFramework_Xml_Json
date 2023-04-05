using Boardgames.DataProcessor.ExportDto;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Trucks.Utilities;

namespace Boardgames.DataProcessor
{
    using Boardgames.Data;

    public class Serializer
    {
        private static XmlHelper xmlHelper;

        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            xmlHelper = new XmlHelper();

            ExportCreatorDto[] creators = context.Creators
                .Where(c => c.Boardgames.Any())
                .Select(c => new ExportCreatorDto()
                {
                    CreatorName = c.FirstName + " " + c.LastName,
                    BoardgamesCount = c.Boardgames.Count,
                    Boardgames = c.Boardgames
                        .Select(bg => new ExportBoardgameDto()
                        {
                            BoardgameName = bg.Name,
                            BoardgameYearPublished = bg.YearPublished
                        })
                        .OrderBy(bg => bg.BoardgameName)
                        .ToArray()
                })
                .OrderByDescending(c => c.BoardgamesCount)
                .ThenBy(c => c.CreatorName)
                .ToArray();

            return xmlHelper.Serialize(creators, "Creators");
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {
            var sellers = context.Sellers
                .Include(c => c.BoardgamesSellers)
                .ThenInclude(bgs => bgs.Boardgame)
                .AsNoTracking()
                .ToArray()
                .Where(c => c.BoardgamesSellers.Any(bgs => bgs.Boardgame.YearPublished >= year && bgs.Boardgame.Rating <= rating))
                    .Select(c => new
                    {
                        c.Name,
                        c.Website,
                        Boardgames = c.BoardgamesSellers
                        .Where(bgs => bgs.Boardgame.YearPublished >= year && bgs.Boardgame.Rating <= rating)
                        .Select(bgs => new
                        {
                            Name = bgs.Boardgame.Name,
                            Rating = bgs.Boardgame.Rating,
                            Mechanics = bgs.Boardgame.Mechanics,
                            Category = bgs.Boardgame.CategoryType.ToString()
                        })
                        .OrderByDescending(r => r.Rating)
                        .ThenBy(n => n.Name)
                        .ToArray()
                    })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(n => n.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers, Formatting.Indented);
        }
    }
}