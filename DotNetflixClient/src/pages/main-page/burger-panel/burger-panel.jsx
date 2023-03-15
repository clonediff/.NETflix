import './burger-panel.css'

const BurgerPanel = ({ topProp }) => {
    return (
        <div style={ topProp } className='burger-panel'>
            <a href='/'>
                Фильмы
            </a>
            <a href='/'>
                Сериалы
            </a>
            <a href='/'>
                Мультфильмы
            </a>
            <a href='/'>
                Аниме
            </a>
        </div>
    )
}

export default BurgerPanel