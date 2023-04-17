import { Route, Routes } from "react-router-dom";
import Layout from "./layout";
import MainPage from "./pages/main-page/main-page";
import UsersPage from "./pages/users-page/users-page"
import AddFilmPage from "./pages/add-film-page/add-film-page";
import FilmsPage from "./pages/films-page/films-page";
import LoginPage from "./pages/login-page/login-page";

const App = () => {
    return (
        <Layout>
            <Routes>
                <Route path="/" element={ <MainPage /> } />
                <Route path="/addfilm" element={ <AddFilmPage /> } />
                <Route path="/films" element={ <FilmsPage /> } />
                <Route path="/users" element={ <UsersPage /> } />
                <Route path="/login" element={ <LoginPage /> } />
            </Routes>
        </Layout>
    )
}

export default App;
