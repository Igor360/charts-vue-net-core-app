<template>
  <header>
    <nav class="navbar navbar-expand-md navbar-light fixed-top bg-light">
      <div class="container">
        <router-link class="navbar-brand font-weight-bold" :to="{ path : '/'}">Charts | <span
            class="text-danger">Now</span></router-link>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarCollapse"
                aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarCollapse">
          <ul class="navbar-nav mr-auto">

            <router-link
                to="/#"
                v-slot="{ href, isActive }"
            >
              <li :class="['nav-item', isActive && 'active']">
                <a class="nav-link" :href="href"><i class="material-icons md-48">send</i>
                </a>
              </li>
            </router-link>
          </ul>
        </div>
      </div>
    </nav>
  </header>
</template>

<script>
export default {
  name: "Header"
}
</script>

<style scoped>
.navbar-nav {
  margin-top: 8px;
  margin-left: -20px;
}
</style>