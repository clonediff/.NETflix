import { Route, Routes } from "react-router-dom"
import { LoginPage } from "./pages/login-page/LoginPageContainer/LoginPage"
import MainPage from "./pages/main-page"
import { ProfilePage } from "./pages/profile-page/Profile"
import { RegistrationPage } from "./pages/registration-page/registration-page/RegistrationPage"

const App = () => {
    return (
        <Routes>
            <Route path="/" element={<MainPage></MainPage>}/>
            <Route path="/login" element={<LoginPage></LoginPage>}/>
            <Route path="/registration" element={<RegistrationPage></RegistrationPage>}/>
            <Route path="/profile/*" element={<ProfilePage></ProfilePage>}/>
        </Routes>
    )
}

export default App