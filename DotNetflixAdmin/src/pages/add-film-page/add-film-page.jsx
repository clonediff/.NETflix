import { useState, useEffect, useRef } from 'react'
import { axiosInstance } from '../../axiosInstance'
import { useForm } from 'antd/es/form/Form'
import { Button, Form, Input, InputNumber, Modal, Select, Space, Upload, Image, DatePicker } from 'antd'
import { MinusCircleOutlined, PlusOutlined, UploadOutlined } from '@ant-design/icons'
import ReactPlayer from 'react-player'
import './add-film-page.css'
import '../../data-layout/form-styles.css'

const AddFilmPage = () => {

    const [form] = useForm()
    const [modal, modalHolder] = Modal.useModal()

    const [options, setOptions] = useState({
        types: [],
        categories: [],
        genres: [],
        countries: [],
        professions: []
    })

    const [people, setPeople] = useState([])
    const [isFilmCrewEmpty, setIsFilmCrewEmpty] = useState(false)

    const trailersEnd = useRef(null)
    const postersEnd = useRef(null)

    useEffect(() => {
        axiosInstance.get('api/enums/getall')
            .then(({ data }) => {
                setOptions(data)
            })
        axiosInstance.get('api/persons/getall')
            .then(({ data }) => {
                setPeople(data)
            })
    }, [])

    const sendForm = (values) => {
        const formData = new FormData()
        Object.entries(values).forEach(([key, value]) => {
            if (Array.isArray(value)) {
                value.forEach((i, index) => {
                    if (typeof i !== 'object') {
                        formData.append(`${key}[]`, i)
                    } else {
                        Object.entries(i).forEach(([iKey, iValue]) => {
                            if (iValue && (key !== 'trailersMetaData' || ['name', 'date', 'language', 'resolution'].includes(iKey))
                                && (key !== 'postersMetaData' || ['name', 'resolution'].includes(iKey))) {
                                formData.append(`${key}[${index}][${iKey}]`, iValue)
                            }
                        })
                    }
                })
            } else if (value) {
                formData.append(key, value)
            }
        })
        values.trailersMetaData?.forEach(x => formData.append('trailers', x.video.file))
        values.postersMetaData?.forEach(x => formData.append('posters', x.picture.file))
        axiosInstance.post('api/films/addFilm', formData)
            .then(_ => {
                modal.success({
                    title: 'фильм успешно добавлен',
                    zIndex: 10001
                })
            })
            .catch(_ => {
                modal.error({
                    title: 'не удалось добавить фильм',
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

    const getUploadProps = (mediaName, end, nodeFactory, detacher) => {
        return {
            beforeUpload: _ => {
                return false
            },
            onChange: x => {
                if (x.status !== 'removed' && x.status !== 'error' && end) {
                    end.current?.scrollIntoView({ behavior: 'smooth' })
                }
            },
            itemRender: (_, { originFileObj }, __, { remove }) => {
                const url = URL.createObjectURL(originFileObj)
                return (
                    <div style={{ marginTop: 8 }}>
                        { nodeFactory(url) }
                        <Button onClick={ () => {
                            remove()
                            detacher()
                        } }>
                            Открепить {mediaName}
                        </Button>
                    </div>
                )
            },
            maxCount: 1
        }
    }

    return (
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
                                        <SeasonsSpace name={ field.name } removeHandler={ (name, _) => remove(name) } />
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
                                            name={ field.name } 
                                            removeHandler={ (name, __, _) => remove(name) } 
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
                                            remove={ remove }
                                            getUploadProps={ (detacher) => getUploadProps('видео', trailersEnd,
                                                url => (<ReactPlayer controls width='70%' height='70%' url={ url } />), detacher) }
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
                                <Button onClick={ add } icon={ <PlusOutlined /> }>Добавить трейлер</Button>
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
                                            remove={ remove }
                                            getUploadProps={ (detacher) => getUploadProps('постер', postersEnd,
                                                url => (<div style={{ marginBottom: 4 }}>
                                                    <Image width='70%' src={ url } />
                                                </div>), detacher) }
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
                                            ]}     />
                                    </div>
                                ))
                            }
                            <Form.Item className='form-item'>
                                <Button onClick={ add } icon={ <PlusOutlined /> }>Добавить постер</Button>
                            </Form.Item>
                        </>
                    )
                }
            </Form.List>
            <div ref={ postersEnd }></div>
            <Form.Item>
                <Button htmlType='submit' className='form-item'>Добавить</Button>
            </Form.Item>
        </Form>
    )
}

export const SeasonsSpace = ({ seasonId, name, removeHandler }) => {
    return (
        <Space direction='vertical' className='form-item'>
            <Form.Item 
                label='№ Сезона' 
                name={[name, 'number']} 
                className='form-list-input'
                rules={[
                    {
                        required: true,
                        message: 'Введите номер сезона'
                    }
                ]}>
                <InputNumber />
            </Form.Item>
            <Form.Item 
                label='Количество серий' 
                name={[name, 'episodesCount']} 
                className='form-list-input'
                rules={[
                    {
                        required: true,
                        message: 'Введите количество серий'
                    }
                ]}>
                <InputNumber />
            </Form.Item>
            <Button icon={ <MinusCircleOutlined /> } onClick={ () => removeHandler(name, seasonId) }>
                Убрать сезон
            </Button>
        </Space>
    )
}

const filterOptions = (inputValue, option) => {
    return option.label.toLowerCase().indexOf(inputValue.toLowerCase()) !== -1;
}

