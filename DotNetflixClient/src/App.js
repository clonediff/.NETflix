import { useState } from "react"
import { Route, Routes } from "react-router-dom"
import { LoginPage } from "./pages/login-page/LoginPageContainer/LoginPage"
import { RegistrationPage } from "./pages/registration-page/registration-page/RegistrationPage"
import MainPage from "./pages/main-page"
import SearchPage from "./pages/search-page/search-page"

const App = () => {

    const [burgerPanelStyle, setBurgerPanelStyle] = useState({ top: -190 })
    const [isBurgerHidden, setIsBurgerHidden] = useState(false)

    const changeBurgerPanel = ({ top = 0 }) => {
        if (burgerPanelStyle.top !== top) {
            setBurgerPanelStyle({ top });
            setIsBurgerHidden(!isBurgerHidden)
        }
    }

    return (
        <Routes>
            <Route path="/" element={ <MainPage 
                burgerPanelStyle={ burgerPanelStyle } 
                changeBurgerPanel={ changeBurgerPanel }
                isBurgerHidden={ isBurgerHidden } /> }/>
            <Route path="/login" element={ <LoginPage /> }/>
            <Route path="/registration" element={ <RegistrationPage /> }/>
            <Route path="/search/*" element={ <SearchPage
                burgerPanelStyle={ burgerPanelStyle } 
                changeBurgerPanel={ changeBurgerPanel }
                isBurgerHidden={ isBurgerHidden } /> } />
        </Routes>
    )
}

export default App