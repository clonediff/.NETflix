import { useState, useEffect } from 'react';
import { useSearchParams } from 'react-router-dom';
import Header from '../main-page/header/header';
import FilmCard from '../main-page/film-card/film-card';
import BurgerMenu from '../main-page/burger-menu/burger-menu';
import BurgerPanel from '../main-page/burger-panel/burger-panel';
import './search-page.css'
import { axiosInstance } from '../../AxiosInstance';

const SearchPage = () => {

    const [searchParams, ] = useSearchParams()
    const [filmsSearched, setFilmsSearched] = useState([])
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        axiosInstance.get('/api/films/getfilmsbysearch?' + searchParams.toString())
            .then(response => response.data)
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
                    ? null 
                    : filmsSearched.length !== 0
                        ? filmsSearched.map(film => <FilmCard key={ film.id } film={ film } /> )
                        : <span className='not-found-span'>По вашему запросу ничего не найдено</span> 
                }
            </div>
        </>
    )
}

export default SearchPage;