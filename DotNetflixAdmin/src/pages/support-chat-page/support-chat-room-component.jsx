import { useEffect, useRef, useState } from 'react'
import { Button, Form, Input, Upload } from 'antd'
import { UploadOutlined } from '@ant-design/icons'
import { axiosInstance } from '../../axiosInstance'
import CustomSpin from '../../custom-spin/custom-spin'
import './support-chat-room-component.css'

const SupportChatRoomComponent = ({ roomId, connection, onLoad, updateLatestMessage }) => {
    
    const [isLoading, setIsLoading] = useState(true)
    const [messages, setMessages] = useState([])
    const [files, setFiles] = useState([])
    const [form] = Form.useForm()
    const messagesEnd = useRef(null)
    const filesEnd = useRef(null)

    useEffect(() => {
        if (connection) {
            connection.on('ReceiveAsync', (message) => { 
                updateLatestMessage(roomId, message.senderName, message.message)
                setMessages(prevState => [ ...prevState, message ])
            })
        }
        onLoad(roomId)
        loadHistory()
        setIsLoading(false)
        markMessagesAsRead()
    }, [roomId])
    
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
        console.log(values)
        if (values.message === '') {
            return
        }
        form.setFieldValue('message', undefined)
        updateLatestMessage(roomId, 'Администратор', values.message)
        connection.invoke('SendAsync', {
            message: values.message,
            roomId: roomId
        })
    }
    
    const sendFiles = () => {        
        console.log(files)
        if (files.length === 0) {
            return
        }
        const formData = new FormData()
        files.forEach(f => {
            formData.append('files', f)
        })
        axiosInstance.post(`https://localhost:7289/api/support-chat/uploadFile?roomId=${roomId}`, formData)
            .then(() => {
                setFiles([])
            })
            .catch(e => console.log(e))
    }

    const uploadProps = {
        multiple: true,
        listType: 'picture',
        beforeUpload: (file) => {
            setFiles([ ...files, file ])
            return false
        },
        onRemove: (file) => {
            const index = files.indexOf(file)
            files.splice(index, 1)
            setFiles([ ...files ])
        },
        onChange: (file) => {
            if (file.status !== 'removed' && file.status !== 'error' && filesEnd) {
                filesEnd.current?.scrollIntoView({ behavior: 'smooth' })
            }
        },
        itemRender: (node) => <div style={{ marginBottom: 8 }}>{ node }</div>,
        fileList: files
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
                    <Form form={ form } onFinish={ sendForm } layout='horizontal'>
                        <Form.Item noStyle>
                            <Button 
                                className='upload-button'
                                onClick={ sendFiles }>
                                Отправить
                            </Button>
                        </Form.Item>
                        <Form.Item
                            name='message' 
                            initialValue=''
                            noStyle>
                            <Input className='message-input margin-left' placeholder='введите сообщение' />
                        </Form.Item>
                        <Upload { ...uploadProps }>
                            <Button
                                disabled={ files.length >= 10 }
                                className='upload-button margin-left'
                                icon={ <UploadOutlined /> }>
                            </Button>
                        </Upload>
                        <div ref={ filesEnd }></div>
                    </Form>
                </>
                :
                <CustomSpin />
            }
        </div>
    )
}

const Message = ({ senderName, message, date, belongsToSender }) => {

    return (
        <div className='message-wrapper' style={{ flexDirection: belongsToSender ? 'row-reverse' : 'row' }}>
            <div className='message' style={{ backgroundColor: belongsToSender ? 'var(--sidebarBgColor)' : 'var(--headerBgColor)' }}>
                <div><strong>{ senderName }</strong></div>    
                    {
                        typeof message === 'string'
                            ? <div>{ message }</div>
                            : <img width={ '100%' } src={ `${message.header}${message.bytes}` } />
                    }
                <div>
                    {
                        new Date(date).toLocaleString()
                    }
                </div>
            </div>
        </div>
    )
}

export default SupportChatRoomComponent