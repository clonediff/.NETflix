import { useState, useEffect } from 'react'
import { axiosInstance } from '../../axiosInstance'
import DataLayout from '../../data-layout/data-layout'
import User from './user'
import '../../data-layout/data-layout.css'

const UsersPage = () => {

    const [users, setUsers] = useState([])
    const [searchedUsers, setSearchedUsers] = useState(null)
    const [roles, setRoles] = useState([])
    const [isLoading, setIsLoading] = useState(true)
    const [page, setPage] = useState(1)   
    const [usersCount, setUsersCount] = useState(0)
    const [searchedUsersCount, setSearchedUsersCount] = useState(null)

    useEffect(() => {
        axiosInstance.get('api/user/getallroles')
            .then(({ data }) => {
                setRoles(data)
            })
    }, [])

    const fetchUsers = () => axiosInstance.get(`api/user/getusers?page=${page}`)
        .then(({ data }) => {
            setUsers(data.data)
            setUsersCount(data.count)
            setIsLoading(false)
        })

    useEffect(fetchUsers, [page])

    const onPageChanged = (page, _) => {
        setPage(page)
    }

    const onSearch = (values) => {
        axiosInstance.get(`api/user/getusers?name=${encodeURIComponent(values.name)}`)
            .then(({ data }) => {
                setSearchedUsers(data.data)
                setSearchedUsersCount(data.count)
            })
    }

    const clearSearchedUsers = () => {
        if (searchedUsers) {
            setSearchedUsers(null)
            setSearchedUsersCount(null)
        }
    }

    return (
        <DataLayout
            dataCount={ (searchedUsersCount ?? usersCount) }
            isLoading={ isLoading }
            onPageChanged={ onPageChanged }
            onSearch={ onSearch }
            pageSize={ 25 }
            onSearchClear={ clearSearchedUsers }
            searchPlaceholder='имя пользователя'>
            <div className='data-list'>
                {
                    (searchedUsers ?? users).map(u => (<User key={ u.id } roles={ roles } user={ u } onChange={ fetchUsers } />))
                }
            </div>
        </DataLayout>
    )
}

export default UsersPage