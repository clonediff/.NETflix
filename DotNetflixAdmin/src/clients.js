import axios from 'axios'
import {SupportChatServiceClient} from './Protos/support-chat_grpc_web_pb'

export const axiosInstance = axios.create({
    baseURL: 'https://localhost:7298',
    withCredentials: true
})

export const supportChatClient = new SupportChatServiceClient('http://localhost:8080');
