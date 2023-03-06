import './film-card.css'

const FilmCard = ({ film }) => {
    return (
        <a href={ `/movies/${film.id}` }>
            <div className='film-card'>
                <img className='film-poster' alt={ film.name } src={ film.poster.url } />
                <div className='film-title'>{ film.name }</div>
                <div>{ film.rating.imdb }</div>
            </div>
        </a>
    )
}

export default FilmCard