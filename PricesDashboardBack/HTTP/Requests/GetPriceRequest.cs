using System;
using System.ComponentModel.DataAnnotations;

namespace PricesDashboardBack.HTTP.Requests
{
    public class GetPriceRequest
    {
        [Required]
        [RegularExpression("^(bch|btc|dash|dcr|eth|etc)$")]
        public String BaseCoin { get; set; }

        [Required]
        [RegularExpression("^(zec|xmr|pivx|ltc|doge|eth)$")]
        public String RelatedCoin { get; set; }

        [Required] public String GroupBy { get; set; }
    }
}