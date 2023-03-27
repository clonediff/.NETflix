import { useParams } from 'react-router-dom'
import { useState, useEffect } from 'react'
import { PosterSkeleton, TextSkeleton } from '../../libs/film-skeleton/film-skeleton'
import BurgerMenu from '../main-page/burger-menu/burger-menu'
import BurgerPanel from '../main-page/burger-panel/burger-panel'
import Header from '../main-page/header/header'
import './film-page.css'
import { axiosInstance } from '../../AxiosInstance'

const FilmPage = () => {

    const { id } = useParams()

    const [film, setFilm] = useState({})
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        axiosInstance.get(`api/films/movies?id=${id}`)
            .then(response => {
                setFilm(response.data)
                setIsLoading(false)
            })
    }, [id])

    return (
        <>
            <BurgerMenu />
            <BurgerPanel />
            <Header />
            <div className='film-page'>
                {
                    isLoading
                    ? <FilmPageSkeleton />
                    : <FilmPageInfo film={ film } />
                }
            </div>
        </>
    )
}

const FilmPageInfo = ({ film }) => {
    return (
        <>
            <img className='film-page-poster' alt={ film.name } src={ film.posterURL } />
            <div className='film-info'>
                <div className='film-page-title'>{ film.name }</div>
                <b>Год производства</b>
                <div>{ film.year }</div>
                <b>Описание</b>
                <div className='film-page-long-text'>{ film.description ?? "—" }</div>
                <b>Краткое описание</b>
                <div className='film-page-long-text'>{ film.shortDescription ?? "—" }</div>
                <b>Слоган</b>
                <div className='film-page-long-text'>{ film.slogan ?? "—" }</div>
                <b>Рейтинг</b>
                <div>{ film.rating ?? "—" }</div>
                <b>Длительность</b>
                <div>{ film.movieLength }мин</div>
                <b>Возрастное ограничение</b>
                <div>{ film.ageRating ? `${film.ageRating}+` : "—" }</div>
                <b>Категория</b>
                <div>{ film.category ?? "—" }</div>
                <b>Бюджет</b>
                <div>{ film.budget !== '' ? film.budget : "—" }</div>
                <b>Сборы в мире</b>
                <div>{ film.fees.world !== '' ? film.fees.world : "—" }</div>
                <b>Сборы в России</b>
                <div>{ film.fees.russia !== '' ? film.fees.russia : "—" }</div>
                <b>Сборы в США</b>
                <div>{ film.fees.usa !== '' ? film.fees.usa : "—" }</div>
                <b>Страны</b>
                <div>{ film.countries.join(", ") }</div>
                <b>Жанры</b>
                <div>{ film.genres.join(", ") }</div>
                <b>Сезоны</b>
                <div>
                    { 
                        film.seasonsInfo.length !== 0 
                        ? film.seasonsInfo.map(si => <div key={ si.number }>Сезон { si.number }, количество серий: { si.episodesCount }</div>) 
                        : "—" 
                    }
                </div>
                {
                    film.proffessions.map(prof => 
                        <div className='film-page-people-container' key={ prof.profession }>
                            <b className='film-page-profession-name'>{ prof.profession }</b>
                            <div className='film-page-people'>
                                {
                                    prof.people.map((person, id) => <PersonInMovie key={ id } person={ person } />)
                                }
                            </div>
                        </div>
                    )
                }
            </div>
        </>
    )
}

const PersonInMovie = ({ person }) => {
    return (
        <div className='film-page-person'>
            <img width={ 50 } src={ person.photo } alt=''/>
            <span>{ person.name }</span>
        </div>
    )
}

const FilmPageSkeleton = () => {
    return (
        <>
            <PosterSkeleton />
            <div className='film-info-skeleton'>
                <TextSkeleton width={ 460 } />
                <TextSkeleton width={ 150 } />
                <TextSkeleton width={ 300 } />
                <TextSkeleton width={ 150 } />
                <TextSkeleton width={ 300 } />
                <TextSkeleton width={ 150 } />
                <TextSkeleton width={ 300 } />
                <TextSkeleton width={ 150 } />
                <TextSkeleton width={ 300 } />
                <TextSkeleton width={ 150 } />
                <TextSkeleton width={ 300 } />
            </div>
        </>
    )
}

export default FilmPage