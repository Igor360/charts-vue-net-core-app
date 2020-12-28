import Vue from "vue";
import VueRouter from "vue-router";

Vue.use(VueRouter);

export default new VueRouter({
    routes: [
        {
            path: "/",
            component: () => import("@/components/Home/Index"),
            meta: {
                title: 'Home',
                guest: true
            }
        }
    ]
});