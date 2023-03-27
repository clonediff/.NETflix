import axios from "axios";
export const axiosInstance = axios.create({
    baseURL: 'https://localhost:7289',
    withCredentials: true
});