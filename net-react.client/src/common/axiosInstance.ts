import axios from 'axios';
const axiosInstance = axios.create({
    baseURL: 'http://localhost:5197/api',
});
export default axiosInstance;
