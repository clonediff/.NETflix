import './support-chat-page.css'
import { Pagination } from 'antd'
import { SupportChatRoomComponent } from './support-chat-room-component'

const SupportChatPage = () => {

    return (
        <div className='chat-container'>
            <div className='chat-previews'>
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
            </div>
            <SupportChatRoomComponent />
        </div>
    )
}

const ChatItem = () => {
    return (
        <div className='chat-item'>
            <span>User 1: How to fix this problem</span>
            <span className='unread-counter'>4</span>
        </div>
    )
}

export default SupportChatPage