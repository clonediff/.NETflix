import { useState, useEffect } from 'react'
import { Modal } from 'antd'
import { axiosInstance } from '../../clients'
import Subscription from './subscription'
import DataLayout from '../../data-layout/data-layout'
import '../../data-layout/data-layout.css'

const SubscriptionPage = () => {

    const [subscriptions, setSubscriptions] = useState([])
    const [searchedSubscriptions, setSearchedSubscriptions] = useState(null)
    const [isLoading, setIsLoading] = useState(true)
    const [page, setPage] = useState(1)
    const [subscriptionsCount, setSubscriptionsCount] = useState(0)

    const [modal, modalHolder] = Modal.useModal()
    
    const fetchSubscriptions = () => {
        axiosInstance.get(`api/subscription/getall?page=${page}`)
            .then(({ data }) => {
                setSubscriptions(data.data)
                setSubscriptionsCount(data.count)
                setIsLoading(false)
            })
    }

    useEffect(fetchSubscriptions, [page])
    
    const onPageChanged = (page, _) => {
        setPage(page)
    }
    
    const onSearch = (values) => {
        axiosInstance.get(`api/subscription/getall?name=${encodeURIComponent(values.name)}`)
            .then(({ data }) => {
                setSearchedSubscriptions(data.data)
                setSubscriptionsCount(data.count)
            })
    }

    const clearSearchedSubscriptions = () => {
        if (searchedSubscriptions) {
            setSearchedSubscriptions(null)
            setSubscriptionsCount(subscriptions.length)
        }
    }

    return (
        <DataLayout
            dataCount={ subscriptionsCount }
            isLoading={ isLoading }
            onPageChanged={ onPageChanged }
            onSearch={ onSearch }
            pageSize={ 25 }
            onSearchClear={ clearSearchedSubscriptions }
            searchPlaceholder='название подписки'>
            <div className='data-list'>
                {
                    (searchedSubscriptions ?? subscriptions).map(s => (
                        <Subscription 
                            key={ s.id } 
                            subscription={ s } 
                            modal={ modal } 
                            modalHolder={ modalHolder }
                            onChange={ fetchSubscriptions } />
                    ))
                }
            </div>
        </DataLayout>
    )
}

export default SubscriptionPage