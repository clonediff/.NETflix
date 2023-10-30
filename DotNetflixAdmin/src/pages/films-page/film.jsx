import { useNavigate } from 'react-router-dom'
import { Button } from 'antd'
import { axiosInstance } from '../../axiosInstance'

const Film = ({ film, modal, modalHolder, onDeleteHandler }) => {

    const navigate = useNavigate()

    const deleteFilm = () => {
        axiosInstance.delete(`api/films/delete?id=${film.id}`)
            .then(_ => {
                modal.success({
                    title: 'фильм успешно удалён',
                    zIndex: 10001,
                    afterClose: onDeleteHandler
                })
            })
            .catch(error => {
                modal.error({
                    title: error,
                    zIndex: 10001
                })
            })
    }

    return (
        <div className='list-item'>
            { modalHolder }
            <a style={{ color: 'black' }} href={`/films/details/${ film.id }`}>{ film.name }</a>
            <div className='list-item-options'>
                <Button type='primary' onClick={ () => navigate(`/films/details/${film.id}`)}>Детали</Button>
                <Button type='primary' onClick={ () => navigate(`/films/editfilm/${film.id}`) }>Изменить</Button>
                <Button type='primary' danger onClick={ deleteFilm }>Удалить</Button>
            </div>
        </div>
    )
}

export default Film