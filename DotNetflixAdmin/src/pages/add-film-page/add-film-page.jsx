import { useState, useEffect } from 'react'
import { axiosInstance } from '../../axiosInstance'
import { useForm } from 'antd/es/form/Form';
import { Button, Form, Input, InputNumber, Modal, Select, Space } from 'antd'
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';
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
        axiosInstance.post('api/films/addfilm', values)
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
                onClick={ () => removeHandler(name, personId, form.getFieldValue(['people', name, 'professionId']).value ?? form.getFieldValue(['people', name, 'professionId'])) }>
                Убрать участника
            </Button>
        </Space>
    )
}

export default AddFilmPage