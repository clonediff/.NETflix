import { useEffect, useState } from 'react'
import { axiosInstance } from '../../axiosInstance'
import { Button, Checkbox, Modal } from 'antd'
import DataLayout from '../../data-layout/data-layout'
import '../../data-layout/data-layout.css'


const FilmsModal = ({ openFilms, hideFilmsModal, subscription }) => {

    const [films, setFilms] = useState([])
    const [searchedFilms, setSearchedFilms] = useState(null)
    const [page, setPage] = useState(1)
    const [initialSubsInfo, setInitialSubsInfo] = useState([])
    const [message, setMessage] = useState(null)

    useEffect(() => {
        if (openFilms && films.length === 0) {
            axiosInstance.get(`api/subscription/getallFilmswithsubscription?subscriptionId=${subscription.id}`)
                .then(({ data }) => {
                    setFilms(data)
                    setInitialSubsInfo(data.map(f => f.isInSubscription))
                })
        }
    }, [openFilms])

    const onPageChanged = (page, _) => {
        setPage(page)
    }

    const onSearch = (values) => {
        const filteredFilms = films.filter(f => f.name.toLowerCase().includes(values.name.toLowerCase()))
        setSearchedFilms(filteredFilms)
    }

    const clearSearchedFilms = () => {
        if (searchedFilms) {
            setSearchedFilms(null)
        }
    }

    const changeAllTo = (value) => 
        () => {
            if (searchedFilms) {
                searchedFilms.forEach(film => {
                    film.isInSubscription = value
                })
                setSearchedFilms(searchedFilms) 
            } else {
                films.forEach(film => film.isInSubscription = value)
            }
            setFilms([ ...films ])
        }

    const sendForm = () => {
        const entries = films.filter((f, i) => initialSubsInfo[i] !== f.isInSubscription)
            .map(f => [f.id, f.isInSubscription])
        if (entries.length !== 0) {
            axiosInstance.put(`api/subscription/updatefilmsinsubscription?subscriptionId=${subscription.id}`, Object.fromEntries(entries))
                .then(response => setMessage(
                    <div style={{ color: 'green' }}>Список фильмов успешно обновлён</div>
                ))
                .catch(error => setMessage(
                    <div style={{ color: 'red' }}>Не удалось обновить список фильмов</div>
                ))
        }
    }

    const handleCheckboxChange = (id) => 
        (e) => {
            films.find(f => f.id === id).isInSubscription = e.target.checked
            setFilms([ ...films ])
        }

    const handleModalClose = () => {
        if (message) {
            setMessage(null)
            setFilms([])
        }
    }

    return (
        <Modal
            open={ openFilms } 
            afterClose={ handleModalClose }
            onCancel={ hideFilmsModal } 
            closable={ false }
            zIndex={ 10001 }
            footer={
                <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                    <Button type='primary' onClick={ changeAllTo(true) }>Выбрать всё</Button>
                    <Button type='primary' onClick={ changeAllTo(false) }>Отменить всё</Button>
                    <Button type='primary' onClick={ sendForm }>Изменить</Button>
                </div>
            }>
            <DataLayout
                dataCount={ (searchedFilms ?? films).length }
                isLoading={ false }
                onPageChanged={ onPageChanged }
                onSearch={ onSearch }
                pageSize={ 10 }
                onSearchClear={ clearSearchedFilms }
                searchPlaceholder='название фильма'>
                <div className='data-list'>
                    {
                        (searchedFilms ?? films)
                            .slice(10 * (page - 1), 10 * page)
                            .map(film => (
                                <div key={ film.id }>
                                    <Checkbox
                                        checked={ film.isInSubscription }
                                        defaultChecked={ film.isInSubscription } 
                                        onChange={ handleCheckboxChange(film.id) }>
                                        { film.name }
                                    </Checkbox>
                                </div>
                            ))
                    }
                </div>
            </DataLayout>
            { message }
        </Modal>
    )
}

export default FilmsModal