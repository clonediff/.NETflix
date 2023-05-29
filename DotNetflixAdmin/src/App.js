import { Route, Routes, useNavigate } from 'react-router-dom'
import Layout from './layout/layout'
import MainPage from './pages/main-page/main-page'
import UsersPage from './pages/users-page/users-page'
import AddFilmPage from './pages/add-film-page/add-film-page'
import FilmsPage from './pages/films-page/films-page'
import SubscriptionPage from './pages/subscription-page/subscription-page'
import AddSubscriptionPage from './pages/add-subscription-page/add-subscription'
import UpdateFilmPage from './pages/update-film-page/update-film'
import FilmDetailsPage from './pages/film-datails-page/film-details-page'
import { LoginPage } from './pages/login-page/login-page'
import { useEffect } from 'react'

const App = () => {
    const isAuthenticated = localStorage.getItem('authenticated')
    const navigate = useNavigate()

    useEffect(() => {
        if(isAuthenticated)
            navigate("/")
        else
            navigate("/login")
    }, [])

    return (
        <div>
        {isAuthenticated ? <Layout>
            <Routes>
                <Route path='/' element={ <MainPage /> } />
                <Route path='/addfilm' element={ <AddFilmPage /> } />
                <Route path='/films' element={ <FilmsPage /> } />
                <Route path='/films/editfilm/:id' element={ <UpdateFilmPage /> }/>
                <Route path='/films/details/:id' element={ <FilmDetailsPage /> } />
                <Route path='/users' element={ <UsersPage /> } />
                <Route path='/subscriptions' element={ <SubscriptionPage /> } />
                <Route path='/addsubscription' element={ <AddSubscriptionPage /> } />
            </Routes>
        </Layout> : 
        <Routes>
            <Route path="/login" element={<LoginPage/>}/>
        </Routes>}
        </div>)
}

export default App;
