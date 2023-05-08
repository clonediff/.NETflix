import { Route, Routes } from "react-router-dom"
import { ProfilePage } from "./pages/profile-page/Profile"
import { LoginPage } from "./pages/login-page/LoginPageContainer/LoginPage"
import { RegistrationPage } from "./pages/registration-page/registration-page/RegistrationPage"
import MainPage from "./pages/main-page"
import SearchPage from "./pages/search-page/search-page"
import FilmPage from "./pages/film-page/film-page"
import { ErrorPage } from "./pages/ErrorPages/ErrorPage"
import { SubscriptionsPage } from "./pages/subscriptions-page/SubscriptionsPage"

const App = () => {
    return (
        <Routes>
            <Route path="/" element={ <MainPage /> }/>
            <Route path="/login" element={ <LoginPage /> }/>
            <Route path="/registration" element={ <RegistrationPage /> }/>
            <Route path="/search/*" element={ <SearchPage /> }/>
            <Route path="/profile/*" element={ <ProfilePage /> }/>
            <Route path="/movies/:id" element={ <FilmPage /> } />
            <Route path="/subscriptions" element={ <SubscriptionsPage/> } />
            <Route path="*" element={<ErrorPage errorNumber={404}/>}></Route>
            {/* <Route path="500"element={<ErrorPage errorNumber={500}/>}></Route>
            <Route path="401"element={<ErrorPage errorNumber={401}/>}></Route>
            <Route path="403"element={<ErrorPage errorNumber={403}/>}></Route>
            <Route path="418"element={<ErrorPage errorNumber={418}/>}></Route> */}
        </Routes>
    )
}

export default App