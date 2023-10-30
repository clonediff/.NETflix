import './simple-layout.css'
import ChatWidget from "../common-layout/chat-widget/chat-widget";
import {useLocation} from "react-router-dom";

const SimpleLayout = ({ children }) => {
    const location = useLocation();
    return (
        <>
            <div className='simple-header'>
                <a href='/' className='simple-logo'>.Netflix</a>
            </div>
            { children }
            {
                !location.pathname.includes('chat') ? <ChatWidget/> : <></>
            }
        </>
    )
}

export default SimpleLayout