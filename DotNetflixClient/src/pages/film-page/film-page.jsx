import CommonLayout from '../../layouts/common-layout/common-layout'
import { CountriesMap } from './countries-map'
import { useNavigate, useParams } from 'react-router-dom'
import { useState, useEffect } from 'react'
import { axiosInstance } from '../../AxiosInstance'
import { PosterSkeleton, TextSkeleton } from '../../libs/film-skeleton/film-skeleton'
import {Image, Modal} from 'antd'
import './film-page.css'
import ReactPlayer from "react-player";

const FilmPage = () => {

    const { id } = useParams()

    const [film, setFilm] = useState({})
    const [isLoading, setIsLoading] = useState(true)
    const [modal, modalHolder] = Modal.useModal()
    const navigate = useNavigate()

    useEffect(() => {
        axiosInstance.get(`api/films/getfilmbyid?id=${id}`)
            .then(response => {
                setFilm(response.data)
                setIsLoading(false)
            })
            .catch(err => {
                modal.error({
                    title: err.response.data,
                    onOk: () => navigate('/subscriptions')
                })
            })
    }, [id])

    return (
        <CommonLayout>
            {modalHolder}
            <div className='film-page'>
                {
                    isLoading
                    ? <FilmPageSkeleton />
                    : <FilmPageInfo film={ film } />
                }
            </div>
        </CommonLayout>
    )
}

const FilmPageInfo = ({ film }) => {
    return (
        <>
            <img className='film-page-poster' alt={ film.name } src={ film.posterUrl } />
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
                <div>
                    { film.countries.map((c) => c.name).join(", ") }
                    <CountriesMap countries={film.countries}/>
                </div>      
                <b>Жанры</b>
                <div>{ film.genres.join(", ") }</div>
                {
                    film.seasonsInfo.length !== 0 
                    ? <SeasonsInfo seasonsInfo={ film.seasonsInfo } />
                    : null
                }
                {
                    film.trailersMetaData.length !== 0
                    ? 
                        <>
                            <b>Трейлеры</b>
                            {
                                film.trailersMetaData.map(tmd => 
                                    <div className="metadata-frame" key={tmd.id}>
                                        <ReactPlayer controls width="70%"
                                                     url={[{src: `http://localhost:7126/api/files/film-${film.id}/${tmd.fileName}`}]}/>
                                        <div className="metadata-table">
                                            <span>Название: {tmd.name}</span>
                                            <span>Дата выхода: {formatDate(tmd.date)}</span>
                                            <span>Язык: {tmd.language}</span>
                                            <span>Качество: {tmd.resolution}</span>
                                        </div>
                                    </div>)
                            }
                        </>
                    : null
                }
                {
                    film.postersMetaData.length !== 0
                    ?
                        <>
                            <b>Постеры</b>
                            {
                                film.postersMetaData.map(tmd =>
                                <div className="metadata-frame" key={tmd.id}>
                                    <Image controls width="70%" src={`http://localhost:7126/api/files/film-${film.id}/${tmd.fileName}`}/>
                                    <div className="metadata-table">
                                        <span>Название: {tmd.name}</span>
                                        <span>Разрешение: {tmd.resolution}</span>
                                    </div>
                                </div>)
                            }
                        </>
                    : null
                }
                {
                    Object.entries(film.professions).map(prof => 
                        <div className='film-page-people-container' key={ prof[0] }>
                            <b className='film-page-profession-name'>{ prof[0] }</b>
                            <div className='film-page-people'>
                                {
                                    prof[1].map((person, id) => <PersonInMovie key={ id } person={ person } />)
                                }
                            </div>
                        </div>
                    )
                }
            </div>
        </>
    )
}

function formatDate(date){
    return new Date(date).toLocaleDateString('ru-ru')
}

const SeasonsInfo = ({ seasonsInfo }) => {
    return (
        <>
            <b>Сезоны</b>
            <div>
                { 
                    seasonsInfo.map(si => <div key={ si.number }>Сезон { si.number }, количество серий: { si.episodesCount }</div>) 
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