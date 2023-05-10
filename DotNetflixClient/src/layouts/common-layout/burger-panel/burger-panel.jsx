import './burger-panel.css'

const BurgerPanel = () => {
    return (
        <div className='burger-panel'>
            <a href='/search?type=movie'>
                Фильмы
            </a>
            <a href='/search?type=tv-series'>
                Сериалы
            </a>
            <a href='/search?type=cartoon'>
                Мультфильмы
            </a>
            <a href='/search?type=anime'>
                Аниме
            </a>
        </div>
    )
}

export default BurgerPanel