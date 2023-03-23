import { Route, Routes } from "react-router-dom"
import { LoginPage } from "./pages/login-page/LoginPageContainer/LoginPage"
import { RegistrationPage } from "./pages/registration-page/registration-page/RegistrationPage"
import MainPage from "./pages/main-page"
import SearchPage from "./pages/search-page/search-page"

const App = () => {
    return (
        <Routes>
            <Route path="/" element={ <MainPage /> }/>
            <Route path="/login" element={ <LoginPage /> }/>
            <Route path="/registration" element={ <RegistrationPage /> }/>
            <Route path="/search/*" element={ <SearchPage /> }/>
        </Routes>
    )
}

export default App