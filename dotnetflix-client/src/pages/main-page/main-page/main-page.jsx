import FilmContainer from '../film-container/film-container'
import Header from '../header/header'
import films from '../../../data.json'
import './main-page.css'

const MainPage = () => {
    return (
        <>
            <Header />
            <div className='main-page'>
                {
                    ['Приключения', 'Триллер', 'Боевик']
                        .map(genre =>
                            <FilmContainer 
                                genre={ genre } 
                                films={ films.filter(film => film.genres.map(genre => genre.name).includes(genre.toLowerCase())) } />
                        )
                }
            </div>
        </>
    )
}

export default MainPage