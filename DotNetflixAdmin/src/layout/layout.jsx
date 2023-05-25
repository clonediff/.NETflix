import { Link } from 'react-router-dom'
import './layout.css'

const Layout = ({ children }) => {
    return (
        <>
            <svg className='burger-menu' viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><g id="SVGRepo_bgCarrier" strokeWidth="0"></g><g id="SVGRepo_tracerCarrier" strokeLinecap="round" strokeLinejoin="round"></g><g id="SVGRepo_iconCarrier"> <path d="M4 18L20 18" stroke="#ffffff" strokeWidth="2" strokeLinecap="round"></path> <path d="M4 12L20 12" stroke="#ffffff" strokeWidth="2" strokeLinecap="round"></path> <path d="M4 6L20 6" stroke="#ffffff" strokeWidth="2" strokeLinecap="round"></path> </g></svg>
            <div className='burger-navigation'>
                <Link to='/' className='navigation-links'>Главная</Link>
                <Link to='/films' className='navigation-links'>Фильмы</Link>
                <Link to='/addfilm' className='navigation-links'>Добавить фильм</Link>
                <Link to='/users' className='navigation-links'>Пользователи</Link>
                <Link to='/subscriptions' className='navigation-links'>Подписки</Link>
                <Link to='/addsubscription' className='navigation-links'>Добавить подписку</Link>
            </div>
            <div className='header'>
            </div>
            <div className='side-bar'>
                <div className='side-bar-navigation'>
                    <Link to='/' className='navigation-links'>Главная</Link>
                    <Link to='/films' className='navigation-links'>Фильмы</Link>
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