import { axiosInstance } from '../AxiosInstance'

class FilmService {

    getSearchFilms(path) {
        return axiosInstance
            .get(path)
            .then(response => response.data)
    }
}

export default FilmService