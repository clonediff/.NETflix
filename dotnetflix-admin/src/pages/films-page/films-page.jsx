import { useState, useEffect } from 'react'
import { axiosInstance } from '../../axiosInstance'
import { Button, Form, Input, Pagination } from 'antd'
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
                setIsLoading(false)
            })
    }, [])

    useEffect(() => {
        axiosInstance.get(`api/films/getallnames?page=${page}&name=${searchedFilmName}`)
            .then(({ data }) => {
                setFilms(data)
            })
    }, [page, searchedFilmName])

    const onPageChanged = (page, _) => {
        setPage(page)
    }

    const onSearch = (values) => {
        setSearchedFilmName(values.name)
    }

    return (
        <>
            {
                !isLoading 
                ? 
                <>
                    <Form onFinish={ onSearch }>
                        <Form.Item name='name' noStyle>
                            <Input.Search placeholder='Введите название фильма' className='film-search' />
                        </Form.Item>
                        <Form.Item hidden noStyle>
                            <Button htmlType='submit'></Button>  
                        </Form.Item>
                    </Form>
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
                        pageSize={ 25 }
                        total={ filmsCount }
                        onChange={ onPageChanged } />
                </>
                : 
                null
            }
        </>
    )
}

export default FilmsPage