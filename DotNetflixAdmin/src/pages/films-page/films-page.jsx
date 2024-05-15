import { useState, useEffect } from 'react'
import { axiosInstance } from '../../clients'
import Film from './film'
import DataLayout from '../../data-layout/data-layout'
import './films-page.css'
import '../../data-layout/data-layout.css'
import { Modal } from 'antd'

const FilmsPage = () => {

    const [films, setFilms] = useState([])
    const [searchedFilms, setSearchedFilms] = useState(null)
    const [isLoading, setIsLoading] = useState(true)
    const [page, setPage] = useState(1)
    const [filmsCount, setFilmsCount] = useState(0)
    const [searchedFilmsCount, setSearchedFilmsCount] = useState(null)

    const [modal, modalHolder] = Modal.useModal()

    const fetchFilms = () => {
        axiosInstance.get(`api/films/getfilmsfiltered?page=${page}`)
            .then(({ data }) => {
                setFilms(data.data)
                setFilmsCount(data.count)
                setIsLoading(false)
            })
    }
        
    useEffect(fetchFilms, [page])

    const onPageChanged = (page, _) => {
        setPage(page)
    }

    const onSearch = (values) => {
        axiosInstance.get(`api/films/getfilmsfiltered?name=${encodeURIComponent(values.name)}`)
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
                    (searchedFilms ?? films).map(film => (
                        <Film 
                            key={ film.id } 
                            film={ film }
                            modal={ modal }
                            modalHolder={ modalHolder }
                            onDeleteHandler={ fetchFilms } />
                    ))
                }
            </div>
        </DataLayout>
    )
}

export default FilmsPage