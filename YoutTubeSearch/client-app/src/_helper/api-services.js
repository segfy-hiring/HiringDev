import axios from "axios";

const http = axios.create({
  baseURL: process.env.VUE_APP_ROOT_API,
});

export default http;