import { useState, useEffect } from 'react'
import './burger-menu.css'

const BurgerMenu = ({ hidden, onBurgerClick }) => {

    const [burgerPopStyle, setBurgerPopStyle] = useState({})

    useEffect(() => {
        hidden 
        ? setBurgerPopStyle({
            opacity: 0,
            transform: 'rotate(90deg)',
            cursor: 'auto'
        })
        : setBurgerPopStyle({}) 
    }, [hidden])

    return (
        <svg style={ burgerPopStyle } onClick={ onBurgerClick } className='burger-menu' viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><g id="SVGRepo_bgCarrier" strokeWidth="0"></g><g id="SVGRepo_tracerCarrier" strokeLinecap="round" strokeLinejoin="round"></g><g id="SVGRepo_iconCarrier"> <path d="M4 18L20 18" stroke="#ffffff" strokeWidth="2" strokeLinecap="round"></path> <path d="M4 12L20 12" stroke="#ffffff" strokeWidth="2" strokeLinecap="round"></path> <path d="M4 6L20 6" stroke="#ffffff" strokeWidth="2" strokeLinecap="round"></path> </g></svg>
    )
}

export default BurgerMenu