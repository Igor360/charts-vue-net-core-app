using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PricesDashboardBack.Mappings;
using PricesDashboardBack.Models;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace CsvReaderBigData.Services
{
    /**
     * @class CsvReader
     */
    public static class CsvReader
    {
        public static String BASE_DATA_PATH = "Data";

        public static List<CsvMappingResult<CoinPrice>> readFile(String coinName)
        {
            CsvParserOptions csvParserOptions = new CsvParserOptions(true, ',');
            CoinPriceMapping csvMapper = new CoinPriceMapping();
            CsvParser<CoinPrice> csvParser = new CsvParser<CoinPrice>(csvParserOptions, csvMapper);
            String path = $@"{BASE_DATA_PATH}/{coinName}.csv";
            return csvParser
                .ReadFromFile(path, Encoding.ASCII)
                .ToList();
        }
    }
}