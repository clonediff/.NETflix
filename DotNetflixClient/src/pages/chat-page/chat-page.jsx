import { useState, useEffect, useRef } from 'react'
import { HttpTransportType, HubConnectionBuilder } from '@microsoft/signalr'
import BurgerMenu from '../main-page/burger-menu/burger-menu'
import BurgerPanel from '../main-page/burger-panel/burger-panel'
import Header from '../main-page/header/header'
import { Form, Input } from 'antd'
import { axiosInstance } from '../../AxiosInstance'
import './chat-page.css'
import '../../constants.css'

const ChatPage = () => {

    const [connection, setConnection] = useState(null)
    const [messages, setMessages] = useState([])
    const [form] = Form.useForm()
    const messagesEnd = useRef(null)

    useEffect(() => {
        if (!connection) {
            const newConnection = new HubConnectionBuilder()
                .withUrl('https://localhost:7289/chatHub', {
                    skipNegotiation: true,
                    transport: HttpTransportType.WebSockets
                })
                .build()
            setConnection(newConnection)
        }
        axiosInstance.get('api/message/getall')
            .then(({ data }) => {
                setMessages(data)
            })
    }, [])

    useEffect(() => {
        if (connection) {
            connection.start()
            connection.on('ReceiveAsync', (message) => {
                setMessages(prevState => [ ...prevState, message ])
            })
        }
    }, [connection])
    
    useEffect(() => {        
        if (messagesEnd) {
            messagesEnd.current.scrollIntoView({ behavior: 'smooth' })
        }
    }, [messages])

    const sendForm = (values) => {
        form.setFieldValue('message', undefined)
        connection.invoke('SendAsync', values.message)
    }

    return (
        <>
            <BurgerMenu />
            <BurgerPanel />
            <Header />
            <div className='chat-container'>
                <div className='chat'>
                    <div className='message-list'>
                        {
                            messages.map((m, i) => (
                                <Message 
                                    key={ i } 
                                    senderName={ m.senderName } 
                                    message={ m.message } 
                                    date={ m.sendingDate }
                                    belongsToSender={ m.belongsToSender } />
                            ))
                        }
                        <div ref={ messagesEnd }></div>
                    </div>
                    <Form form={ form } onFinish={ sendForm } className='message-enter'>
                        <Form.Item 
                            name='message' 
                            initialValue=''
                            rules={[
                                {
                                    required: true,
                                    message: 'введите сообщение'
                                }
                            ]} 
                            noStyle>
                            <Input className='message-input' placeholder='введите сообщение' autoComplete='off' />
                        </Form.Item>
                        <Form.Item noStyle>
                            <button type='submit' hidden />
                        </Form.Item>
                    </Form>
                </div>
            </div>
        </>
    )
}

const Message = ({ senderName, message, date, belongsToSender }) => {

    const getTime = (date) => {
        let hours = date.getHours()
        if (hours < 10) {
            hours = '0' + hours
        }
        let minutes = date.getMinutes()
        if (minutes < 10) {
            minutes = '0' + minutes
        }
        return `${hours}:${minutes}`
    }

    return (
        <div className='message-wrapper' style={{ flexDirection: belongsToSender ? 'row-reverse' : 'row' }}>
            <div className='message' style={{ backgroundColor: belongsToSender ? 'var(--search-bg-color)' : 'var(--main-bg-color)' }}>
                <div><strong>{ senderName }</strong></div>    
                { message }
                <div className='message-time'>
                    {
                        getTime(new Date(date))
                    }
                </div>
            </div>
        </div>
    )
}

export default ChatPage