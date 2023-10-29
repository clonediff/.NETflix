import CommonLayout from '../../layouts/common-layout/common-layout'
import { useState, useEffect, useRef } from 'react'
import { HttpTransportType, HubConnectionBuilder } from '@microsoft/signalr'
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
        axiosInstance.get('api/userchat/getall')
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
        <CommonLayout>
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
        </CommonLayout>
    )
}

const Message = ({ senderName, message, date, belongsToSender }) => {

    return (
        <div className='message-wrapper' style={{ flexDirection: belongsToSender ? 'row-reverse' : 'row' }}>
            <div className='message' style={{ backgroundColor: belongsToSender ? 'var(--search-bg-color)' : 'var(--main-bg-color)' }}>
                <div><strong>{ senderName }</strong></div>    
                { message }
                <div className='message-time'>
                    {
                        new Date(date).toLocaleString()
                    }
                </div>
            </div>
        </div>
    )
}

export default ChatPage