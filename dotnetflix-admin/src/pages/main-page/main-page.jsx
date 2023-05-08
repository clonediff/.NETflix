import { useState, useEffect } from 'react'
import { axiosInstance } from '../../axiosInstance'
import CustomSpin from '../../custom-spin/custom-spin'
import './main-page.css'

const MainPage = () => {

    const [filmsCount, setFilmsCount] = useState(0)
    const [usersCount, setUsersCount] = useState(0)
    const [subscriptionsCount, setSubscriptionsCount] = useState(0)
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        axiosInstance.get('api/subscription/getsubscriptionscount')
            .then(({ data }) => {
                setSubscriptionsCount(data)
            })
        axiosInstance.get('api/user/getuserscount')
            .then(({ data }) => {
                setUsersCount(data)
            })
        axiosInstance.get('api/films/getfilmscount')
            .then(({ data }) => {
                setFilmsCount(data)
                setIsLoading(false)
            })
    }, [])

    return (
        <>
            {
                !isLoading
                ?
                <>
                    <div className='grid-data-item'>
                        <h1>{ filmsCount }</h1>
                        <div><strong>фильмов на сайте</strong></div>
                    </div>
                    <div className='grid-data-item'>
                        <h1>{ subscriptionsCount }</h1>
                        <div><strong>подписок на сайте</strong></div>
                    </div>
                    <div className='grid-data-item'>
                        <h1>{ usersCount }</h1>
                        <div><strong>пользователей на сайте</strong></div>
                    </div>
                </>
                :
                <CustomSpin />
            }
        </>
    )
}

export default MainPage