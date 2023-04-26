import { useState, useEffect } from 'react'
import { axiosInstance } from '../../axiosInstance'
import DataLayout from '../../data-layout/data-layout'
import './films-page.css'
import '../../data-layout/data-layout.css'

const FilmsPage = () => {

    const [films, setFilms] = useState([])
    const [searchedFilms, setSearchedFilms] = useState(null)
    const [isLoading, setIsLoading] = useState(true)
    const [page, setPage] = useState(1)
    const [filmsCount, setFilmsCount] = useState(0)
    const [searchedFilmsCount, setSearchedFilmsCount] = useState(null)
        
    useEffect(() => {
        axiosInstance.get(`api/films/getallnames?page=${page}`)
            .then(({ data }) => {
                setFilms(data.data)
                setFilmsCount(data.count)
                setIsLoading(false)
            })
    }, [page])

    const onPageChanged = (page, _) => {
        setPage(page)
    }

    const onSearch = (values) => {
        axiosInstance.get(`api/films/getallnames?name=${encodeURIComponent(values.name)}`)
            .then(({ data }) => {
                setSearchedFilms(data.data)
                setSearchedFilmsCount(data.count)
            })
    }

    const clearSearchedFilms = () => {
        if (searchedFilms) {
            setSearchedFilms(null)
            setSearchedFilmsCount(null)
        }
    }

    return (
        <DataLayout
            dataCount={ searchedFilmsCount ?? filmsCount }
            isLoading={ isLoading }
            onPageChanged={ onPageChanged }
            onSearch={ onSearch }
            pageSize={ 25 }
            onSearchClear={ clearSearchedFilms }
            searchPlaceholder='название фильма'>
            <div className='data-list'>
                {
                    (searchedFilms ?? films).map((film, i) => (<div key={ i } className='film-list-item'>{ film }</div>))
                }
            </div>
        </DataLayout>
    )
}

export default FilmsPage