import { useState, useEffect } from 'react'
import { axiosInstance } from '../../axiosInstance'
import DataLayout from '../../data-layout/data-layout'
import './films-page.css'

const FilmsPage = () => {

    const [films, setFilms] = useState([])
    const [isLoading, setIsLoading] = useState(true)
    const [page, setPage] = useState(1)
    const [filmsCount, setFilmsCount] = useState(0)
    const [searchedFilmName, setSearchedFilmName] = useState(null)

    useEffect(() => {
        axiosInstance.get('api/films/getfilmscount')
            .then(({ data }) => {
                setFilmsCount(data)
            })
    }, [])
        
    useEffect(() => {
        axiosInstance.get(`api/films/getallnames?page=${page}`)
            .then(({ data }) => {
                setFilms(data)
                setIsLoading(false)
            })
    }, [page])

    useEffect(() => {
        if (searchedFilmName) {
            axiosInstance.get(`api/films/getallnames?page=1&name=${encodeURIComponent(searchedFilmName)}`)
                .then(({ data }) => {
                    setFilms(data)
                    setFilmsCount(data.length)
                })
        }
    }, [searchedFilmName])

    const onPageChanged = (page, _) => {
        setPage(page)
    }

    const onSearch = (values) => {
        setSearchedFilmName(values.name)
    }

    return (
        <DataLayout
            dataCount={ filmsCount }
            isLoading={ isLoading }
            onPageChanged={ onPageChanged }
            onSearch={ onSearch }
            searchPlaceholder='введите название фильма'
            children={
                films.map((film, i) => (<div key={ i } className='film-list-item'>{ film }</div>))
            } />
    )
}

export default FilmsPage