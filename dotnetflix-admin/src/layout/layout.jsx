import { Link } from 'react-router-dom'
import './layout.css'

const Layout = ({ children }) => {
    return (
        <>
            <div className='header'>
                <div className='header-navigation'>
                    <Link to='/' className='navigation-links'>Главная</Link>
                    <Link to='/addfilm' className='navigation-links'>Добавить фильм</Link>
                    <Link to='/films' className='navigation-links'>Фильмы</Link>
                    <Link to='/users' className='navigation-links'>Пользователи</Link>
                </div>
            </div>
            <div className='side-bar'>
                <div className='side-bar-navigation'>
                    <Link to='/' className='navigation-links'>Главная</Link>
                    <Link to='/films' className='navigation-links'>Список фильмов</Link>
                    <Link to='/addfilm' className='navigation-links'>Добавить фильм</Link>
                    <Link to='/users' className='navigation-links'>Пользователи</Link>
                    <Link to='/subscriptions' className='navigation-links'>Подписки</Link>
                    <Link to='/addsubscription' className='navigation-links'>Добавить подписку</Link>
                </div>
            </div>
            <div className='content'>
                { children }    
            </div>
        </>
    )
}

export default Layout