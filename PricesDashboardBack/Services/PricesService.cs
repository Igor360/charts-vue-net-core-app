using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Globalization;
using System.Linq;
using PricesDashboardBack.Models;
using TinyCsvParser.Mapping;

namespace PricesDashboardBack.Services
{
    public class PricesService : IPricesService
    {
        private const String BASE_TIME_FORMAT = "yyyy-MM-dd";

        public Dictionary<String, List<CsvMappingResult<CoinPrice>>> GroupByOneMonth(
            List<CsvMappingResult<CoinPrice>> csvData)
        {
            var cultureInfo = new CultureInfo("en-US");
            return csvData
                .Where(x => x.Result?.date != null)
                .Select(x => new {Date = DateTime.ParseExact(x.Result.date, BASE_TIME_FORMAT, cultureInfo), Data = x})
                .GroupBy(x => $"{x.Date.Month}/{x.Date.Year}")
                .ToDictionary(x => x.First().Date.ToString("yyyy-MM"), y => y.Select(el => el.Data).ToList());
        }

        public Dictionary<String, List<CsvMappingResult<CoinPrice>>> GroupByWeek(
            List<CsvMappingResult<CoinPrice>> csvData)
        {
            var cultureInfo = new CultureInfo("en-US");
            return csvData
                .Where(x => x.Result?.date != null)
                .Select(x => new {Date = DateTime.ParseExact(x.Result.date, BASE_TIME_FORMAT, cultureInfo), Data = x})
                .GroupBy(x =>  $"{x.Date.Year} " + x.Date.ToString("ddd"))
                .ToDictionary(x =>  $"{x.First().Date.Year} " + x.First().Date.ToString("ddd"), y => y.Select(el => el.Data).ToList());
        }


        public Dictionary<String, List<CsvMappingResult<CoinPrice>>> GroupByQuarter(
            List<CsvMappingResult<CoinPrice>> csvData)
        {
            var cultureInfo = new CultureInfo("en-US");
            return csvData
                .Where(x => x.Result?.date != null)
                .Select(x => new {Date = DateTime.ParseExact(x.Result.date, BASE_TIME_FORMAT, cultureInfo), Data = x})
                .GroupBy(x => $"{x.Date.Year} Q" + (1 + (int) (x.Date.Month - 1) / 3))
                .ToDictionary(x => $"{x.First().Date.Year} Q" + (1 + (int) (x.First().Date.Month - 1) / 3),
                    y => y.Select(el => el.Data).ToList());
        }


        public Dictionary<String, List<CsvMappingResult<CoinPrice>>> GroupByYear(
            List<CsvMappingResult<CoinPrice>> csvData)
        {
            var cultureInfo = new CultureInfo("en-US");
            return csvData
                .Where(x => x.Result?.date != null)
                .Select(x => new {Date = DateTime.ParseExact(x.Result.date, BASE_TIME_FORMAT, cultureInfo), Data = x})
                .GroupBy(x => x.Date.Year)
                .ToDictionary(x => x.First().Date.ToString("yyyy"), y => y.Select(el => el.Data).ToList());
        }

        public Dictionary<String, Double> CalculatePricesForPair(
            Dictionary<String, List<CsvMappingResult<CoinPrice>>> baseCoin,
            Dictionary<String, List<CsvMappingResult<CoinPrice>>> relatedCoin)
        {
            var res = new Dictionary<String, Double>();
            foreach (var keyValuePair in baseCoin)
            {
                if (!relatedCoin.ContainsKey(keyValuePair.Key))
                {
                    continue;
                }

                var baseMediumPrice =
                    keyValuePair.Value.ToList().Sum(x => x.Result.priceusd) / keyValuePair.Value.ToList().Count;
                var relatedMediumPrice = relatedCoin[keyValuePair.Key].ToList().Sum(x => x.Result.priceusd) /
                                         relatedCoin[keyValuePair.Key].ToList().Count;
                res.Add(keyValuePair.Key, baseMediumPrice / relatedMediumPrice);
            }

            return res;
        }
    }
}