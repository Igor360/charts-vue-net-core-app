using System;
using System.ComponentModel.DataAnnotations;

namespace PricesDashboardBack.HTTP.Requests
{
    public class GetPriceRequest
    {
        [Required]
        [RegularExpression("^(bch|btc|dash|dcr|eth|etc|bch|xem|zec|vtc|xmr|pivx|ltc|doge)$")]
        public String BaseCoin { get; set; }

        [Required]
        [RegularExpression("^(bch|btc|dash|dcr|eth|etc|bch|xem|zec|vtc|xmr|pivx|ltc|doge)$")]
        public String RelatedCoin { get; set; }

        [Required] public String GroupBy { get; set; }
    }
}