import Vue from 'vue'
import axios from 'axios'

axios.defaults.baseURL = 'http://hiringdevwebapi-test.sa-east-1.elasticbeanstalk.com/'
axios.defaults.headers.common['Content-Type'] = 'application/json'

Vue.use({
    install(Vue){
        Vue.prototype.$http = axios
    }
})