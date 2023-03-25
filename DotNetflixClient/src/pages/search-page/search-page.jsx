import { useState, useEffect } from 'react';
import { useSearchParams } from 'react-router-dom';
import { FilmCardSkeleton } from '../film-skeleton/film-skeleton';
import Header from '../main-page/header/header';
import FilmCard from '../main-page/film-card/film-card';
import BurgerMenu from '../main-page/burger-menu/burger-menu';
import BurgerPanel from '../main-page/burger-panel/burger-panel';
import FilmService from '../../services/film-service';
import './search-page.css'

const SearchPage = () => {

    const [searchParams, ] = useSearchParams()
    const [filmsSearched, setFilmsSearched] = useState([])
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        const filmService = new FilmService()
        filmService.getFilms('/search?' + searchParams.toString())
            .then(data => {
                setFilmsSearched(data)
                setIsLoading(false)
            })
    }, [searchParams])

    return (
        <>
            <BurgerMenu />
            <BurgerPanel />
            <Header />
            <div className='films-searched'>
                <h1 className='title'>
                    Результаты поиска
                </h1>
                { 
                    isLoading 
                    ? <SearchedFilmsSkeleton />
                    : filmsSearched.length !== 0
                        ? filmsSearched.map(film => <FilmCard key={ film.id } film={ film } /> )
                        : <span className='not-found-span'>По вашему запросу ничего не найдено</span> 
                }
            </div>
        </>
    )
}

const SearchedFilmsSkeleton = () => {
    return (
        <div className='skeleton-grid-container'>
            {
                Array(4).fill().map((_, i) => i + 1).map(id => <FilmCardSkeleton key={ id } />)
            }
        </div>
    )
}

export default SearchPage;