using System;
using System.Collections;
using System.Collections.Generic;
using CsvReaderBigData.Services;
using Microsoft.AspNetCore.Mvc;
using PricesDashboardBack.HTTP.Requests;
using PricesDashboardBack.Models;
using PricesDashboardBack.Services;
using TinyCsvParser.Mapping;

namespace PricesDashboardBack.HTTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController
    {
        private readonly IPricesService _PricesService;

        public PricesController(IPricesService pricesService)
        {
            _PricesService = pricesService;
        }

        [HttpPost]
        public ActionResult<IEnumerable> getChartData([FromBody] GetPriceRequest request)
        {
            var baseCoinDataSet = CsvReader.readFile(request.BaseCoin);
            var relatedCoinDataSet = CsvReader.readFile(request.RelatedCoin);
            Dictionary<String, List<CsvMappingResult<CoinPrice>>> baseCoinGroupedData;
            Dictionary<String, List<CsvMappingResult<CoinPrice>>> relatedCoinGroupedData;
            switch (request.GroupBy)
            {
                case "month":
                    baseCoinGroupedData = this._PricesService.GroupByOneMonth(baseCoinDataSet);
                    relatedCoinGroupedData = this._PricesService.GroupByOneMonth(relatedCoinDataSet);
                    break;
                case "year":
                    baseCoinGroupedData = this._PricesService.GroupByYear(baseCoinDataSet);
                    relatedCoinGroupedData = this._PricesService.GroupByYear(relatedCoinDataSet);
                    break;
                case "week":
                    baseCoinGroupedData = this._PricesService.GroupByWeek(baseCoinDataSet);
                    relatedCoinGroupedData = this._PricesService.GroupByWeek(relatedCoinDataSet);
                    break;
                case "quarter":
                    baseCoinGroupedData = this._PricesService.GroupByQuarter(baseCoinDataSet);
                    relatedCoinGroupedData = this._PricesService.GroupByQuarter(relatedCoinDataSet);
                    break;
                default:
                    return new BadRequestResult();
            }

            return this._PricesService.CalculatePricesForPairByTasks(baseCoinGroupedData, relatedCoinGroupedData)
                .Result;
        }
    }
}