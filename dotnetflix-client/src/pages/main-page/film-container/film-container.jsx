import FilmCard from '../film-card/film-card'
import './film-container.css'

const FilmContainer = ({ genre, films }) => {
    return (
        <div className='container'>
            <div className='genre-header'>{ genre }</div> 
            <div className='films'>
                { films.map(film => <FilmCard key={ film.id } film={ film } />) }
            </div>
        </div>
    )
}

export default FilmContainer