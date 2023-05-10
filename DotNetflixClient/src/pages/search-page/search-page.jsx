import CommonLayout from '../../layouts/common-layout/common-layout';
import FilmCard from '../main-page/film-card/film-card';
import { useState, useEffect } from 'react';
import { useSearchParams } from 'react-router-dom';
import { FilmCardSkeleton } from '../../libs/film-skeleton/film-skeleton'
import { axiosInstance } from '../../AxiosInstance';
import './search-page.css'

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
        <CommonLayout>
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
        </CommonLayout>
    )
}

const SearchedFilmsSkeleton = () => {
    return (
        <div className='films-searched-skeleton'>
            {
                Array(4).fill().map((_, i) => i + 1).map(id => <FilmCardSkeleton key={ id } />)
            }
        </div>
    )
}

export default SearchPage;