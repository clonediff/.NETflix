import { Button, Form, Input, Modal } from 'antd'
import { axiosInstance } from '../../axiosInstance'
import '../../data-layout/form-styles.css'

const AddSubscriptionPage = () => {

    const [modal, modalHolder] = Modal.useModal()

    const sendForm = (values) => {
        axiosInstance.post('api/subscription/add', values)
            .then(_ => {
                modal.success({
                    title: 'Успешно добавлена новая подписка. Перейдите в раздел подписок, чтобы её активировать',
                    zIndex: 10001
                })
            })
            .catch(_ => {
                modal.error({
                    title: 'Не удалось добавить подписку',
                    zIndex: 10001
                })
            })
    }

    return (
        <Form className='add-form' onFinish={ sendForm }>
            { modalHolder }
            <Form.Item 
                name='name' 
                label='Название'
                className='form-item'
                rules={[
                    {
                        required: true,
                        message: 'введите название'
                    }
                ]}>
                <Input />
            </Form.Item>
            <Form.Item 
                name='cost' 
                label='Стоимость'
                className='form-item'
                rules={[
                    {
                        required: true,
                        message: 'введите стоимость'
                    }
                ]}>
                <Input addonAfter={ <div>в рублях</div> } />
            </Form.Item>
            <Form.Item 
                name='periodInDays' 
                label='Срок'
                className='form-item'>
                <Input placeholder='ничего не вводите, если подписка бессрочна' addonAfter={ <div>количество дней</div> } />
            </Form.Item>
            <Form.Item>
                <Button htmlType='submit' className='form-item'>Добавить</Button>
            </Form.Item>
        </Form>
    )
}

export default AddSubscriptionPage