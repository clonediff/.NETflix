import { useState, useEffect } from 'react'
import { FilmContainer, FilmsContainerSkeleton } from '../film-container/film-container'
import BurgerMenu from '../burger-menu/burger-menu'
import BurgerPanel from '../burger-panel/burger-panel'
import Header from '../header/header'
import './main-page.css'
import { axiosInstance } from '../../../AxiosInstance'

const MainPage = () => {

    const [grouppedFilms, setGrouppedFilms] = useState([])
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        axiosInstance.get('/api/films/getallfilms')
            .then(response => response.data)
            .then(data => {
                setGrouppedFilms(data)
                setIsLoading(false)
            })
    }, [])

    return (
        <>
            <BurgerMenu />
            <BurgerPanel />
            <Header />
            <div className='main-page-container'>
                {
                    isLoading
                    ? <FilmsContainerSkeleton />
                    : grouppedFilms.map(group =>
                        <FilmContainer
                            key={ group.films[0].id }
                            category={ group.category }
                            films={ group.films }/>)
                }
            </div>
        </>
    )
}

export default MainPage