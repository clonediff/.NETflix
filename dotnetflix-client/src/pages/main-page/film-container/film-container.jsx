import { useState, useEffect } from 'react'
import FilmCard from '../film-card/film-card'
import './film-container.css'

const FilmContainer = ({ genre, films }) => {

    const [filmList, setFilmList] = useState({})

    useEffect(() => {
        setFilmList(document.getElementById(genre))
    }, [genre])

    const moveFilmsRight = () => {
        filmList.scrollBy({ left: filmList.clientWidth, behavior: 'smooth' })
    }

    const moveFilmsLeft = () => {
        filmList.scrollBy({ left: -filmList.clientWidth, behavior: 'smooth' })
    }

    return (
        <div className='container'>
            <div className='genre-header'>{ genre }</div> 
            <div className='films-container'>
                <div onClick={ moveFilmsLeft } className='arrow-container'>
                    <svg className='arrow' viewBox="0 0 1024 1024" xmlns="http://www.w3.org/2000/svg"><g id="SVGRepo_bgCarrier" strokeWidth="0"></g><g id="SVGRepo_tracerCarrier" strokeLinecap="round" strokeLinejoin="round"></g><g id="SVGRepo_iconCarrier"><path d="M604.7 759.2l61.8-61.8L481.1 512l185.4-185.4-61.8-61.8L357.5 512z" fill='#ffffff'></path></g></svg>
                </div>
                <div id={ genre } className='films'>
                    { films.map(film => <FilmCard key={ film.id } film={ film } />) }
                </div>
                <div onClick={ moveFilmsRight } className='arrow-container'>
                    <svg className='arrow' viewBox="0 0 1024 1024" xmlns="http://www.w3.org/2000/svg"><g id="SVGRepo_bgCarrier" strokeWidth="0"></g><g id="SVGRepo_tracerCarrier" strokeLinecap="round" strokeLinejoin="round"></g><g id="SVGRepo_iconCarrier"><path d="M419.3 264.8l-61.8 61.8L542.9 512 357.5 697.4l61.8 61.8L666.5 512z" fill='#ffffff'></path></g></svg>
                </div>
            </div>
        </div>
    )
}

export default FilmContainer