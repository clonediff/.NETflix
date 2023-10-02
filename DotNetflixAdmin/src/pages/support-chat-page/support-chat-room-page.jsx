import { Form, Input } from "antd"
import './support-chat-room-page.css'

export const SupportChatRoomPage = () => {
    
    const [form] = Form.useForm()

    const sendForm = (values) => {
        form.setFieldValue('message', undefined)
        console.log(values);
    }

    return (
        <div className='chat-container'>
            <div className='message-list'>
                <Message belongsToSender={ true } />
                <Message belongsToSender={ true } />
                <Message belongsToSender={ false } />
                <Message belongsToSender={ true } />
                <Message belongsToSender={ false } />
                <Message belongsToSender={ true } />
                <Message belongsToSender={ false } />
                <Message belongsToSender={ false } />
                <Message belongsToSender={ false } />
            </div>
            <Form form={ form } onFinish={ sendForm } >
                <Form.Item
                    name='message' 
                    initialValue=''
                    rules={[
                        {
                            required: true,
                            message: 'введите сообщение'
                        }
                    ]}>
                    <Input placeholder='введите сообщение' />
                </Form.Item>
                <Form.Item noStyle>
                    <button type='submit' hidden />
                </Form.Item>
            </Form>
        </div>
    )
}

const Message = ({ belongsToSender }) => {
    return (
        <div className='message-wrapper' style={{ flexDirection: belongsToSender ? 'row-reverse' : 'row' }}>
            <div className='message' style={{ backgroundColor: belongsToSender ? 'var(--sidebarBgColor)' : 'var(--headerBgColor)' }}>
                <div><strong>User 1</strong></div>    
                <div>How to fix this problem</div>
                <div>19:30</div>
            </div>
        </div>
    )
}