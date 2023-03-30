import { Link } from 'react-router-dom'
import './layout.css'

const Layout = ({ children }) => {
    return (
        <>
            <div className='header'></div>
            <div className='side-bar'>
                <div className='side-bar-navigation'>
                    <Link to='/' className='side-bar-navigation-link'>Главная</Link>
                    <Link to='/films' className='side-bar-navigation-link'>Фильмы</Link>
                    <Link to='/users' className='side-bar-navigation-link'>Пользователи</Link>
                </div>
            </div>
            <div className='content'>
                { children }    
            </div>
        </>
    )
}

export default Layout