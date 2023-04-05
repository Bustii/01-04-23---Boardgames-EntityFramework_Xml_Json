using Boardgames.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardGameDto
    {
        [XmlElement("Name")]
        [MinLength(ValidationConstants.BoardGameNameMinLength)]
        [MaxLength(ValidationConstants.BoardGameNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("Rating")]
        [Range(ValidationConstants.BoardGameRatingMinLength, ValidationConstants.BoardGameRatingMaxLength)]
        public string Rating { get; set; } = null!;

        [XmlElement("YearPublished")]
        [Range(ValidationConstants.BoardGameYearPublishedMinLength, ValidationConstants.BoardGameYearPublishedMaxLength)]
        public int YearPublished { get; set; }

        [XmlElement("CategoryType")]
        [Range(ValidationConstants.BoardGameCategoryTypeMinLength, ValidationConstants.BoardGameCategoryTypeMaxLength)]
        public int CategoryType { get; set; }

        [XmlElement("Mechanics")]
        public string Mechanics { get; set; } = null!;
        
    }
}