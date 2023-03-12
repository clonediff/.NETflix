import { useState } from 'react'
import FilmContainer from '../film-container/film-container'
import BurgerMenu from '../burger-menu/burger-menu'
import Header from '../header/header'
import films from '../../../data.json'
import './main-page.css'

const MainPage = () => {

    const [topProp, setLeftProp] = useState({
        top: -190
    })

    const [isBurgerHidden, setIsBurgerHidden] = useState(false)

    const changeBurgerPanel = ({ top = 0 }) => {
        if (topProp.top !== top){
            setLeftProp({ top });
            setIsBurgerHidden(!isBurgerHidden)
        }
    }

    return (
        <>
            <BurgerMenu hidden={ isBurgerHidden } onBurgerClick={ changeBurgerPanel } />
            <div onClick={ () => changeBurgerPanel({ top: -190 }) }>
                <Header />
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
                <div className='main-page'>
                    {
                        ['Приключения', 'Триллер', 'Боевик']
                            .map(genre =>
                                <FilmContainer 
                                    key={ genre }
                                    genre={ genre } 
                                    films={ films.filter(film => film.genres.map(genre => genre.name).includes(genre.toLowerCase())) } />
                            )
                    }
                </div>
            </div>
        </>
    )
}

export default MainPage