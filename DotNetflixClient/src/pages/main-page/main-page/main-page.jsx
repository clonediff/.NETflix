import { useState, useEffect } from 'react'
import { FilmContainer, FilmsContainerSkeleton } from '../film-container/film-container'
import BurgerMenu from '../burger-menu/burger-menu'
import BurgerPanel from '../burger-panel/burger-panel'
import Header from '../header/header'
import FilmService from '../../../services/film-service'
import './main-page.css'

const MainPage = () => {

    const [grouppedFilms, setGrouppedFilms] = useState([])
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        const filmService = new FilmService()
        filmService.getData('/')
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