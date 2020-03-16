import '@babel/polyfill'
import Vue from 'vue'
import App from './App.vue'
import { FontAwesomeIcon } from './plugins/icons'

import './plugins/bootstrap-vue'
import './plugins/axios'

Vue.component('icon', FontAwesomeIcon)

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')
