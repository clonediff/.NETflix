import image401 from './../../assets/image401.gif';
import image403 from './../../assets/image403.gif';
import image404 from './../../assets/image404.gif';
import image418 from './../../assets/image418.gif'
import image500 from './../../assets/image500.jpg';

let images = {
    401 : image401,
    403 : image403,
    404 : image404, 
    418 : image418, 
    500 : image500
}

let messages = {
    401 : "Кажется, Джейсон Стэйтем запрещает вам попасть на эту страницу",
    403 : "Гэндальф говорит вам, что вы не пройдёте дальше. Мы с ним согласны",
    404 : "Упс, кажется кто-то украл эту страничку", 
    418 : "Разработчик этой страницы - чайник ;)", 
    500 : "Нельзя просто так взять и сделать нормальный сервер"
}


export function ErrorDto (errorNumber) {
    this.imageURL = images[errorNumber];
    this.errorMessage = messages[errorNumber];
}