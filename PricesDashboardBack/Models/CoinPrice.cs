using System;

namespace PricesDashboardBack.Models
{
    public class CoinPrice
    {
        public String date { get; set; }

        public Int32 adractcnt { get; set; }

        public Int32 blkcnt { get; set; }

        public Int32 blksizebyte { get; set; }

        public Double blksizemeanbyte { get; set; }

        public Double capmvrvcur { get; set; }

        public Double capmrktcurusd { get; set; }

        public Double caprealusd { get; set; }

        public Double diffmean { get; set; }

        public Double feemeanntv { get; set; }

        public Double feemeanusd { get; set; }

        public Double feemedntv { get; set; }

        public Double feemedusd { get; set; }

        public Double hashrate { get; set; }

        public Double isscontntv { get; set; }

        public Double isscontpctann { get; set; }

        public Double isscontusd { get; set; }

        public Double isstotntv { get; set; }

        public Double isstotusd { get; set; }

        public Double nvtadj { get; set; }

        public Double nvtadj90 { get; set; }

        public Double pricebtc { get; set; }

        public Double priceusd { get; set; }

        public Double roi1yr { get; set; }

        public Double roi30d { get; set; }

        public Double splycur { get; set; }

        public Double splyexpfut10yrcmbi { get; set; }

        public Double splyff { get; set; }

        public Double txcnt { get; set; }

        public Double txtfrcnt { get; set; }

        public Double txtfrvaladjntv { get; set; }

        public Double txtfrvaladjusd { get; set; }

        public Double txtfrvalmeanntv { get; set; }

        public Double txtfrvalmeanusd { get; set; }

        public Double txtfrvalmedntv { get; set; }

        public Double txtfrvalmedusd { get; set; }

        public Double txtfrvalntv { get; set; }

        public Double txtfrvalusd { get; set; }

        public Double vtydayret180d { get; set; }

        public Double vtydayret30d { get; set; }
        
        public Double vtydayret60d { get; set; }
    }
}