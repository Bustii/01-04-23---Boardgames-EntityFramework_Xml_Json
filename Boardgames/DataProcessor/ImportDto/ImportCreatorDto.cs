using Boardgames.Common;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Creator")]
    public class ImportCreatorDto
    {
        [XmlElement("FirstName")]
        [Required]
        [MaxLength(ValidationConstants.CreatorFirstNameMaxLength)]
        [MinLength(ValidationConstants.CreatorFirstNameMinLength)]
        public string FirstName { get; set; } = null!;

        [XmlElement("LastName")]
        [Required]
        [MaxLength(ValidationConstants.CreatorLastNameMaxLength)]
        [MinLength(ValidationConstants.CreatorLastNameMinLength)]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")] 
        public ImportBoardGameDto[] Boardgames { get; set; } = null!;
    }
}
