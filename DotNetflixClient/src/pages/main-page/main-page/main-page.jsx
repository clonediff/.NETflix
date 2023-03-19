import FilmContainer from '../film-container/film-container'
import BurgerMenu from '../burger-menu/burger-menu'
import Header from '../header/header'
import BurgerPanel from '../burger-panel/burger-panel'
import films from '../../../data.json'
import './main-page.css'

const MainPage = ({ isBurgerHidden, changeBurgerPanel, burgerPanelStyle }) => {
    return (
        <>
            <BurgerMenu hidden={ isBurgerHidden } onBurgerClick={ changeBurgerPanel } />
            <BurgerPanel topProp={ burgerPanelStyle } />
            <div className='main-page-container' onClick={ () => changeBurgerPanel({ top: -190 }) }>
                <Header />
                <div>
                    {/* {
                        ['Приключения', 'Триллер', 'Боевик']
                            .map(genre =>
                                <FilmContainer 
                                    key={ genre }
                                    genre={ genre } 
                                    films={ films.filter(film => film.genres.map(genre => genre.name).includes(genre.toLowerCase())) } />
                            )
                    } */}
                </div>
            </div>
        </>
    )
}

export default MainPage