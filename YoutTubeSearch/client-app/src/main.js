import Vue from "vue";
import { store } from "./_store";
import App from "./App.vue";
import router from "./router";
import VueLoading from "vuejs-loading-plugin";
import BootstrapVue from "bootstrap-vue";
import VueMask from "vue-the-mask";
import { library } from "@fortawesome/fontawesome-svg-core";
import { fab } from "@fortawesome/free-brands-svg-icons";
import { fas } from "@fortawesome/free-solid-svg-icons";
import { far } from "@fortawesome/free-regular-svg-icons";
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import "bootstrap/dist/css/bootstrap.css";
import "bootstrap-vue/dist/bootstrap-vue.css";
import "./assets/style/style.scss";
import VueSweetalert2 from "vue-sweetalert2";
import VueClipboard from "vue-clipboard2";
import Snotify, { SnotifyPosition, SnotifyStyle } from "vue-snotify";
import iconSucessNotification from "@/assets/icons/icon-success-notification.svg";
import iconErrorNotification from "@/assets/icons/icon-error-notification.svg";
import Vuelidate from "vuelidate";
import VueFilterDateFormat from "vue-filter-date-format";
import Vue2Filters from "vue2-filters";

Vue.use(BootstrapVue);
Vue.use(VueMask);
library.add(fas);
library.add(fab);
library.add(far);
Vue.component("font-awesome-icon", FontAwesomeIcon);
Vue.use(VueSweetalert2);
Vue.use(VueClipboard);
Vue.use(Vuelidate);
Vue.use(VueFilterDateFormat);
Vue.use(Vue2Filters);

// import {InlineSvgPlugin} from 'vue-inline1-svg';
// Vue.use(InlineSvgPlugin);
Vue.config.lang = "ingles";

const options = {
  toast: {
    position: SnotifyPosition.leftTop,
    pauseOnHover: true,
    showProgressBar: false,
    timeout: 5000,
    closeOnClick: false,
    preventDuplicates: true,
  },
  type: {
    [SnotifyStyle.success]: {
      icon: iconSucessNotification,
    },
    [SnotifyStyle.error]: {
      icon: iconErrorNotification,
    },
  },
};

Vue.use(Snotify, options);

Vue.use(VueLoading, {
  dark: true, // default false
  text: " ", // default 'Loading'
  loading: false, // default false
  background: "rgb(255,255,255)", // set custom background
  classes: ["myclass"], // array, object or string
});

Vue.config.productionTip = false;

new Vue({
  router,
  store,
  render: (h) => h(App),
}).$mount("#app");
