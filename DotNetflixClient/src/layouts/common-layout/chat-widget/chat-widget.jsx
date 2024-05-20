import { FileTextOutlined, UploadOutlined, SendOutlined } from '@ant-design/icons';
import { useState, useEffect, useRef } from 'react';
import { axiosInstance } from '../../../AxiosInstance'
import { HttpTransportType, HubConnectionBuilder } from '@microsoft/signalr'
import { Form, Input, FloatButton, Button, Image } from 'antd'
import './chat-widget.css'

const ChatWidget = () => {

    const [connection, setConnection] = useState(null);
    const [isVisible, setIsVisible] = useState(false);
    const [messages, setMessages] = useState([]);
    const [isStarted, setStarted] = useState(false);
    const [files, setFiles] = useState([])
    const [previews, setPreviews] = useState([])
    const [form] = Form.useForm();
    const isAuthenticated = localStorage.getItem('authenticated');
    const messagesEnd = useRef(null);
    const filesEnd = useRef(null)

    useEffect(() => {
        if (isVisible && !connection) {
            const newConnection = new HubConnectionBuilder()
                .withUrl('https://localhost:7289/supportChatHub', {
                    skipNegotiation: true,
                    transport: HttpTransportType.WebSockets
                })
                .build();
            setConnection(newConnection);
        }

    }, [isVisible])

    useEffect(() => {
        if(connection){
            connection.start();
            setStarted(true);
        }
    }, [connection]);

    useEffect(() => {
        if (isStarted) {
            connection.on('ReceiveAsync', (message) => {
                setMessages(prevState => [ ...prevState, message ]);
            });
            loadHistory();
        }
    }, [isStarted])

    useEffect(() => {
        if (messagesEnd) {
            messagesEnd.current?.scrollIntoView({ behavior: 'smooth' });
        }
    }, [messages])

    const loadHistory = () => {
        axiosInstance.get(`api/support-chat/history`)
            .then(({ data }) => {
                setMessages(data);
            });
    }

    const sendForm = (values) => {
        if (connection.state !== "Connected")
            connection.start()
        form.setFieldValue('message', undefined);
        connection.invoke('SendMessageAsync', {
            message: values.message,
            roomId: null
        }, null);
    }

    window.onclick = (event) => {
        let modal = document.getElementById("myModal");
        if(event.target === modal){
            setIsVisible(false);
        }
    };

    const sendFiles = () => {     
        if (files.length === 0) {
            return
        }
        files.forEach(f => {
            sendFile(f)
        })
        setFiles([])
        setPreviews([])
    }

    const sendFile = (file) => {
        const reader = new FileReader()
        reader.onloadend = () => {
            const bytes = new Uint8Array(reader.result)
            connection.invoke('SendFilesAsync', {
                message: Array.from(bytes),
                roomId: null
            }, file.type, null)
        }
        reader.readAsArrayBuffer(file)
    }

    const onFileInputChange = (event) => {
        if(event.target.files && event.target.files[0]){
            let inputFile = event.target.files[0];
            setFiles([...files, inputFile])
            let reader = new FileReader();
            
            let res
            reader.onload = function () {
                res = reader.result;
                let preview = {
                    id: `${inputFile.size}_${inputFile.name}`,
                    type: inputFile.type,
                    info: res,  
                    name: inputFile.name
                }
                setPreviews([...previews, preview]);
            }
            reader.readAsDataURL(inputFile);
        }
    }
        
    const onFileDelete = (event) => {
        let id = event.target.id;
        let fileName = event.target.dataset.filename;
        setPreviews(previews.filter(preview => preview.id !== id));
        setFiles(files.filter(file => file.name !== fileName));
    }

    const previewItem = (item, id, name) => {
        return <div key={id} className='file-preview'>
                    <span id={id} data-fileName={name} onClick={onFileDelete} className="delete-button">&times;</span>
                    {item}
            </div>;
    }

    const transformPreview = (preview) => {
        let reg = new RegExp('image');

        return reg.test(preview.type) ?
        previewItem(<Image className='image-preview' src={`${preview.info}`}/>, preview.id, preview.name) : 
        previewItem(<span>{`${preview.name}`}</span>, preview.id, preview.name);
    }

    return (<>{
        isAuthenticated 
        ? <>
                {!isVisible
                    ? <FloatButton
                        className="chat_button"
                        icon={<FileTextOutlined />}
                        description="Help"
                        shape="circle"
                        type="primary"
                        onClick={() => setIsVisible(true)}
                        style={{color: "rgb(0, 52, 94)"}}
                    />
                    : <></>}

            { isVisible 
            ? <div id="myModal" className="modal" style={{}}>
            <div className="modal-content">
                <div className="modal-header">
                    <span onClick={() => {setIsVisible(false)}} className="close">&times;</span>
                    <h2>Support Chat</h2>
                </div>
                <div className="modal-body" style={{ height: previews.length ? '60%' : '70%'}}>
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
                </div>
                <div className="modal-footer" style={{ height: previews.length ? '30%' : '20%'}}>    
                    <Form form={ form } onFinish={ sendForm } className='chat-form' layout='horizontal'>
                        <Form.Item
                        className='file-input'>
                            <input
                                type="file"
                                style={{ display: 'none' }}
                                id="contained-button-file"
                                multiple
                                onChange={onFileInputChange}
                            />
                            <label className='upload' htmlFor="contained-button-file">
                                <UploadOutlined />
                            </label>
                        </Form.Item>                         
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
                            <Input className='text-input' placeholder='введите сообщение' autoComplete='off' autoFocus />
                        </Form.Item>
                        <Button
                            onClick={ sendFiles }
                            disabled={ files.length >= 5 }
                            className='upload-button margin-left'
                            icon={ <SendOutlined /> }>
                        </Button>
                    </Form>
                    <div className='preview-list' style={{ height: previews.length ? '100%' : '0%'}}>
                        {
                            previews.map((preview) => transformPreview(preview))
                        }
                        <div ref={ filesEnd }></div>
                    </div>
                </div>
            </div>
        </div>
            : <></>}
        </>
        : <></>}
        </>);
}

const Message = ({ message }) => {

    return (
        <div className='message-wrapper' style={{ flexDirection: message.belongsToSender ? 'row-reverse' : 'row' }}>
            <div className='message' style={{ backgroundColor: message.belongsToSender ? 'var(--search-bg-color)' : 'var(--header-bg-color)' }}>
                <div><strong>{ message.senderName }</strong></div>    
                    {
                        message.messageType === 0
                            ? <div>{ message.content }</div>
                            : <Image src={ `${message.content.header}${message.content.bytes}` } />
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



export default ChatWidget
