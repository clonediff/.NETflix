import { useEffect, useRef, useState } from 'react'
import { Form, Input } from 'antd'
import { axiosInstance } from '../../axiosInstance'
import CustomSpin from '../../custom-spin/custom-spin'
import './support-chat-room-component.css'

const SupportChatRoomComponent = ({ prevRoomId, roomId, connection, onLoad, updateLatestMessage }) => {
    
    const [isLoading, setIsLoading] = useState(true)
    const [messages, setMessages] = useState([])
    const [form] = Form.useForm()
    const messagesEnd = useRef(null)

    useEffect(() => {
        if (connection) {
            connection.on('ReceiveAsync', (message) => {
                updateLatestMessage(roomId, message.senderName, message.message)
                setMessages(prevState => [ ...prevState, message ])
            })
        }
        onLoad(roomId)
        loadHistory()
        connectToRoom()
        setIsLoading(false)
        markMessagesAsRead()
    }, [roomId])
    
    useEffect(() => {    
        if (messagesEnd) {
            messagesEnd.current?.scrollIntoView({ behavior: 'smooth' })
        }
        markMessagesAsRead()
    }, [messages])

    const connectToRoom = () => {
        if (connection.state !== "Connected")
            connection.start()
        connection.invoke('ConnectToGroupAsync', {
            prevRoomId: prevRoomId,
            roomId: roomId
        })
    }
    
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
        if (connection.state !== "Connected")
            connection.start()
        form.setFieldValue('message', undefined)
        updateLatestMessage(roomId, 'Администратор', values.message)
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
                            <Input className='message-input' placeholder='введите сообщение' autoFocus/>
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