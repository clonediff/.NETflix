import { FileTextOutlined } from '@ant-design/icons';
import { useState, useEffect, useRef } from 'react';
import { axiosInstance } from '../../../AxiosInstance'
import { HttpTransportType, HubConnectionBuilder } from '@microsoft/signalr'
import { Form, Input, FloatButton } from 'antd'
import './chat-widget.css'

const ChatWidget = () => {

    const [connection, setConnection] = useState(null);
    const [isVisible, setIsVisible] = useState(false);
    const [messages, setMessages] = useState([]);
    const [isStarted, setStarted] = useState(false);
    const [form] = Form.useForm();
    const isAuthenticated = localStorage.getItem('authenticated');
    const messagesEnd = useRef(null);

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
        }
        loadHistory();
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
        form.setFieldValue('message', undefined);
        connection.invoke('SendAsync', {
            message: values.message,
            roomId: null
        });
    }

    window.onclick = (event) => {
        let modal = document.getElementById("myModal");
        if(event.target === modal){
            setIsVisible(false);
        }
    };

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
                <div className="modal-body">
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
                </div>
                <div className="modal-footer">
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
        </div>
            : <></>}
            
        </>
        
        : <></>}
        </>);
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



export default ChatWidget