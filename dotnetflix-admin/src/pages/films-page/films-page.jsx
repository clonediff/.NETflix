import { useState, useEffect } from 'react'
import { Button, Form, Input, InputNumber, Select, Space } from 'antd'
import { MinusCircleOutlined, PlusOutlined } from '@ant-design/icons';
import { axiosInstance } from '../../axiosInstance'
import './films-page.css'

const FilmsPage = () => {

    const [options, setOptions] = useState({
        types: [],
        categories: [],
        genres: [],
        countries: []
    })

    useEffect(() => {
        axiosInstance.get('api/enums/getall')
            .then(({ data }) => {
                setOptions(data)
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

    return (
        <div className='films-page'>
            <div className='film-list'>Список всех фильмов на сайте</div> 
            <Form className='film-add-form' onFinish={ sendForm }>
                <Form.Item label='Название' className='form-item' name='name'>
                    <Input />
                </Form.Item>
                <Form.Item label='Год выхода' className='form-item' name='year'>
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
                <Form.Item label='Длительность' className='form-item' name='movieLength'>
                    <Input />
                </Form.Item>
                <Form.Item label='Возрастное ограничение' className='form-item' name='ageRating'>
                    <Input />
                </Form.Item>
                <Form.Item label='URL постера' className='form-item' name='posterUrl'>
                    <Input />
                </Form.Item>
                <Form.Item label='Тип' className='form-item' name='type'>
                    <Select allowClear options={ options.types.map(v => ({ label: v, value: v })) } />
                </Form.Item>
                <Form.Item label='Категория' className='form-item' name='category'>
                    <Select allowClear options={ options.categories.map(v => ({ label: v, value: v })) } />
                </Form.Item>
                <Form.Item label='Бюджет' className='form-item' name='budget'>
                    <Input addonAfter={ 
                        <Form.Item name='budgetCurrency' noStyle>
                            { currencySuffix }
                        </Form.Item>
                     } />
                </Form.Item>
                <Form.Item label='Сборы в мире' className='form-item' name='feesWorld'>
                    <Input addonAfter={ 
                        <Form.Item name='feesWorldCurrency' noStyle>
                            { currencySuffix }
                        </Form.Item>
                     } />
                </Form.Item>
                <Form.Item label='Сборы в России' className='form-item' name='feesRussia'>
                    <Input addonAfter={ 
                        <Form.Item name='feesRussiaCurrency' noStyle>
                            { currencySuffix }
                        </Form.Item>
                     } />
                </Form.Item>
                <Form.Item label='Сборы в США' className='form-item' name='feesUsa'>
                    <Input addonAfter={ 
                        <Form.Item name='feesUsaCurrency' noStyle>
                            { currencySuffix }
                        </Form.Item>
                     } />
                </Form.Item>
                <Form.Item label='Жанры' className='form-item' name='genres'>
                    <Select allowClear mode='multiple' options={ options.genres.map(v => ({ label: v, value: v })) } />
                </Form.Item>
                <Form.Item label='Страны' className='form-item' name='countries'>
                    <Select allowClear mode='multiple' options={ options.countries.map(v => ({ label: v, value: v })) } />
                </Form.Item>
                <Form.List name='seasons'>
                    {
                        (fields, { add, remove }) => (
                            <>
                                {
                                    fields.map((field, index) => (  
                                        <>
                                            { index === 0 ? <div className='form-label'>Сезоны</div> : null }
                                            <Space align='center' className='form-item' key={ field.key }>
                                                <Form.Item name={[field.name, 'number']} className='form-list-input'>
                                                    <InputNumber addonBefore='№' />
                                                </Form.Item>
                                                <Form.Item name={[field.name, 'episodesCount']} className='form-list-input'>
                                                    <InputNumber addonBefore='Серии' />
                                                </Form.Item>
                                                <MinusCircleOutlined onClick={ () => remove(field.name) } />
                                            </Space>
                                        </>
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
                                        <>
                                            { index === 0 ? <div className='form-label'>Коллектив</div> : null }
                                            <Space direction='vertical' className='form-item person-space' key={ field.key }>
                                                <Form.Item name={[field.name, 'name']} className='form-list-input'>
                                                    <Input addonAfter={
                                                        <Form.Item name={[field.name, 'profession']} noStyle>
                                                            <Select allowClear options={[
                                                                { label: 'актёр', value: 'актеры' },
                                                                { label: 'оператор', value: 'операторы' }
                                                            ]} />
                                                        </Form.Item>
                                                    } />
                                                </Form.Item>
                                                <Form.Item name={[field.name, 'photo']} className='form-list-input'>
                                                    <Input addonBefore='фото' />
                                                </Form.Item>
                                                <Button 
                                                    icon={ <MinusCircleOutlined /> } 
                                                    onClick={ () => remove(field.name) }>
                                                    Убрать участника
                                                </Button>
                                            </Space>
                                        </>
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

export default FilmsPage