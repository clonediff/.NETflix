import './header.css'

const Header = () => {

    return (
        <div className='flex-container'>
            <div className='flex-container'>
                <a href='#' className='logo'>.Netflix</a>
                <div className='links'>
                    <a href='#'>Фильмы</a>
                    <a href='#'>Сериалы</a>
                </div>
            </div>
            <input className='search' type='search' placeholder='поиск' />
        </div>
    )
}

export default Header