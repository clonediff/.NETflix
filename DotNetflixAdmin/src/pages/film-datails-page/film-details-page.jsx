import { useEffect, useState } from 'react'
import { useLocation } from 'react-router-dom'
import { axiosInstance } from '../../axiosInstance'
import CustomSpin from '../../custom-spin/custom-spin'

const FilmDetailsPage = () => {

    const location = useLocation()
    const [film, setFilm] = useState({})
    const [isLoading, setIsLoading] = useState(true)

    useEffect(() => {
        setIsLoading(true)
        axiosInstance.get(`api/films/getfilmdetails?id=${location.pathname.split('/')[3]}`)
            .then(({ data }) => {
                console.log(data)
                setFilm(data)
                setIsLoading(false)
            })
    }, [])

    return (
        !isLoading
        ?
        <>
            <div>
                <b>Название:</b> { film.name }
            </div>
            <div>
                <b>Год выхода:</b> { film.year }
            </div>
            <div>
                <b>Описание:</b> { film.description ?? '—' }
            </div>
            <div>
                <b>Краткое описание:</b> { film.shortDescription ?? '—' }
            </div>
            <div>
                <b>Слоган:</b> { film.slogan ?? '—' }
            </div>
            <div>
                <b>Рейтинг:</b> { film.rating ?? '—' }
            </div>
            <div>
                <b>Длительность:</b> { film.movieLength }
            </div>
            <div>
                <b>Возрастное ограничение:</b> { film.ageRating ?? '—' }
            </div>
            <div>
                <b>Ссылка на постер: </b>
                <a href={ film.posterUrl }>{ film.posterUrl }</a>
            </div>
            <div>
                <b>Тип:</b> { film.type }
            </div>
            <div>
                <b>Категория:</b> { film.category ?? '—' }
            </div>
            <div>
                <b>Бюджет: </b> { film.budget ?? '—' }
            </div>
            <div>
                <b>Сборы в мире:</b> { film.fees?.world ?? '—' }
            </div>
            <div>
                <b>Сборы в России:</b> { film.fees?.russia ?? '—' }
            </div>
            <div>
                <b>Сборы в США:</b> { film.fees?.usa ?? '—' }
            </div>
            <div>
                <b>Страны:</b> { film.countries.join(', ') }
            </div>
            <div>
                <b>Жанры:</b> { film.genres.join(', ') }
            </div>
            <div>
                <b>Сезоны: </b> 
                { 
                    film.seasons.length !== 0
                        ? film.seasons.map(s => <div key={ s.number }>Сезон { s.number }, количество серий: { s.episodesCount }</div>)
                        : '—'
                }
            </div>
            <div>
                <b>В каких подписках: </b> 
                {
                    film.subscriptionNames.length !== 0
                        ? film.subscriptionNames.join(', ')
                        : '—'
                }
            </div>
            <div>
                <b>Участники: </b>
                {
                    film.filmCrew.map((fc, i) => 
                        <div key={ i } style={{ marginBottom: 8, marginTop: i === 0 ? 8 : 0 }}>
                            <div>
                                <b>Имя:</b> { fc.name }
                            </div>
                            <div>
                                <b>Ссылка на фото: </b>
                                <a href={ fc.photo }>{ fc.photo ?? '—' }</a>
                            </div>
                            <div>
                                <b>Профессия:</b> { fc.profession }
                            </div>
                        </div>)
                }
            </div>
        </>
        :
        <CustomSpin />
    )
}

export default FilmDetailsPage