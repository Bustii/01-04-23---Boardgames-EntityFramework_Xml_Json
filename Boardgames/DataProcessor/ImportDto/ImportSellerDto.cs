using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Boardgames.Common;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor.ImportDto
{
    public class ImportSellerDto
    {
        [JsonProperty("Name")]
        [Required]
        [MinLength(ValidationConstants.SellerNameMinLength)]
        [MaxLength(ValidationConstants.SellerNameMaxLength)]
        public string Name { get; set; } = null!;

        [JsonProperty("Address")]
        [Required]
        [MinLength(ValidationConstants.SellerAddressMinLength)]
        [MaxLength(ValidationConstants.SellerAddressMaxLength)]
        public string Address { get; set; }

        [JsonProperty("Country")]
        [Required]
        public string Country { get; set; } = null!;

        [JsonProperty("Website")]
        [Required]
        [RegularExpression(ValidationConstants.WebsiteRegEx)]
        public string Website { get; set; } = null!;

        [JsonProperty("Boardgames")] 
        public int[] BoardgamesIds { get; set; } = null!;
    }
}
