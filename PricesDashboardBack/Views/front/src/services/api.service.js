import {API_URL} from "@/configs";
import VueAxios from "vue-axios";
import Axios from "axios";
import Vue from "vue";

const ApiService = {
    init() {
        Vue.use(VueAxios, Axios);
        Vue.axios.defaults.baseURL = API_URL;
    },
    query(resource, params) {
        return Vue.axios.get(resource, params).catch(error => {
            throw  new Error(`Api service error: ${error}`);
        });
    },
    get: function (resource, slug = "") {
        return Vue.axios.get(`${slug}/${resource}`).catch(error => {
            throw new Error(`Api service error: ${error}`);
        });
    },
    post(resource, slug = "", param) {
        return Vue.axios.post(`${slug}/${resource}`, param);
    },
    update(resource, slug = "", param) {
        return Vue.axios.put(`${slug}/${resource}`, param);
    },
    put(resource, slug = "", param) {
        return Vue.axios.put(`${slug}/${resource}`, param);
    },
    delete(resource, slug = "") {
        return Vue.axios.delete(`${slug}/${resource}`).catch(error => {
            throw new Error(`Api service error : ${error}`);
        });
    }
};

export default ApiService;