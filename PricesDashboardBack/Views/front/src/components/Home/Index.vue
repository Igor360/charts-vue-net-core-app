<template>
  <div class="content">

    <div class="container marketing">
      <!-- Three columns of text below the carousel -->
      <div class="row">
        <div class="col-lg-12 note note-danger shadow-lg">
          <h2 class="text-dark">Prices Chart</h2>
        </div><!-- /.col-lg-4 -->
      </div><!-- /.row -->


      <!-- START THE FEATURETTES -->

      <hr class="featurette-divider">

      <div class="row featurette">
        <div class="col-md-6">
          <div class="row">
            <div class="col-md-3">
              <h2 class="featurette-heading">Selected</h2>
            </div>
            <div class="col-md-5">
              <select name="pair" v-model="selectedPair"
                      class="m-1 custom-select custom-select-sm border-left-0 border-right-0 border-top-0">
                <option selected>btc/eth</option>
                <option v-for="option in pairs" v-bind:key="option">{{ option }}</option>
              </select>
            </div>
            <div class="col-md-1">
              <h2 class="featurette-heading">by</h2>
            </div>
            <div class="col-md-3">
              <select name="groupBy" v-model="groupBy"
                      class="m-1 custom-select custom-select-sm border-left-0 border-right-0 border-top-0">
                <option selected>month</option>
                <option v-bind:key="year">year</option>
                <option v-bind:key="week">week</option>
                <option v-bind:key="quarter">quarter</option>
              </select>
            </div>
          </div>
          <button class="btn btn-block btn-danger m-1" @click="renderChart()">Render</button>
        </div>
        <div class="col-md-6">
          <h2 class="featurette-heading">pair for your. <span class="text-muted">Chart</span> <h6 class="display-7 text-danger">{{ priceDescription }}</h6></h2>
          <line-chart :chart-data="dataCollection"></line-chart>
        </div>

      </div>

      <hr class="featurette-divider">
      <!-- /END THE FEATURETTES -->

    </div><!-- /.container -->
  </div>
</template>

<script>

import LineChart from './LineChart.js'
import ApiService from "@/services/api.service";

export default {
  name: "Index",
  components: {
    LineChart
  },
  data() {
    return {
      dataCollection: null,
      selectedPair: "btc/eth",
      pairs: ["btc/ltc", "btc/etc", "dash/ltc", "btc/xem", "eth/xem", "vtc/btc", "bch/btc", "dash/dcr", "eth/etc", "bch/xem", "zec/vtc", "xmr/pivx", "ltc/doge"],
      groupBy: "month",
      priceDescription : ""
    }
  },
  mounted() {
    this.fillData()
  },
  methods: {
    async renderChart() {
      let baseCoin = this.$data.selectedPair.split('/')[0];
      let relatedCoin = this.$data.selectedPair.split('/')[1];
      this.$data.priceDescription = `number of ${baseCoin} per ${relatedCoin} by ${this.$data.groupBy}`;
      let res = await ApiService.post("prices", "api",
          {
            "BaseCoin": baseCoin,
            "RelatedCoin": relatedCoin,
            "GroupBy": this.$data.groupBy
          }
      )
      console.log(res.data);
      this.fillChartData(Object.values(res.data), Object.keys(res.data));
    },
    fillChartData(prices, dates) {
      this.dataCollection = {
        labels: [...dates],
        datasets: [
          {
            label: 'Pair : ' + this.$data.selectedPair,
            backgroundColor: '#f87977',
            data: [...prices]
          }
        ]
      }
    }
  }
}
</script>

<style scoped>
.content {
  margin-top: 100px;
}

.content {
  color: #f87977 !important;
}

.footer > a {
  color: #ff6766 !important;
}
</style>