import { Button, Form, Input, Pagination, Select, Space } from 'antd'
import { useState, useEffect } from 'react'
import { axiosInstance } from '../../axiosInstance'
import './users-page.css'

const UsersPage = () => {

    const [users, setUsers] = useState([])
    const [page, setPage] = useState(1) 
    const [searchedUserName, setSearchedUserName] = useState(null)

    useEffect(() => {
        axiosInstance.get(`userURL?page=${page}&name=${searchedUserName}`)
            .then(({ data }) => {
                setUsers(data)
            })
    }, [page, searchedUserName])

    const onPageChanged = (page, _) => {
        setPage(page)
    }

    const onSearch = (values) => {
        setSearchedUserName(values.name)
    }

    return (
        <>
            <Form onFinish={ onSearch }>
                <Form.Item name='name' noStyle>
                    <Input.Search placeholder='введите имя пользователя' className='user-search' />
                </Form.Item>
                <Form.Item hidden noStyle>
                    <Button htmlType='submit'></Button>
                </Form.Item>
            </Form>
            <div className='user-list'>
                <User />
                <User />
                <User />
                <User />
                <User />
                <User />
                <User />
                <User />
                <User />
                <User />
                <User />
                <User />
                <User />
                <User />
                <User />
                <User />
            </div>
            <Pagination 
                className='pagination'
                responsive
                showSizeChanger={ false }
                pageSize={ 15 }
                total={ 100 }
                onChange={ onPageChanged } />
        </>
    )
}

const User = () => {

    const [isBanned, setIsBanned] = useState(false)

    const onRoleUpdating = (values) => {
        console.log(values)
        axiosInstance.put('roleURL', { ...values, id: 1 })
    }

    const onBanning = (values) => {
        console.log(values)
        axiosInstance.put('banURL', { ...values, id: 1 })
        setIsBanned(true)
    } 

    const onUnbanning = () => {
        axiosInstance.put('unbanURL', { id: 1 })
        setIsBanned(false)
    }

    return (
        <div className='user-list-item'>
            <span>User 1</span>
            <div className='user-options'>
                <Form disabled={ isBanned } onFinish={ onRoleUpdating }>
                    <Space.Compact>
                        <Form.Item 
                            name='role' 
                            initialValue='пользователь'
                            noStyle>
                            <Select 
                                options={[
                                    { label: 'пользователь', value: 'пользователь' },
                                    { label: 'модератор чата', value: 'модератор чата' },
                                    { label: 'менеджер', value: 'менеджер' }
                            ]} />
                        </Form.Item>
                        <Button htmlType='submit'>Обновить роль</Button>
                    </Space.Compact>
                </Form>
                {
                    isBanned 
                    ?
                    <Space.Compact>
                        <div className='ban-info'>Забанен до 16.04.2023</div>
                        <button className='ban-button unban-color' onClick={ onUnbanning }>Разблокировать</button>
                    </Space.Compact>
                    :
                    <Form onFinish={ onBanning }>
                        <Space.Compact>
                            <Form.Item 
                                name='period'
                                initialValue='1'
                                noStyle>
                                <Select
                                    options={[
                                        { label: '1 день', value: '1' },
                                        { label: '7 дней', value: '7' },
                                        { label: '30 дней', value: '30' },
                                        { label: '180 дней', value: '180' }
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