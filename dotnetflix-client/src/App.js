import { Route, Routes } from "react-router-dom"
import { LoginPage } from "./pages/login-page/LoginPageContainer/LoginPage"
import MainPage from "./pages/main-page"
import { RegistrationPage } from "./pages/registration-page/RegistrationPage"

const App = () => {
    return (
        <Routes>
            <Route path="/" element={<MainPage></MainPage>}/>
            <Route path="/login" element={<LoginPage></LoginPage>}/>
            <Route path="/registration" element={<RegistrationPage></RegistrationPage>}/>
        </Routes>
    )
}

export default App