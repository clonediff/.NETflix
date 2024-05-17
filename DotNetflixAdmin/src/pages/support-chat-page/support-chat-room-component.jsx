import {useEffect, useRef, useState} from 'react'
import {Button, Form, Input, Upload, Image} from 'antd'
import {UploadOutlined} from '@ant-design/icons'
import {axiosInstance, supportChatClient} from '../../clients'
import CustomSpin from '../../custom-spin/custom-spin'
import './support-chat-room-component.css'
import {ReceiveRequest, MessageType, TextMessageRequest, FileMessageRequest} from "../../Protos/support-chat_pb";
import { getRandomString } from './random-string-generator'

const SupportChatRoomComponent = ({roomId, connection, onLoad, updateLatestMessage}) => {

    const [isLoading, setIsLoading] = useState(true)
    const [messages, setMessages] = useState([])
    const [files, setFiles] = useState([])
    const [form] = Form.useForm()
    const messagesEnd = useRef(null)
    const filesEnd = useRef(null)
    let stream = null;

    useEffect(() => {
        if (connection) {
            connection.off('ReceiveAsync')
            connection.on('ReceiveAsync', (message) => {
                updateLatestMessage(message.roomId, message.senderName, message.content, () => message.messageType === MessageType.TEXT)
                if (message.roomId === roomId)
                    setMessages(prevState => 
                        prevState.some(x => JSON.stringify(x.content) === JSON.stringify(message.content)
                            && message.sendingDate.toLocaleString() === x.sendingDate.toLocaleString()) 
                            ? prevState 
                            : [...prevState, message])
            })
            stream?.cancel();
            const receiveRequest = new ReceiveRequest();
            receiveRequest.setRoomid(roomId);
            stream = supportChatClient.receiveMessage(receiveRequest);
            stream.on("data", (message) => {
                let content =
                    (message.getMessagetype() === MessageType.TEXT 
                        ? (x) => x 
                        : (x) => JSON.parse(x))(new TextDecoder('utf-8').decode(message.getContent().getValue()));
                    
                let newMessage = {
                    belongsToSender: message.getBelongstosender(),
                    content: content,
                    message: content,
                    messageType: message.getMessagetype(),
                    roomId: message.getRoomid(),
                    senderName: message.getSendername(),
                    sendingDate: new Date(message.getSendingdate().getSeconds() * 1000)
                }
                console.log(newMessage)
                setMessages(prevState => {
                    if (prevState.some(x => JSON.stringify(x.content) === JSON.stringify(newMessage.content)
                        && newMessage.sendingDate.toLocaleString() === x.sendingDate.toLocaleString())) {
                        console.log('duplicate found')
                        return prevState
                    }
                    return [...prevState, newMessage]
                })
            })
        }
        onLoad(roomId)
        loadHistory()
        markMessagesAsRead()
    }, [roomId])

    useEffect(() => {
        if (messagesEnd) {
            messagesEnd.current?.scrollIntoView({behavior: 'smooth'})
        }
        markMessagesAsRead()
    }, [messages])
    
    const loadHistory = () => {
        axiosInstance.get(`api/support-chat/history?roomId=${roomId}`)
            .then(({data}) => {
                setMessages(data)
                setIsLoading(false)
            })
    }

    const markMessagesAsRead = () => {
        axiosInstance.patch(`api/support-chat/markasread?roomId=${roomId}`)
    }

    const sendForm = (values) => {
        const uniqueKey = getRandomString()
        if (values.message === '') {
            return
        }
        if (connection.state !== "Connected")
            connection.start()
        connection.invoke('SendMessageAsync', {
            message: values.message,
            roomId: roomId
        }, uniqueKey)
        const message = new TextMessageRequest();
        message.setContent(values.message);
        message.setRoomid(roomId);
        message.setUniquekey(uniqueKey)
        supportChatClient.sendTextMessage(message, null, (_, __) => console.log('message sent'));
        form.setFieldValue('message', '')
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
        const uniqueKey = getRandomString()
        reader.onloadend = () => {
            const bytes = new Uint8Array(reader.result)
            connection.invoke('SendFilesAsync', {
                message: Array.from(bytes),
                roomId: roomId
            }, file.type, uniqueKey)
            const message = new FileMessageRequest();
            message.setContent(bytes);
            message.setRoomid(roomId);
            message.setContenttype(file.type);
            message.setUniquekey(uniqueKey);
        }
        reader.readAsArrayBuffer(file)
    }

    const uploadProps = {
        multiple: true,
        listType: 'picture',
        beforeUpload: (file) => {
            setFiles([...files, file])
            return false
        },
        onRemove: (file) => {
            const index = files.indexOf(file)
            files.splice(index, 1)
            setFiles([...files])
        },
        onChange: (file) => {
            if (file.status !== 'removed' && file.status !== 'error' && filesEnd) {
                filesEnd.current?.scrollIntoView({behavior: 'smooth'})
            }
        },
        itemRender: (node) => <div style={{marginBottom: 8}}>{node}</div>,
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
                                        key={i}
                                        message={m}/>
                                ))
                            }
                            <div ref={messagesEnd}></div>
                        </div>
                        <Form form={form} onFinish={sendForm} layout='horizontal'>
                            <Form.Item noStyle>
                                <Button
                                    className='upload-button'
                                    onClick={sendFiles}>
                                    Отправить файл
                                </Button>
                            </Form.Item>
                            <Form.Item
                                name='message'
                                initialValue=''
                                noStyle>
                                <Input className='message-input margin-left' placeholder='введите сообщение' autoFocus/>
                            </Form.Item>
                            <Upload {...uploadProps}>
                                <Button
                                    disabled={files.length >= 5}
                                    className='upload-button margin-left'
                                    icon={<UploadOutlined/>}>
                                </Button>
                            </Upload>
                            <div ref={filesEnd}></div>
                        </Form>
                    </>
                    :
                    <CustomSpin/>
            }
        </div>
    )
}

const Message = ({message}) => {

    return (
        <div className='message-wrapper' style={{flexDirection: message.belongsToSender ? 'row-reverse' : 'row'}}>
            <div className='message'
                 style={{backgroundColor: message.belongsToSender ? 'var(--sidebarBgColor)' : 'var(--headerBgColor)'}}>
                <div><strong>{message.senderName}</strong></div>
                {
                    !message.content || message.messageType === MessageType.TEXT
                        ? <div>{message.content}</div>
                        : <Image width={'100%'} src={`${message.content.header}${message.content.bytes}`}/>
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