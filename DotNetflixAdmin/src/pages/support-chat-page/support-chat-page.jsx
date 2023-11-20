import { useEffect, useState } from 'react'
import { HttpTransportType, HubConnectionBuilder } from '@microsoft/signalr'
import { Button, Pagination } from 'antd'
import { axiosInstance } from '../../axiosInstance'
import CustomSpin from '../../custom-spin/custom-spin'
import SupportChatRoomComponent from './support-chat-room-component'
import './support-chat-page.css'

const SupportChatPage = () => {

    const [isLoading, setIsLoading] = useState(true)
    const [chatPreviews, setChatPreviews] = useState([])
    const [chatPreviewsCount, setChatPreviewsCount] = useState(0)
    const [selectedRoom, setSelectedRoom] = useState(undefined)
    const [connection, setConnection] = useState(null)

    useEffect(() => {
        if (!connection) {
            const newConnection = new HubConnectionBuilder()
                .withUrl('https://localhost:7289/supportChatHub', {
                    skipNegotiation: true,
                    transport: HttpTransportType.WebSockets
                })
                .build()
            setConnection(newConnection)
        }
        fetchPreviews(1, null)
    }, [])
    
    useEffect(() => {
        if (connection) {
            connection.start()
        }
    }, [connection])
    
    const fetchPreviews = (page, _) => {
        axiosInstance.get(`api/support-chat/preview/?page=${page}&size=25`)
        .then(({ data }) => {
                setChatPreviews(data.data)
                setChatPreviewsCount(data.count)
                setIsLoading(false)
            })
    }

    const markMessagesAsRead = (roomId) => {
        const newChatPreview = chatPreviews.find(p => p.roomId === roomId)
        newChatPreview.totalUnReadMessages = 0
        setChatPreviews([ ...chatPreviews ])
    }

    const updateMessagePreview = (roomId, userName, latestMessage) => {
        const newChatPreview = chatPreviews.find(p => p.roomId === roomId)
        newChatPreview.userName = userName
        newChatPreview.latestMessage = typeof latestMessage === 'string' ? latestMessage : 'файл'
        setChatPreviews([ ...chatPreviews ])
    }

    return (
        !isLoading
        ?
        <div className='chat-container'>
            {
                chatPreviews.length !== 0
                ?
                <>
                    <Button className='show-chats' size='small'>&gt;</Button>
                    <div className='chat-previews'>
                        {
                            chatPreviews.map(preview => (
                                <ChatPreview 
                                    key={ preview.roomId }
                                    preview={ preview }
                                    onClick={ (roomId) => setSelectedRoom(roomId) } />
                            ))
                        }
                        <Pagination 
                            className='pagination'
                            responsive
                            showSizeChanger={ false }
                            pageSize={ 25 }
                            total={ chatPreviewsCount }
                            onChange={ fetchPreviews } />
                    </div>
                </>
                :
                null
            }
            {
                selectedRoom 
                ? 
                <SupportChatRoomComponent 
                    roomId={ selectedRoom } 
                    connection={ connection } 
                    onLoad={ markMessagesAsRead }
                    updateLatestMessage={ updateMessagePreview } /> 
                : 
                null
            }
        </div>
        :
        <CustomSpin />
    )
}

const ChatPreview = ({ onClick, preview }) => {
    return (
        <div className='chat-item' onClick={ () => onClick(preview.roomId) }>
            <span className='latest-message'>{ preview.userName }: { preview.latestMessage }</span>
            {
                preview.totalUnReadMessages !== 0
                ?
                <span className='unread-counter'>{ preview.totalUnReadMessages }</span>
                :
                null
            }
        </div>
    )
}

export default SupportChatPage