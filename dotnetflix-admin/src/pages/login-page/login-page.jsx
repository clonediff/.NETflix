import { Button, Form, Input } from 'antd'
import './login-page.css'

const LoginPage = () => {
    return (
        <div className='login-form-container'>
            <Form 
                labelCol={{
                    span: 8
                }}
                wrapperCol={{
                    span: 16
                }}>
                <Form.Item 
                    label='Логин' 
                    name='login'
                    rules={[
                        {
                            required: true,
                            message: 'введите логин'
                        }
                    ]}>
                    <Input />
                </Form.Item>
                <Form.Item 
                    label='Пароль' 
                    name='password'
                    rules={[
                        {
                            required: true,
                            message: 'введите пароль'
                        }
                    ]}>
                    <Input.Password />
                </Form.Item>
                <Form.Item
                    wrapperCol={{
                        offset: 8
                    }}>
                    <Button htmlType='submit'>Войти</Button>  
                </Form.Item>
            </Form>
        </div>
    )
}

export default LoginPage