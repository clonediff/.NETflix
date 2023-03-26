import { axiosInstance } from '../AxiosInstance'

class FilmService {

    getData(path) {
        return axiosInstance
            .get(path)
            .then(response => response.data)
    }
}

export default FilmService