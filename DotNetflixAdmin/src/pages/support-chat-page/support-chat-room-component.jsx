import { useEffect, useRef, useState } from 'react'
import { Button, Form, Input, Upload, Image } from 'antd'
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
            connection.off('ReceiveAsync')
            connection.on('ReceiveAsync', (message) => {
                updateLatestMessage(message.roomId, message.senderName, message.message)
                if (message.roomId === roomId)
                    setMessages(prevState => [ ...prevState, message ])
            })
        }
        onLoad(roomId)
        loadHistory()
        markMessagesAsRead()
    }, [roomId])

    useEffect(() => {    
        if (messagesEnd) {
            messagesEnd.current?.scrollIntoView({ behavior: 'smooth' })
        }
        markMessagesAsRead()
    }, [messages])
    
    const loadHistory = () => {
        axiosInstance.get(`api/support-chat/history?roomId=${roomId}`)
        .then(({ data }) => {
                setMessages(data)
                setIsLoading(false)
            })
    }

    const markMessagesAsRead = () => {
        axiosInstance.patch(`api/support-chat/markasread?roomId=${roomId}`)
    }

    const sendForm = (values) => {
        if (values.message === '') {
            return
        }
        if (connection.state !== "Connected")
            connection.start()
        form.setFieldValue('message', '')
        connection.invoke('SendMessageAsync', {
            message: values.message,
            roomId: roomId
        })
    }
    
    const sendFiles = () => {     
        if (files.length === 0) {
            return
        }
        files.forEach(f => {
            sendFile(f)
        })
        setFiles([])
    }

    const sendFile = (file) => {
        const reader = new FileReader()
        reader.onloadend = () => {
            const bytes = new Uint8Array(reader.result)
            connection.invoke('SendFilesAsync', {
                message: Array.from(bytes),
                roomId: roomId
            }, file.type)
        }
        reader.readAsArrayBuffer(file)
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
                                    message={ m } />
                            ))
                        }
                        <div ref={ messagesEnd }></div>
                    </div>
                    <Form form={ form } onFinish={ sendForm } layout='horizontal'>
                        <Form.Item noStyle>
                            <Button 
                                className='upload-button'
                                onClick={ sendFiles }>
                                Отправить файл
                            </Button>
                        </Form.Item>
                        <Form.Item
                            name='message' 
                            initialValue=''
                            noStyle>
                            <Input className='message-input margin-left' placeholder='введите сообщение' autoFocus />
                        </Form.Item>
                        <Upload { ...uploadProps }>
                            <Button
                                disabled={ files.length >= 5 }
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

const Message = ({ message }) => {

    return (
        <div className='message-wrapper' style={{ flexDirection: message.belongsToSender ? 'row-reverse' : 'row' }}>
            <div className='message' style={{ backgroundColor: message.belongsToSender ? 'var(--sidebarBgColor)' : 'var(--headerBgColor)' }}>
                <div><strong>{ message.senderName }</strong></div>    
                    {
                        !message.content || message.messageType === 0
                            ? <div>{ message.content }</div>
                            : <Image width={ '100%' } src={ `${message.content.header}${message.content.bytes}` } />
                    }
                <div>
                    {
                        new Date(message.sendingDate).toLocaleString()
                    }
                </div>
            </div>
        </div>
    )
}

export default SupportChatRoomComponent