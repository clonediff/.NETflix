import { Button, Form, Modal, Select, Space } from 'antd'
import { useState } from 'react'
import { axiosInstance } from '../../axiosInstance'
import '../../data-layout/buttons-styles.css'
import '../../data-layout/data-layout.css'
import '../../data-layout/border-styles.css'
import './users-page.css'

const User = ({ roles, user }) => {

    const [isBanned, setIsBanned] = useState(false)
    const [bannedUntill, setBannedUntill] = useState('')
    const [modal, modalHolder] = Modal.useModal()

    const onRoleUpdating = (values) => {
        axiosInstance.put('api/user/setrole', { ...values, userId: user.id })
            .then(response => {
                modal.success({
                    title: 'успешно обновлены данные для пользователя ' + user.name,
                    zIndex: 10001
                })
            })
            .catch(error => {
                modal.error({
                    title: 'не удалось обновить данные для пользователя ' + user.name,
                    zIndex: 10001
                })
            })
    }

    const onBanning = (values) => {
        axiosInstance.put('api/user/banuser', { ...values, userId: user.id })
            .then(({ data }) => {
                setBannedUntill(data)
                setIsBanned(true)
                modal.success({
                    title: 'успешно обновлены данные для пользователя ' + user.name,
                    zIndex: 10001
                })
            })
            .catch(error => {
                modal.error({
                    title: 'не удалось обновить данные для пользователя ' + user.name,
                    zIndex: 10001
                })
            })
    } 

    const onUnbanning = () => {
        axiosInstance.put('api/user/unbanuser',
            JSON.stringify(user.id), {
                headers: {
                    'Content-Type': 'application/json'
                }
            })
            .then(_ => {
                setIsBanned(false)
                modal.success({
                    title: 'успешно обновлены данные для пользователя ' + user.name,
                    zIndex: 10001
                })
            })
            .catch(error => {
                modal.error({
                    title: 'не удалось обновить данные для пользователя ' + user.name,
                    zIndex: 10001
                })
            })
    }

    return (
        <div className='list-item'>
            { modalHolder }
            <span>{ user.name }</span>
            <div className='list-item-options'>
                <Form disabled={ isBanned } onFinish={ onRoleUpdating }>
                    <Space.Compact>
                        <Form.Item 
                            name='roleid' 
                            initialValue={ user.roleId }
                            noStyle>
                            <Select options={ roles.map(r => ({ label: r.name, value: r.id })) } />
                        </Form.Item>
                        <Button htmlType='submit'>Обновить роль</Button>
                    </Space.Compact>
                </Form>
                {
                    isBanned 
                    ?
                    <Space.Compact>
                        <div className='ban-info left-border-radius'>Забанен до { bannedUntill }</div>
                        <button className='ban-button unban-color right-border-radius' onClick={ onUnbanning }>Разблокировать</button>
                    </Space.Compact>
                    :
                    <Form onFinish={ onBanning }>
                        <Space.Compact>
                            <Form.Item 
                                name='days'
                                initialValue={ 1 }
                                noStyle>
                                <Select
                                    options={[
                                        { label: '1 день', value: 1 },
                                        { label: '7 дней', value: 7 },
                                        { label: '30 дней', value: 30 },
                                        { label: '180 дней', value: 180 }
                                    ]} />
                            </Form.Item>
                            <button type='submit' className='ban-button ban-color right-border-radius'>Заблокировать</button>
                        </Space.Compact>
                    </Form>
                }
            </div>
        </div>
    )
}

export default User