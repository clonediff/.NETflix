import FilmCard from '../film-card/film-card'
import './film-container.css'

const FilmContainer = ({ genre, films }) => {
    return (
        <div className='body'>
            <div className='genre-header'>{ genre }</div> 
            <div className='film-container'>
                { films.map(film => <FilmCard key={ film.id } film={ film } />) }
            </div>
        </div>
    )
}

export default FilmContainer