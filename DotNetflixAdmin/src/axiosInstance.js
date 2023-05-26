import axios from 'axios'

export const axiosInstance = axios.create({
    baseURL: 'http://localhost:7298',
    withCredentials: true
})