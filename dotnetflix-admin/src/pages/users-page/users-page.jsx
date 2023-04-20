import { useState, useEffect } from 'react'
import { axiosInstance } from '../../axiosInstance'
import { Button, Form, Modal, Select, Space } from 'antd'
import DataLayout from '../../data-layout/data-layout'
import './users-page.css'

const UsersPage = () => {

    const [users, setUsers] = useState([])
    const [roles, setRoles] = useState([])
    const [isLoading, setIsLoading] = useState(true)
    const [page, setPage] = useState(1)   
    const [usersCount, setUsersCount] = useState(0)
    const [searchedUserName, setSearchedUserName] = useState(null)

    useEffect(() => {
        axiosInstance.get('api/user/getuserscount')
            .then(({ data }) => {
                setUsersCount(data)
            })
        axiosInstance.get('api/user/getroles')
            .then(({ data }) => {
                setRoles(data)
            })
    }, [])

    useEffect(() => {
        axiosInstance.get(`api/user/getusers?page=${page}`)
            .then(({ data }) => {
                setUsers(data)
                setIsLoading(false)
            })
    }, [page])

    useEffect(() => {
        if (searchedUserName) {
            axiosInstance.get(`api/user/getusers?page=1&searchedUserName=${encodeURIComponent(searchedUserName)}`)
                .then(({ data }) => {
                    setUsers(data)
                    setUsersCount(data.length)
                })
        }
    }, [searchedUserName])

    const onPageChanged = (page, _) => {
        setPage(page)
    }

    const onSearch = (values) => {
        setSearchedUserName(values.name)
    }

    return (
        <DataLayout
            dataCount={ usersCount }
            isLoading={ isLoading }
            onPageChanged={ onPageChanged }
            onSearch={ onSearch }
            searchPlaceholder='введите имя пользователя'
            children={
                users.map(u => (<User key={ u.id } roles={ roles } user={ u } />))
            } />
    )
}

const User = ({ roles, user }) => {

    const [isBanned, setIsBanned] = useState(false)
    const [bannedUntill, setBannedUntill] = useState('')
    const [modal, contentHolder] = Modal.useModal()

    const onRoleUpdating = (values) => {
        console.log(values)
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
        console.log(values)
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
        <div className='user-list-item'>
            { contentHolder }
            <span>{ user.name }</span>
            <div className='user-options'>
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
                        <div className='ban-info'>Забанен до { bannedUntill }</div>
                        <button className='ban-button unban-color' onClick={ onUnbanning }>Разблокировать</button>
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
                            <button type='submit' className='ban-button ban-color'>Заблокировать</button>
                        </Space.Compact>
                    </Form>
                }
            </div>
        </div>
    )
}

export default UsersPage