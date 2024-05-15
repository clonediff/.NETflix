import { useState } from 'react'
import { axiosInstance } from '../../clients'
import { Button, Form, Input, Modal } from 'antd'

const SettingsModal = ({ openSettings, hideSettingsModal, subscription, onChange }) => {

    const [message, setMessage] = useState(null)
    const [form] = Form.useForm()

    const submit = (values) => {
        axiosInstance.put('api/subscription/update', { id: subscription.id, ...values })
            .then(_ => setMessage(
                <div style={{ color: 'green' }}>подписка успешно обновлена</div>
            ))
            .catch(_ => setMessage(
                <div style={{ color: 'red' }}>не удалось обновить подписку</div>
            ))
    }

    const handleModalClose = () => {
        if (message) {
            setMessage(null)
            onChange()
        }
    }

    return (
        <Modal 
            open={ openSettings } 
            afterClose={ handleModalClose }
            onCancel={ hideSettingsModal } 
            closable={ false }
            zIndex={ 10001 }
            footer={
                <Button onClick={ form.submit } type='primary'>Изменить</Button>
            }>
            <Form form={ form } onFinish={ submit }>
                <Form.Item 
                    label='название' 
                    name='name' 
                    initialValue={ subscription.name }
                    rules={[
                        {
                            required: true,
                            message: 'введите название'
                        }
                    ]}>
                    <Input />
                </Form.Item>
                <Form.Item 
                    label='стоимость' 
                    name='cost' 
                    initialValue={ subscription.cost }
                    rules={[
                        {
                            required: true,
                            message: 'введите стоимость'
                        }
                    ]}>
                    <Input addonAfter={ <div>в рублях</div> } />
                </Form.Item>
                <Form.Item label='срок' name='periodInDays' initialValue={ subscription.periodInDays }>
                    <Input placeholder='пустой ввод — бессрочная подписка' addonAfter={ <div>количество дней</div> } />
                </Form.Item>
                <Form.Item hidden noStyle>
                    <Button htmlType='submit'></Button>
                </Form.Item>
            </Form>
            { message }
        </Modal>
    )
}

export default SettingsModal