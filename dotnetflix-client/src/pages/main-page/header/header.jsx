import './header.css'

const Header = () => {
    return (
        <div className='flex-container align-items'>
            <a href='/' className='logo'>.Netflix</a>
            <div className='links'>
                <a className='header-link' href='/'>Фильмы</a>
                <a className='header-link' href='/'>Сериалы</a>
                <a className='header-link' href='/'>Мультфильмы</a>
                <a className='header-link' href='/'>Аниме</a>
            </div>
            <div className='flex-container'>
                <div className='search'>
                    <input type='search' placeholder='Поиск' />
                    <svg className='search-glass' viewBox="-102.4 -102.4 1228.80 1228.80" version="1.1" xmlns="http://www.w3.org/2000/svg" fill="#000000"><g id="SVGRepo_bgCarrier" strokeWidth="0"></g><g id="SVGRepo_tracerCarrier" strokeLinecap="round" strokeLinejoin="round"></g><g id="SVGRepo_iconCarrier"><path d="M448 768A320 320 0 1 0 448 128a320 320 0 0 0 0 640z m297.344-76.992l214.592 214.592-54.336 54.336-214.592-214.592a384 384 0 1 1 54.336-54.336z" fill="#c0c0c0"></path></g></svg>
                </div>
                <a className='header-link' href='/login'>Войти</a>
            </div>
        </div>
    )
}

export default Header