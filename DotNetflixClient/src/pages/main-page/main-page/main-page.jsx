import CommonLayout from '../../../layouts/common-layout/common-layout'
import { useState, useEffect } from 'react'
import { FilmContainer, FilmsContainerSkeleton } from '../film-container/film-container'
import { axiosInstance } from '../../../AxiosInstance'
import './main-page.css'

const MainPage = () => {

    const [grouppedFilms, setGrouppedFilms] = useState([])
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        axiosInstance.get('/api/films/getallfilms')
            .then(response => response.data)
            .then(data => {
                setGrouppedFilms(Object.entries(data))
                setIsLoading(false)
            })
    }, [])

    return (
        <CommonLayout>
            <div className='main-page-container'>
                {
                    isLoading
                    ? <FilmsContainerSkeleton />
                    : grouppedFilms.map(group =>
                        <FilmContainer
                            key={ group[1][0].id }
                            category={ group[0] }
                            films={ group[1] }/>)
                }
                <div className='chat-link'>
                    <a href='/chat'>
                        Присоединяйся к беседе в нашем чате
                    </a>
                </div>
            </div>
        </CommonLayout>
    )
}

export default MainPage