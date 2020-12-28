import Vue from 'vue'
import App from './App.vue'
import ApiService from "@/services/api.service";
import router from './router';

Vue.config.productionTip = false
ApiService.init();

router.beforeEach((to, from, next) => {
    const nearestWithTitle = to.matched.slice().reverse().find(r => r.meta && r.meta.title);
    if (nearestWithTitle) document.title = nearestWithTitle.meta.title;
    next();
});

new Vue({
    router,
    render: h => h(App),
}).$mount('#app')
