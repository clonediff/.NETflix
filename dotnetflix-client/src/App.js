import FilmContainer from './components/film-container/film-container'
import Header from './components/header/header'
import films from './data.json'

const App = () => {
    return (
        <>
            <Header />
            {
                ['приключения', 'триллер', 'боевик']
                    .map(genre =>
                        <FilmContainer 
                            genre={genre} 
                            films={films.filter(film => film.genres.map(genre => genre.name).includes(genre))} />
                    )
            }
        </>
    )
}

export default App