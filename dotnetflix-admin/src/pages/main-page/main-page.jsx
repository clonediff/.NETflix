import { useState, useEffect } from 'react'
import { axiosInstance } from '../../axiosInstance'
import './main-page.css'

const MainPage = () => {

    const [filmsCount, setFilmsCount] = useState(0)
    const [usersCount, setUsersCount] = useState(0)

    useEffect(() => {
        axiosInstance.get('api/users/getuserscount')
            .then(({ data }) => {
                setUsersCount(data)
            })
        axiosInstance.get('api/films/getfilmscount')
            .then(({ data }) => {
                setFilmsCount(data)
            })
    }, [])

    return (
        <>
            <div className='grid-data-item'>
                <h1>{ filmsCount }</h1>
                <div><strong>фильмов на сайте</strong></div>
            </div>
            <div className='grid-data-item'>
                <h1>{ usersCount }</h1>
                <div><strong>пользователей на сайте</strong></div>
            </div>
        </>
    )
}

export default MainPage