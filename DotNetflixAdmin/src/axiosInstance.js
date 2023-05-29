import axios from 'axios'

export const axiosInstance = axios.create({
    baseURL: 'https://localhost:7298',
    withCredentials: true
})