export const PeopleSpace = ({ personId, name, removeHandler, people, professions, form }) => {

    const [exists, setExists] = useState(true)

    const personPhotoValidator = ({ getFieldValue }) => ({
        validator(_, value) {
            if (getFieldValue(['people', name, 'id']) || value) {
                return Promise.resolve()
            } else {
                return Promise.reject(new Error('добавьте фото'))
            }
        }
    })

    const personValidator = (pathname, errorMessage) => 
        ({ getFieldValue }) => ({
            validator(_, value) {
                if (getFieldValue(['people', name, pathname]) || value) {
                    return Promise.resolve()
                } else {
                    return Promise.reject(new Error(errorMessage))
                }
            }
        })

    const onAddNewPersonClicked = () => {
        form.setFieldValue(['people', name, 'id'], undefined)
        setExists(false)
    }

    const onAddExistingPersonClicked = () => {
        form.setFieldValue(['people', name, 'name'], null)
        form.setFieldValue(['people', name, 'photo'], null)
        setExists(true)
    }

    return (
        <Space direction='vertical' className='form-item person-space'>
            <Space.Compact style={{ width: '100%' }}>
                <Form.Item 
                    name={[name, 'id']}
                    style={{ display: exists ? 'inline-block' : 'none', width: '80%' }} 
                    className='form-list-input'
                    rules={[ personValidator('name', 'выберите актёра') ]}>
                    <Select 
                        style={{ display: exists ? 'inline-block' : 'none' }} 
                        showSearch 
                        allowClear 
                        filterOption={ filterOptions }
                        optionLabelProp='label'
                        notFoundContent={ 
                            <Button className='right-border-radius' onClick={ onAddNewPersonClicked }>
                                Добавить нового человека
                            </Button> }>
                        {
                            people.map(p => (
                                <Select.Option key={ p.id } label={ p.name } value={ p.id }>
                                    <div className='option-item'>
                                        <span>{ p.name }</span>
                                        <img style={{ width: 20 }} src={ p.photo } alt=''/>
                                    </div>
                                </Select.Option>
                            ))
                        }
                    </Select>
                </Form.Item>
                <Form.Item 
                    name={[name, 'name']}
                    style={{ display: !exists ? 'inline-block' : 'none', width: '80%' }}
                    className='form-list-input'
                    rules={[ personValidator('id', 'введите имя актёра') ]}>
                    <Input className='left-border-radius' style={{ display: !exists ? 'inline-block' : 'none' }} />
                </Form.Item>
                <Form.Item 
                    name={[name, 'professionId']}
                    style={{ width: '20%' }} 
                    className='form-list-input'
                    rules={[
                        {
                            required: true,
                            message: 'выберите профессию',
                        }
                    ]}>
                    <Select allowClear options={ professions.map(p => ({ label: p.name, value: p.id })) } />
                </Form.Item>
            </Space.Compact>
            <Form.Item 
                name={[name, 'photo']} 
                hidden={ exists } 
                className='form-list-input' 
                rules={[ personPhotoValidator ]}>
                <Input addonBefore='фото' />
            </Form.Item>
            <Button style={{ display: !exists ? 'block' : 'none' }} onClick={ onAddExistingPersonClicked }>
                Добавить существуещего человека
            </Button>
            <Button 
                icon={ <MinusCircleOutlined /> } 
                onClick={ () => removeHandler(name, personId, form.getFieldValue(['people', name, 'professionId'])?.value ?? form.getFieldValue(['people', name, 'professionId'])) }>
                Убрать участника
            </Button>
        </Space>
    )
}

const MediaSpace = ({ baseName, mediaName, mediaFormName, getUploadProps, remove, formFields }) => {

    const mediaValidator = () => ({
        validator(_, value) {
            if (value && value.fileList.length > 0) {
                return Promise.resolve()
            } else {
                return Promise.reject(new Error(`Прикрепите ${mediaName}`))
            }
        }
    })

    const [isMediaAttached, setIsMediaAttached] = useState(false)

    const renderFormInput = (inputType, options) => {
        switch (inputType) {
            case 'string':
                return (<Input />)
            case 'date':
                return (<DatePicker />)
            case 'array':
                return (
                    <Select>
                        {
                            options.map(o => (<Select.Option key={ o }>{ o }</Select.Option>))
                        }
                    </Select>
                )
            default:
                return null
        }
    }

    return (
        <>
            <Form.Item name={[baseName, mediaFormName]} valuePropName='file' className='form-item'
                rules={[ mediaValidator ]}>
                <Upload { ...getUploadProps(() => setIsMediaAttached(false)) }>
                    {
                        !isMediaAttached &&
                        <Button onClick={ () => setIsMediaAttached(true) } icon={ <UploadOutlined /> }>
                            Прикрепить постер
                        </Button>
                    }
                </Upload>
            </Form.Item>
            {
                formFields.map((field, index) => (
                    <Form.Item key={ index } label={ field.label } name={[baseName, field.name]} className='form-item'
                        rules={[
                            {
                                required: true,
                                message: field.message
                            }
                        ]}>
                        { renderFormInput(field.type, field.data) }
                    </Form.Item>
                ))
            }
            <Button icon={ <MinusCircleOutlined /> } onClick={ () => remove(baseName) } className='form-item'>
                Убрать { mediaName }
            </Button>
        </>
    )
}

export default AddFilmPage