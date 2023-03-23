import { axiosInstance } from '../AxiosInstance'

class FilmService {

    getFilms(path) {
        return axiosInstance
            .get(path)
            .then(response => response.data)
    }
}

export default FilmService