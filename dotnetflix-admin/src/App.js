import { Route, Routes } from "react-router-dom";
import Layout from "./layout";
import FilmsPage from "./pages/films-page/films-page";
import MainPage from "./pages/main-page/main-page";
import UsersPage from "./pages/users-page/users-page"

const App = () => {
    return (
        <Layout>
            <Routes>
                <Route path="/" element={ <MainPage /> } />
                <Route path="/films" element={ <FilmsPage /> } />
                <Route path="/users" element={ <UsersPage /> } />
            </Routes>
        </Layout>
    )
}

export default App;
