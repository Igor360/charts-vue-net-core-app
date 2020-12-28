using PricesDashboardBack.Models;
using TinyCsvParser.Mapping;

namespace PricesDashboardBack.Mappings
{
    public class CoinPriceMapping : CsvMapping<CoinPrice>
    {
        public CoinPriceMapping() : base()
        {
            MapProperty(0, price => price.date);
            MapProperty(1, price => price.adractcnt);
            MapProperty(2, price => price.blkcnt);
            MapProperty(3, price => price.blksizebyte);
            MapProperty(4, price => price.blksizemeanbyte);
            MapProperty(5, price => price.capmvrvcur);
            MapProperty(6, price => price.capmrktcurusd);
            MapProperty(7, price => price.caprealusd);
            MapProperty(8, price => price.diffmean);
            MapProperty(9, price => price.feemeanntv);
            MapProperty(10, price => price.feemeanusd);
            MapProperty(11, price => price.feemedntv);
            MapProperty(12, price => price.feemedusd);
            MapProperty(13, price => price.hashrate);
            MapProperty(14, price => price.isscontntv);
            MapProperty(15, price => price.isscontpctann);
            MapProperty(16, price => price.isscontusd);
            MapProperty(17, price => price.isstotntv);
            MapProperty(18, price => price.isstotusd);
            MapProperty(19, price => price.nvtadj);
            MapProperty(20, price => price.nvtadj90);
            MapProperty(21, price => price.pricebtc);
            MapProperty(22, price => price.priceusd);
            MapProperty(23, price => price.roi1yr);
            MapProperty(24, price => price.roi30d);
            MapProperty(25, price => price.splyff);
            MapProperty(26, price => price.txcnt);
            MapProperty(27, price => price.txtfrcnt);
            MapProperty(28, price => price.txtfrvaladjntv);
            MapProperty(29, price => price.txtfrvaladjusd);
            MapProperty(30, price => price.txtfrvalmeanntv);
            MapProperty(31, price => price.txtfrvalmeanusd);
            MapProperty(32, price => price.txtfrvalmedntv);
            MapProperty(33, price => price.txtfrvalmedusd);
            MapProperty(34, price => price.txtfrvalntv);
            MapProperty(35, price => price.txtfrvalusd);
            MapProperty(36, price => price.vtydayret180d);
            MapProperty(37, price => price.vtydayret30d);
            MapProperty(38, price => price.vtydayret60d);
        }
    }
}