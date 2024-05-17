import { useEffect, useState, useRef } from 'react'
import { useLocation } from 'react-router-dom'
import { MediaSpace, PeopleSpace, SeasonsSpace } from '../add-film-page/add-film-page'
import { Button, Form, Input, Modal, Select, Image } from 'antd'
import { PlusOutlined } from '@ant-design/icons'
import ReactPlayer from 'react-player'
import { axiosInstance } from '../../clients'
import { initForm, initUpdatedFilm } from './helpers'
import CustomSpin from '../../custom-spin/custom-spin'

const UpdateFilmPage = () => {
    
    const location = useLocation()
    const [form] = Form.useForm()
    const [modal, modalHolder] = Modal.useModal()
    const [film, setFilm] = useState({})
    const [people, setPeople] = useState([])
    const [isFilmCrewEmpty, setIsFilmCrewEmpty] = useState(false)
    const [seasonsToDelete, setSeasonsToDelete] = useState([])
    const [peopleToDelete, setPeopleToDelete] = useState([])
    const [isLoading, setIsLoading] = useState(true)
    const [options, setOptions] = useState({
        types: [],
        categories: [],
        genres: [],
        countries: [],
        professions: []
    })

    const [trailersToDelete, setTrailersToDelete] = useState([])
    const [trailersMetaDataToDelete, setTrailersMetaDataToDelete] = useState([])
    const trailersEnd = useRef(null)

    const [postersToDelete, setPostersToDelete] = useState([])
    const [postersMetaDataToDelete, setPostersMetaDataToDelete] = useState([])
    const postersEnd = useRef(null)

    useEffect(() => {
        axiosInstance.get(`api/films/getfilmbyid?id=${location.pathname.split('/')[3]}`)
            .then(({ data }) => {
                setSeasonsToDelete([])
                setPeopleToDelete([])
                setTrailersToDelete([])
                setPostersToDelete([])
                setTrailersMetaDataToDelete([])
                setPostersMetaDataToDelete([])
                setFilm(data)
                form.setFieldsValue(initForm(data))
                setIsLoading(false)
            })
        axiosInstance.get('api/enums/getall')
            .then(({ data }) => {
                setOptions(data)
            })
        axiosInstance.get('api/persons/getall')
            .then(({ data }) => {
                setPeople(data)
            })
    }, [])

    const removeSeasonHandler = (name, seasonId, remover) => {
        remover(name)
        if (seasonId) {
            setSeasonsToDelete(prev => [ ...prev, seasonId ])
        }
    }

    const removePersonHandler = (name, personId, professionId, remover) => {
        remover(name)
        if (personId) {
            setPeopleToDelete(prev => [ ...prev, { personId: personId, professionId: professionId } ])
        }
    }

    const removeTrailerHandler = (name, trailerName, trailerId, remover) => {
        remover && remover(name)
        if (trailerName) {
            setTrailersToDelete(prev => [ ...prev, trailerName ])
        }
        if (trailerId) {
            setTrailersMetaDataToDelete(prev => [ ...prev, trailerId ])
        }
    }
    
    const removePosterHandler = (name, posterName, posterId, remover) => {
        remover && remover(name)
        if (posterName) {
            setPostersToDelete(prev => [ ...prev, posterName ])
        }
        if (posterId) {
            setPostersMetaDataToDelete(prev => [ ...prev, posterId ])
        }
    }

    const sendForm = (values) => {
        const updatedFilm = initUpdatedFilm(location.pathname.split('/')[3], values, film, seasonsToDelete, peopleToDelete,
            trailersToDelete, postersToDelete, trailersMetaDataToDelete, postersMetaDataToDelete)
        axiosInstance.put('api/films/update', updatedFilm)
            .then(_ => {
                modal.success({
                    title: 'фильм успешно обновлён',
                    zIndex: 10001
                })
            })
            .catch(_ => {
                modal.error({
                    title: 'не удалось обновить фильм',
                    zIndex: 10001
                })
            })
    }

    const currencySuffix = (
        <Select allowClear options={[
            { label: '$', value: '$' },
            { label: '€', value: '€' },
            { label: '₽', value: '₽' }
        ]} />
    )

    const currencyValidator = (namepath) => 
        ({ getFieldValue }) => ({
            validator(_, value) {
                if (getFieldValue(namepath) && !value) {
                    return Promise.reject(new Error('Выберите наименование валюты'))
                }
                return Promise.resolve()
            }
        })

    const filterOptions = (inputValue, option) => {
        return option.label.toLowerCase().indexOf(inputValue.toLowerCase()) !== -1;
    }

    const getUploadProps = (end, detacher, externalRemover, node, nodeFactory) => {
        return {
            beforeUpload: _ => {
                return false
            },
            onChange: x => {
                if (x.status !== 'removed' && x.status !== 'error' && end) {
                    end.current?.scrollIntoView({ behavior: 'smooth' })
                }
            },
            itemRender: (_, file, __, { remove }) => {
                const url = (!!file.originFileObj || Object.entries(file).length > 1) && URL.createObjectURL(file.originFileObj ?? file)
                return (
                    <div style={{ marginTop: 8 }}>
                        { url ? nodeFactory(url) : node }
                        <Button onClick={ () => {
                            remove()
                            detacher()
                            externalRemover()
                        } }>
                            Открепить файл
                        </Button>
                    </div>
                )
            },
            maxCount: 1
        }
    }

    return(
        !isLoading
        ?
        <Form form={ form } className='add-form' onFinish={ sendForm }>
            { modalHolder }
            <Form.Item 
                label='Название' 
                className='form-item' 
                name='name'
                rules={[
                    {
                        required: true,
                        message: 'Введите название'
                    }
                ]}>
                <Input />
            </Form.Item>
            <Form.Item 
                label='Год выхода' 
                className='form-item' 
                name='year'
                rules={[
                    {
                        required: true,
                        message: 'Введите год выхода'
                    }
                ]}>
                <Input />
            </Form.Item>
            <Form.Item 
                label='Описание' 
                className='form-item' 
                name='description'>
                <Input />
            </Form.Item>
            <Form.Item 
                label='Краткое описание' 
                className='form-item' 
                name='shortDescription'>
                <Input />
            </Form.Item>
            <Form.Item 
                label='Слоган' 
                className='form-item' 
                name='slogan'>
                <Input />
            </Form.Item>
            <Form.Item 
                label='Рейтинг' 
                className='form-item' 
                name='rating'>
                <Input />
            </Form.Item>
            <Form.Item 
                label='Длительность' 
                className='form-item' 
                name='movieLength'
                rules={[
                    {
                        required: true,
                        message: 'Введите длительность'
                    }
                ]}>
                <Input />
            </Form.Item>
            <Form.Item 
                label='Возрастное ограничение' 
                className='form-item' 
                name='ageRating'>
                <Input />
            </Form.Item>
            <Form.Item 
                label='URL постера' 
                className='form-item' 
                name='posterUrl'>
                <Input />
            </Form.Item>
            <Form.Item 
                label='Тип' 
                className='form-item' 
                name='type'
                rules={[
                    {
                        required: true,
                        message: 'Выберите тип'
                    }
                ]}>
                <Select allowClear options={ options.types.map(t => ({ label: t.name, value: t.id })) } />
            </Form.Item>
            <Form.Item 
                label='Категория' 
                className='form-item' 
                name='category'>
                <Select allowClear options={ options.categories.map(c => ({ label: c.name, value: c.id })) } />
            </Form.Item>
            <Form.Item 
                label='Бюджет' 
                className='form-item' 
                name='budget'>
                <Input addonAfter={ 
                    <Form.Item name='budgetCurrency' noStyle
                        rules={[ currencyValidator('budget') ]}>
                        { currencySuffix }
                    </Form.Item>
                    } />
            </Form.Item>
            <Form.Item 
                label='Сборы в мире' 
                className='form-item' 
                name='feesWorld'>
                <Input addonAfter={ 
                    <Form.Item name='feesWorldCurrency' noStyle
                        rules={[ currencyValidator('feesWorld') ]}>
                        { currencySuffix }
                    </Form.Item>
                    } />
            </Form.Item>
            <Form.Item 
                label='Сборы в России' 
                className='form-item' 
                name='feesRussia'>
                <Input addonAfter={ 
                    <Form.Item name='feesRussiaCurrency' noStyle
                        rules={[ currencyValidator('feesRussia') ]}>
                        { currencySuffix }
                    </Form.Item>
                    } />
            </Form.Item>
            <Form.Item 
                label='Сборы в США' 
                className='form-item' 
                name='feesUsa'>
                <Input addonAfter={ 
                    <Form.Item name='feesUsaCurrency' noStyle
                        rules={[ currencyValidator('feesUsa') ]}>
                        { currencySuffix }
                    </Form.Item>
                    } />
            </Form.Item>
            <Form.Item 
                label='Жанры' 
                className='form-item' 
                name='genres'
                rules={[
                    {
                        required: true,
                        message: 'Выберите жанр'
                    }
                ]}>
                <Select 
                    filterOption={ filterOptions } 
                    allowClear 
                    mode='multiple' 
                    options={ options.genres.map(g => ({ label: g.name, value: g.id })) } />
            </Form.Item>
            <Form.Item 
                label='Страны' 
                className='form-item' 
                name='countries'
                rules={[
                    {
                        required: true,
                        message: 'Выберите страны'
                    }
                ]}>
                <Select 
                    filterOption={ filterOptions } 
                    allowClear 
                    mode='multiple' 
                    options={ options.countries.map(c => ({ label: c.name, value: c.id })) } />
            </Form.Item>
            <Form.List name='seasons'>
                {
                    (fields, { add, remove }) => (
                        <>
                            {
                                fields.map((field, index) => (  
                                    <div key={ field.key }>
                                        { index === 0 ? <div className='form-label'>Сезоны</div> : null }
                                        <SeasonsSpace 
                                            seasonId={ index < film.seasons?.length ? film.seasons[index].id : undefined } 
                                            name={ field.name } 
                                            removeHandler={ (name, seasonId) => removeSeasonHandler(name, seasonId, remove) } />
                                    </div>
                                ))
                            }
                            <Form.Item className='form-item'>
                                <Button onClick={ () => add() } icon={ <PlusOutlined /> }>Добавить сезон</Button>
                            </Form.Item>
                        </>
                    )
                }
            </Form.List>
            <Form.List 
                name='people'
                rules={[
                    {
                        validator: (rule, value, _) => {
                            if (value && value.length > 0) {
                                return Promise.resolve()
                            } else {
                                setIsFilmCrewEmpty(true)
                                return Promise.reject(new Error('добавьте участников фильма'))
                            }
                        }
                    }
                ]}>
                {
                    (fields, { add, remove }) => (
                        <>
                            {
                                fields.map((field, index) => (
                                    <div key={ field.key }>
                                        { index === 0 ? <div className='form-label'>Коллектив</div> : null }
                                        <PeopleSpace 
                                            personId={ index < film.filmCrew.length ? film.filmCrew[index].id : undefined }
                                            name={ field.name } 
                                            removeHandler={ (name, personId, professionId) => removePersonHandler(name, personId, professionId, remove) } 
                                            people={ people } 
                                            professions={ options.professions }
                                            form={ form } />
                                    </div>
                                ))
                            }
                            <Form.Item className='form-item'>
                                <Button 
                                    onClick={ () => { 
                                        setIsFilmCrewEmpty(false)
                                        add() 
                                    }} 
                                    icon={ <PlusOutlined /> }>Добавить участника</Button>
                            </Form.Item>
                            {
                                isFilmCrewEmpty ? <div className='form-label' style={{ color: '#ff4d4f' }}>Добавьте участников фильма</div> : null
                            }
                        </>
                    )
                }
            </Form.List>
            <Form.List name='trailersMetaData'>
                {
                    (fields, { add, remove }) => (
                        <>
                            {
                                fields.map((field, index) => (
                                    <div key={ field.key }>
                                        { index === 0 ? <div className='form-label'>Трейлеры</div> : null }
                                        <MediaSpace
                                            baseName={ field.name }
                                            mediaName='трейлер'
                                            mediaFormName='video'
                                            removeHandler={ () => removeTrailerHandler(field.name, 
                                                index < ((film.trailersMetaData?.length ?? 0) - trailersToDelete.length) && film.trailersMetaData[index].fileName,
                                                index < ((film.trailersMetaData?.length ?? 0) - trailersToDelete.length) && film.trailersMetaData[index].id, remove) }
                                            defaultFile={ index < ((film.trailersMetaData?.length ?? 0) - trailersToDelete.length) ? {} : form.getFieldValue(['trailersMetaData', field.name, 'video'])?.file }
                                            getUploadProps={ (detacher) => getUploadProps(trailersEnd, detacher,
                                                () => removeTrailerHandler(field.name, index < ((film.trailersMetaData?.length ?? 0) - trailersToDelete.length) && film.trailersMetaData[index].fileName),
                                                index < film.trailersMetaData.length && <ReactPlayer controls width='70%' height='70%' url={[{ src: `https://localhost:7126/api/files/film-${location.pathname.split('/')[3]}/${film.trailersMetaData[index].fileName}` }]} />,
                                                url => (<ReactPlayer controls width='70%' height='70%' url={ url } />)) }
                                            formFields={[
                                                {
                                                    label: 'Название',
                                                    name: 'name',
                                                    message: 'Введите название',
                                                    type: 'string'
                                                },
                                                {
                                                    label: 'Дата выхода',
                                                    name: 'date',
                                                    message: 'Введите дату',
                                                    type: 'date'
                                                },
                                                {
                                                    label: 'Язык',
                                                    name: 'language',
                                                    message: 'Выберите язык',
                                                    type: 'array',
                                                    data: ['Русский', 'Английский']
                                                },
                                                {
                                                    label: 'Разрешение',
                                                    name: 'resolution',
                                                    message: 'Выберите разрешение',
                                                    type: 'array',
                                                    data: ['360', '720', '1080', '4K']
                                                }
                                            ]} />
                                    </div>
                                ))
                            }
                            <Form.Item className='form-item'>
                                <Button onClick={ () => add() } icon={ <PlusOutlined /> }>Добавить трейлер</Button>
                            </Form.Item>
                        </>
                    )
                }
            </Form.List>
            <div ref={ trailersEnd }></div>
            <Form.List name='postersMetaData'>
                {
                    (fields, { add, remove }) => (
                        <>
                            {
                                fields.map((field, index) => (
                                    <div key={ field.key }>
                                        { index === 0 ? <div className='form-label'>Постеры</div> : null }
                                        <MediaSpace
                                            baseName={ field.name }
                                            mediaName='постер'
                                            mediaFormName='picture'
                                            removeHandler={ () => removePosterHandler(field.name, 
                                                index < ((film.postersMetaData?.length ?? 0) - postersToDelete.length) && film.postersMetaData[index].fileName,
                                                index < ((film.postersMetaData?.length ?? 0) - postersToDelete.length) && film.postersMetaData[index].id, remove) }
                                            defaultFile={ index < ((film.postersMetaData?.length ?? 0) - postersToDelete.length) ? {} : form.getFieldValue(['postersMetaData', field.name, 'picture'])?.file }
                                            getUploadProps={ (detacher) => getUploadProps(postersEnd, detacher, 
                                                () => removePosterHandler(field.name, index < ((film.postersMetaData?.length ?? 0) - postersToDelete.length) && film.postersMetaData[index].fileName),
                                                index < film.postersMetaData.length &&
                                                <div style={{ marginBottom: 4 }}>
                                                    <Image width='70%' src={ `https://localhost:7126/api/files/film-${location.pathname.split('/')[3]}/${film.postersMetaData[index].fileName}` } />
                                                </div>,
                                                url => (<div style={{ marginBottom: 4 }}>
                                                            <Image width='70%' src={ url } />
                                                        </div>)) }
                                            formFields={[
                                                {
                                                    label: 'Название',
                                                    name: 'name',
                                                    message: 'Введите название',
                                                    type: 'string'
                                                },
                                                {
                                                    label: 'Разрешение',
                                                    name: 'resolution',
                                                    message: 'Введите разрешение',
                                                    type: 'string'
                                                }
                                            ]} />
                                    </div>
                                ))
                            }
                            <Form.Item className='form-item'>
                                <Button onClick={ () => add() } icon={ <PlusOutlined /> }>Добавить постер</Button>
                            </Form.Item>
                        </>
                    )
                }
            </Form.List>
            <Form.Item>
                <Button htmlType='submit' className='form-item'>Обновить</Button>
            </Form.Item>
        </Form>
        :
        <CustomSpin />
    )
}

export default UpdateFilmPage