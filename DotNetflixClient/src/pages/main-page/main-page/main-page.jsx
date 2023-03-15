import { useState } from 'react'
import FilmContainer from '../film-container/film-container'
import BurgerMenu from '../burger-menu/burger-menu'
import Header from '../header/header'
import films from '../../../data.json'
import './main-page.css'
import BurgerPanel from '../burger-panel/burger-panel'

const MainPage = () => {

    const [burgerPanelStyle, setBurgerPanelStyle] = useState({ top: -190 })
    const [isBurgerHidden, setIsBurgerHidden] = useState(false)

    const changeBurgerPanel = ({ top = 0 }) => {
        if (burgerPanelStyle.top !== top) {
            setBurgerPanelStyle({ top });
            setIsBurgerHidden(!isBurgerHidden)
        }
    }

    return (
        <>
            <BurgerMenu hidden={ isBurgerHidden } onBurgerClick={ changeBurgerPanel } />
            <BurgerPanel topProp={ burgerPanelStyle } />
            <div onClick={ () => changeBurgerPanel({ top: -190 }) }>
                <Header />
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