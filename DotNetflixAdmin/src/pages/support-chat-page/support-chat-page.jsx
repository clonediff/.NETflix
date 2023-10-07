import { useEffect, useState } from 'react'
import { HttpTransportType, HubConnectionBuilder } from '@microsoft/signalr'
import { Pagination } from 'antd'
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
        setIsLoading(false)
    }, [])

    useEffect(() => {
        if (connection) {
            connection.start()
        }
    }, [connection])

    const fetchPreviews = (page, _) => {
        axiosInstance.get(`api/support-chat/preview/?page=${page}`)
            .then(({ data }) => {
                setChatPreviews(data.data)
                setChatPreviewsCount(data.count)
            })
    }

    return (
        !isLoading
        ?
        <div className='chat-container'>
            <div className='chat-previews'>
                {
                    chatPreviews.map(preview => (
                        <ChatPreview 
                            key={ preview.roomId }
                            preview={ preview }
                            onClick={ (roomId) => setSelectedRoom(roomId) } />
                    ))
                }
                {
                    chatPreviews.length !== 0
                    ?
                    <Pagination 
                        className='pagination'
                        responsive
                        showSizeChanger={ false }
                        pageSize={ 25 }
                        total={ chatPreviewsCount }
                        onChange={ fetchPreviews } />
                    :
                    null
                }
            </div>
            {
                selectedRoom ? <SupportChatRoomComponent roomId={ selectedRoom } connection={ connection } /> : null
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
            <span className='unread-counter'>{ preview.totalUnReadMessages }</span>
        </div>
    )
}

export default SupportChatPage