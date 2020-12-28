using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PricesDashboardBack.Models;
using TinyCsvParser.Mapping;

namespace PricesDashboardBack.Services
{
    public interface IPricesService
    {
        public Dictionary<String, List<CsvMappingResult<CoinPrice>>> GroupByOneMonth(
            List<CsvMappingResult<CoinPrice>> csvData);

        public Dictionary<String, List<CsvMappingResult<CoinPrice>>> GroupByWeek(
            List<CsvMappingResult<CoinPrice>> csvData);

        public Dictionary<String, List<CsvMappingResult<CoinPrice>>> GroupByQuarter(
            List<CsvMappingResult<CoinPrice>> csvData);

        public Dictionary<String, List<CsvMappingResult<CoinPrice>>> GroupByYear(
            List<CsvMappingResult<CoinPrice>> csvData);

        public Dictionary<String, Double> CalculatePricesForPair(
            Dictionary<String, List<CsvMappingResult<CoinPrice>>> baseCoin,
            Dictionary<String, List<CsvMappingResult<CoinPrice>>> relatedCoin);

        public Task<Dictionary<String, Double>> CalculatePricesForPairByTasks(
            Dictionary<String, List<CsvMappingResult<CoinPrice>>> baseCoin,
            Dictionary<String, List<CsvMappingResult<CoinPrice>>> relatedCoin);
    }
}