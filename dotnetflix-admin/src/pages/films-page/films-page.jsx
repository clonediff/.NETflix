import { useState, useEffect } from 'react'
import { Button, Checkbox, Form, Input, InputNumber, Select, Space } from 'antd'
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';
import { axiosInstance } from '../../axiosInstance'
import './films-page.css'
import { useForm } from 'antd/es/form/Form';

const FilmsPage = () => {

    const [form] = useForm()

    const [options, setOptions] = useState({
        types: [],
        categories: [],
        genres: [],
        countries: [],
        professions: []
    })

    const [people, setPeople] = useState([{
        id: 0,
        name: '',
        photo: ''
    }])

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
        console.log(values)
        Object.keys(values).forEach(key => {
            if (values[key] === undefined)
                values[key] = null
        });
        axiosInstance.post('api/Films/AddFilm', values)
            .then(response => console.log(response))
            .catch(error => console.log(error))
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
                    return Promise.reject(new Error('Введите наименование валюты'))
                }
                return Promise.resolve()
            }
        })

    return (
        <div className='films-page'>
            <div className='film-list'>Список всех фильмов на сайте</div> 
            <Form form={ form } className='film-add-form' onFinish={ sendForm }>
                <Form.Item label='Название' className='form-item' name='name'
                    rules={[
                        {
                            required: true,
                            message: 'Введите название'
                        }
                    ]}>
                    <Input />
                </Form.Item>
                <Form.Item label='Год выхода' className='form-item' name='year'
                    rules={[
                        {
                            required: true,
                            message: 'Введите год выхода'
                        }
                    ]}>
                    <Input />
                </Form.Item>
                <Form.Item label='Описание' className='form-item' name='description'>
                    <Input />
                </Form.Item>
                <Form.Item label='Краткое описание' className='form-item' name='shortDescription'>
                    <Input />
                </Form.Item>
                <Form.Item label='Слоган' className='form-item' name='slogan'>
                    <Input />
                </Form.Item>
                <Form.Item label='Рейтинг' className='form-item' name='rating'>
                    <Input />
                </Form.Item>
                <Form.Item label='Длительность' className='form-item' name='movieLength'
                    rules={[
                        {
                            required: true,
                            message: 'Введите длительность'
                        }
                    ]}>
                    <Input />
                </Form.Item>
                <Form.Item label='Возрастное ограничение' className='form-item' name='ageRating'>
                    <Input />
                </Form.Item>
                <Form.Item label='URL постера' className='form-item' name='posterUrl'>
                    <Input />
                </Form.Item>
                <Form.Item label='Тип' className='form-item' name='type'
                    rules={[
                        {
                            required: true,
                            message: 'Выберите тип'
                        }
                    ]}>
                    <Select allowClear options={ options.types.map(v => ({ label: v.name, value: v.id })) } />
                </Form.Item>
                <Form.Item label='Категория' className='form-item' name='category'>
                    <Select allowClear options={ options.categories.map(v => ({ label: v.name, value: v.id })) } />
                </Form.Item>
                <Form.Item label='Бюджет' className='form-item' name='budget'>
                    <Input addonAfter={ 
                        <Form.Item name='budgetCurrency' noStyle
                            rules={[ currencyValidator('budget') ]}>
                            { currencySuffix }
                        </Form.Item>
                     } />
                </Form.Item>
                <Form.Item label='Сборы в мире' className='form-item' name='feesWorld'>
                    <Input addonAfter={ 
                        <Form.Item name='feesWorldCurrency' noStyle
                            rules={[ currencyValidator('feesWorld') ]}>
                            { currencySuffix }
                        </Form.Item>
                     } />
                </Form.Item>
                <Form.Item label='Сборы в России' className='form-item' name='feesRussia'>
                    <Input addonAfter={ 
                        <Form.Item name='feesRussiaCurrency' noStyle
                            rules={[ currencyValidator('feesRussia') ]}>
                            { currencySuffix }
                        </Form.Item>
                     } />
                </Form.Item>
                <Form.Item label='Сборы в США' className='form-item' name='feesUsa'>
                    <Input addonAfter={ 
                        <Form.Item name='feesUsaCurrency' noStyle
                            rules={[ currencyValidator('feesUsa') ]}>
                            { currencySuffix }
                        </Form.Item>
                     } />
                </Form.Item>
                <Form.Item label='Жанры' className='form-item' name='genres'
                    rules={[
                        {
                            required: true,
                            message: 'Выберите жанр'
                        }
                    ]}>
                    <Select filterOption={ filterOptions } allowClear mode='multiple' 
                        options={ options.genres.map(v => ({ label: v.name, value: v.id })) } />
                </Form.Item>
                <Form.Item label='Страны' className='form-item' name='countries'
                    rules={[
                        {
                            required: true,
                            message: 'Выберите страны'
                        }
                    ]}>
                    <Select filterOption={ filterOptions } allowClear mode='multiple' 
                        options={ options.countries.map(v => ({ label: v.name, value: v.id })) } />
                </Form.Item>
                <Form.List name='seasons'>
                    {
                        (fields, { add, remove }) => (
                            <>
                                {
                                    fields.map((field, index) => (  
                                        <div key={ field.key }>
                                            { index === 0 ? <div className='form-label'>Сезоны</div> : null }
                                            <SeasonsSpace name={ field.name } remove={ remove } />
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
                <Form.List name='people'>
                    {
                        (fields, { add, remove }) => (
                            <>
                                {
                                    fields.map((field, index) => (
                                        <div key={ field.key }>
                                            { index === 0 ? <div className='form-label'>Коллектив</div> : null }
                                            <PeopleSpace name={ field.name } remove={ remove } 
                                                form={ form } professions={ options.professions } 
                                                people={ people }/>
                                        </div>
                                    ))
                                }
                                <Form.Item className='form-item'>
                                    <Button onClick={ () => add() } icon={ <PlusOutlined /> }>Добавить участника</Button>
                                </Form.Item>
                            </>
                        )
                    }
                </Form.List>
                <Form.Item>
                    <Button htmlType='submit' className='form-item'>Добавить</Button>
                </Form.Item>
            </Form>
        </div>
    )
}

const SeasonsSpace = ({ name, remove }) => {
    return (
        <Space direction='vertical' className='form-item'>
            <Form.Item label='№ Сезона' name={[name, 'number']} className='form-list-input'
                rules={[
                    {
                        required: true,
                        message: 'Введите номер сезона'
                    }
                ]}>
                <InputNumber />
            </Form.Item>
            <Form.Item label='Количество серий' name={[name, 'episodesCount']} className='form-list-input'
                rules={[
                    {
                        required: true,
                        message: 'Введите количество серий'
                    }
                ]}>
                <InputNumber />
            </Form.Item>
            <Button icon={ <MinusCircleOutlined /> } onClick={ () => remove(name) }>
                Убрать сезон
            </Button>
        </Space>
    )
}

const filterOptions = (inputValue, option) => {
    return option.label.toLowerCase().indexOf(inputValue.toLowerCase()) !== -1;
}

const PeopleSpace = ({ name, remove, form, professions, people }) => {

    const [exists, setExists] = useState(true)

    const changeExistance = (exists) => {
        setExists(exists)
        form.setFieldValue(['people', name, 'exists'], exists)
    }

    return (
        <Space direction='vertical' className='form-item person-space'>
            <Space.Compact style={{ width: '100%' }}>
                <Form.Item name={[name, 'id']} noStyle required>
                    <Select 
                        style={{ display: exists ? 'inline-block' : 'none', width: '80%' }} 
                        showSearch 
                        allowClear 
                        filterOption={ filterOptions }
                        optionLabelProp='label'
                        notFoundContent={ 
                            <Button className='right-border-radius' onClick={ () => changeExistance(false) }>
                                Добавить нового человека
                            </Button> }>
                        { people.map(v => (
                            <Select.Option label={v.name} value={v.id}>
                                <OptionItem name={v.name} photo={v.photo}/>
                            </Select.Option>
                        )) }
                        {/* <Select.Option label='Том Круз' value='Том Круз'>
                            <OptionItem name={}/>
                        </Select.Option> */}
                    </Select>
                </Form.Item>
                <Form.Item name={[name, 'name']} noStyle required>
                    <Input className='left-border-radius' style={{ display: !exists ? 'inline-block' : 'none', width: '80%' }} />
                </Form.Item>
                <Form.Item name={[name, 'profession']} noStyle required>
                    <Select style={{ width: '20%' }} allowClear options={ professions.map(v => ({ label: v.name, value: v.id })) }/>
                </Form.Item>
            </Space.Compact>
            <Form.Item hidden={ exists } name={[name, 'photo']} className='form-list-input' noStyle>
                <Input addonBefore='фото' />
            </Form.Item>
            <Form.Item hidden initialValue={ true } name={[name, 'exists']} className='form-list-input' valuePropName='checked' noStyle>
                <Checkbox />
            </Form.Item>
            <Button style={{ display: !exists ? 'block' : 'none' }} onClick={ () => changeExistance(true) }>
                Добавить существуещего человека
            </Button>
            <Button icon={ <MinusCircleOutlined /> } onClick={ () => remove(name) }>
                Убрать участника
            </Button>
        </Space>
    )
}

const OptionItem = ({ name, photo}) => {
    return (
        <div className='option-item'>
            <span>{name}</span>
            <img style={{ width: 20 }} src={photo} alt=''/>
        </div>
    )
}

export default FilmsPage