import { useState, useEffect } from 'react'
import { Button, Form, Input, Select } from 'antd'
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
        axiosInstance.post('api/admin/grab', values)
    }

    return (
        <div className='films-page'>
            <div className='film-list'>Список всех фильмов на сайте</div> 
            <Form className='film-add-form' onFinish={ sendForm }>
                <div className='form-item'>Название</div>
                <Form.Item className='form-item' name='name'>
                    <Input className='form-input' />
                </Form.Item>
                <div className='form-item'>Год выхода</div>
                <Form.Item className='form-item' name='year'>
                    <Input className='form-input' />
                </Form.Item>
                <div className='form-item'>Описание</div>
                <Form.Item className='form-item' name='description'>
                    <Input className='form-input' />
                </Form.Item>
                <div className='form-item'>Краткое описание</div>
                <Form.Item className='form-item' name='shortdescription'>
                    <Input className='form-input' />
                </Form.Item>
                <div className='form-item'>Слоган</div>
                <Form.Item className='form-item' name='slogan'>
                    <Input />
                </Form.Item>
                <div className='form-item'>Рейтинг</div>
                <Form.Item className='form-item' name='rating'>
                    <Input />
                </Form.Item>
                <div className='form-item'>Длительность</div>
                <Form.Item className='form-item' name='movielength'>
                    <Input />
                </Form.Item>
                <div className='form-item'>Возрастное ограничение</div>
                <Form.Item className='form-item' name='agerating'>
                    <Input />
                </Form.Item>
                <div className='form-item'>URL постера</div>
                <Form.Item className='form-item' name='posterurl'>
                    <Input />
                </Form.Item>
                <div className='form-item'>Тип</div>
                <Form.Item className='form-item' name='type'>
                    <Select allowClear options={ options.types.map(v => ({ label: v, value: v })) } />
                </Form.Item>
                <div className='form-item'>Категория</div>
                <Form.Item className='form-item' name='category'>
                    <Select allowClear options={ options.categories.map(v => ({ label: v, value: v })) } />
                </Form.Item>
                <div className='form-item'>Бюджет</div>
                <Form.Item className='form-item' name='budget'>
                    <Input />
                </Form.Item>
                <div className='form-item'>Сборы в мире</div>
                <Form.Item className='form-item' name='feesworld'>
                    <Input className='form-input' />
                </Form.Item>
                <div className='form-item'>Сборы в России</div>
                <Form.Item className='form-item' name='feesrussia'>
                    <Input />
                </Form.Item>
                <div className='form-item'>Сборы в США</div>
                <Form.Item className='form-item' name='feesusa'>
                    <Input />
                </Form.Item>
                <div className='form-item'>Жанры</div>
                <Form.Item className='form-item' name='genres'>
                    <Select allowClear mode='multiple' options={ options.genres.map(v => ({ label: v, value: v })) } />
                </Form.Item>
                <div className='form-item'>Страны</div>
                <Form.Item className='form-item' name='countries'>
                    <Select allowClear mode='multiple' options={ options.countries.map(v => ({ label: v, value: v })) } />
                </Form.Item>
                <Form.Item>
                    <Button className='form-item'>Добавить</Button>
                </Form.Item>
            </Form>
        </div>
    )
}

export default FilmsPage