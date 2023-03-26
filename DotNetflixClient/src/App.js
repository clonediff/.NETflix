import { Route, Routes } from "react-router-dom"
import { ProfilePage } from "./pages/profile-page/Profile"
import { LoginPage } from "./pages/login-page/LoginPageContainer/LoginPage"
import { RegistrationPage } from "./pages/registration-page/registration-page/RegistrationPage"
import MainPage from "./pages/main-page"
import SearchPage from "./pages/search-page/search-page"
import FilmPage from "./pages/film-page/film-page"

const App = () => {
    return (
        <Routes>
            <Route path="/" element={ <MainPage /> }/>
            <Route path="/login" element={ <LoginPage /> }/>
            <Route path="/registration" element={ <RegistrationPage /> }/>
            <Route path="/search/*" element={ <SearchPage /> }/>
            <Route path="/profile/*" element={ <ProfilePage /> }/>
            <Route path="/movies/:id" element={ <FilmPage /> } />
        </Routes>
    )
}

export default App