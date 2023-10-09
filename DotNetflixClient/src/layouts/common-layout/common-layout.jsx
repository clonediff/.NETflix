import Header from './header/header'
import BurgerMenu from './burger-menu/burger-menu'
import BurgerPanel from './burger-panel/burger-panel'
import ChatWidget from './chat-widget/chat-widget';
import { useLocation } from "react-router-dom";

const CommonLayout = ({ children }) => {
    const location = useLocation();
    return (
        <>
            <BurgerMenu />
            <BurgerPanel />
            <Header />
            { children }
            {
                !location.pathname.includes('chat') ? <ChatWidget/> : <></>
            }
        </>
    )
}

export default CommonLayout