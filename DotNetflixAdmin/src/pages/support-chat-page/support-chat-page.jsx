import { useNavigate } from 'react-router-dom'
import './support-chat-page.css'
import { Pagination } from 'antd'

const SupportChatPage = () => {

    return (
        <>
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <ChatItem />
            <Pagination 
                className='pagination'
                responsive
                pageSize={ 25 }
                showSizeChanger={ false }
                total={ 100 } />
        </>
    )
}

const ChatItem = () => {

    const navigate = useNavigate();

    return (
        <div className="chat-item" onClick={ () => navigate('/support-chat') }>
            <span>User 1: How to fix this problem</span>
            <span className='unread-counter'>4</span>
        </div>
    )
}

export default SupportChatPage