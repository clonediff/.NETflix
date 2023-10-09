import { useEffect, useRef, useState } from 'react'
import { Form, Input } from 'antd'
import { axiosInstance } from '../../axiosInstance'
import CustomSpin from '../../custom-spin/custom-spin'
import './support-chat-room-component.css'

const SupportChatRoomComponent = ({ roomId, connection, onLoad, onMessageSent }) => {
    
    const [isLoading, setIsLoading] = useState(true)
    const [messages, setMessages] = useState([])
    const [form] = Form.useForm()
    const messagesEnd = useRef(null)

    useEffect(() => {
        if (connection) {
            connection.on('ReceiveAsync', (message) => { 
                setMessages(prevState => [ ...prevState, message ])
            })
        }
        onLoad(roomId)
        loadHistory()
        setIsLoading(false)
        markMessagesAsRead()
    }, [])
    
    useEffect(() => {    
        if (messagesEnd) {
            messagesEnd.current?.scrollIntoView({ behavior: 'smooth' })
        }
    }, [messages])

    const loadHistory = () => {
        axiosInstance.get(`api/support-chat/history?roomId=${roomId}`)
            .then(({ data }) => {
                setMessages(data)
            })
    }

    const markMessagesAsRead = () => {
        axiosInstance.patch(`api/support-chat/markasread?roomId=${roomId}`)
    }

    const sendForm = (values) => {
        form.setFieldValue('message', undefined)
        onMessageSent(roomId, 'Администратор', values.message)
        connection.invoke('SendAsync', {
            message: values.message,
            roomId: roomId
        })
    }

    return (
        <div className='room'>
            {
                !isLoading
                ?
                <>
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
                    <Form form={ form } onFinish={ sendForm } >
                        <Form.Item
                            name='message' 
                            initialValue=''
                            noStyle
                            rules={[
                                {
                                    required: true,
                                    message: 'введите сообщение'
                                }
                            ]}>
                            <Input className='message-input' placeholder='введите сообщение' />
                        </Form.Item>
                        <Form.Item noStyle>
                            <button type='submit' hidden />
                        </Form.Item>
                    </Form>
                </>
                :
                <CustomSpin />
            }
        </div>
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
            <div className='message' style={{ backgroundColor: belongsToSender ? 'var(--sidebarBgColor)' : 'var(--headerBgColor)' }}>
                <div><strong>{ senderName }</strong></div>    
                <div>{ message }</div>
                <div>
                    {
                        getTime(new Date(date))
                    }
                </div>
            </div>
        </div>
    )
}

export default SupportChatRoomComponent