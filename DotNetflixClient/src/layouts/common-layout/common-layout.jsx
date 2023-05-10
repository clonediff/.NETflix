import Header from './header/header'
import BurgerMenu from './burger-menu/burger-menu'
import BurgerPanel from './burger-panel/burger-panel'

const CommonLayout = ({ children }) => {
    return (
        <>
            <BurgerMenu />
            <BurgerPanel />
            <Header />
            { children }
        </>
    )
}

export default CommonLayout