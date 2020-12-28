<template>
  <main>
    <Header/>
    <router-view></router-view>
  </main>
</template>

<script>
import Header from "./Parts/Header";

export default {
  name: "Index",
  components: {
    Header
  }
}
</script>

<style scoped>
@import "https://fonts.googleapis.com/css2?family=Material+Icons";
@import url('https://fonts.googleapis.com/css?family=Nunito&display=swap');
@import url('https://fonts.googleapis.com/css?family=PT+Sans&display=swap');
@import url('https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/2.2.1/mdb.min.css');
</style>