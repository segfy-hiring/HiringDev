import axios from 'axios';

class HttpClientService {
  public client;

  constructor() {
    this.client = axios.create({
      baseURL: process.env.REACT_APP_API_URL,
    });
  }
}

export default new HttpClientService();
