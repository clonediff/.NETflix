import { useState, useEffect } from 'react'
import { axiosInstance } from '../../axiosInstance'
import './films-page.css'
import { Pagination } from 'antd'

const FilmsPage = () => {

    const [films, setFilms] = useState([])
    const [isLoading, setIsLoading] = useState(true)
    const [page, setPage] = useState(1)
    const [filmsCount, setFilmsCount] = useState(0)

    useEffect(() => {
        axiosInstance.get('api/enums/getfilmscount')
            .then(({ data }) => {
                setFilmsCount(data)
                setIsLoading(false)
            })
        axiosInstance.get(`api/enums/getallnames?page=${page}`)
            .then(({ data }) => {
                setFilms(data)
            })
    }, [page])

    const onPageChanged = (page, _) => {
        setPage(page)
    }

    return (
        <>
            {
                !isLoading ? 
                <>
                    <div className='film-list'>
                    {
                        films.map(film => (
                            <div className='film-list-item'>{ film }</div>
                        ))
                    }
                    </div>
                    <Pagination 
                        className='pagination'
                        responsive
                        showSizeChanger={ false }
                        pageSize={ 15 }
                        total={ filmsCount }
                        onChange={ onPageChanged } />
                </>
                : null
            }
        </>
    )
}

export default FilmsPage