import CommonLayout from '../../layouts/common-layout/common-layout'
import { useEffect, useState } from 'react'
import { ActiveSubscriptionContent } from '../profile-page/subscription/active-subscription-content/ActiveSubscriptionContent'
import { SubscriptionCard } from './subscription-card/subscription-card'
import { PaymentForm } from '../profile-page/main-info/components/payment-form/payment-form'
import { axiosInstance } from '../../AxiosInstance'
import { Modal } from 'antd'

export const SubscriptionsPage = () => {

    const [subscriptions, setSubscriptions] = useState([])

    useEffect(() => {
        axiosInstance.get('api/subscription/GetAllSubscriptions')
            .then(response => response.data)
            // subscription: id, name, cost, periodInDays, filmNames
            .then(data => setSubscriptions(data))
    }, [])

    const [selectedSubscription, setSelectedSubscription] = useState(undefined)
    const [showActiveSubscription, setShowActiveSubscription] = useState(false)

    const [buyModalSubscription, setBuyModalSubscription] = useState(undefined)
    const [showBuyModal, setShowBuyModal] = useState(false)

    const [onBuy, setOnBuy] = useState(undefined)
    const [modal, modalHolder] = Modal.useModal()

    const setSelected = (subscription) => {
        setSelectedSubscription(subscription)
        setShowActiveSubscription(true)
    }

    const onCancel = () => {
        setSelectedSubscription(undefined)
        setShowActiveSubscription(false)
    }

    const setBuySubsription = (subscription) => {
        setBuyModalSubscription(subscription)
        setOnBuy(_ => (data) => 
            axiosInstance.post(`api/Subscription/Purchase?subscriptionId=${data.prodId}`, data)
                .then(resp => resp.data)
                .then(_ => {
                    modal.success({
                        title: 'Подписка успешно оформлена',
                        onOk: () => {
                            onBuyModalCancel()
                            setSubscriptions(x => x.map(item => 
                                (item.id === subscription.id ?
                                    {...item, belongsToUser: true} :
                                    item)))
                        },
                        zIndex: 10001
                    })
                })
                .catch(err => {
                    modal.error({
                        title: `Не удалось оформить подписку. ${err.response.data}`,
                        zIndex: 10001
                    })
                }))
        setShowBuyModal(true)
    }

    const setExtendSubscription = (subscription) => {
        setBuyModalSubscription(subscription)
        setOnBuy(_ => (data) => 
            axiosInstance.put(`api/Subscription/Extend?subscriptionId=${data.prodId}`, data)
                .then(resp => resp.data)
                .then(_ => modal.success({
                    title: `Подписка успешно продлена ещё на ${subscription.periodInDays} дней`,
                    onOk: () => {
                        onBuyModalCancel()
                    },
                    zIndex: 10001
                }))
                .catch(err => {
                    modal.error({
                        title: `Не удалось продлить подписку. ${err.response.data}`,
                        zIndex: 10001
                    })
                }))
        setShowBuyModal(true)
    }

    const onBuyModalCancel = () => {
        setShowBuyModal(false)
        setBuyModalSubscription(undefined)
        setOnBuy(undefined)
    }

    return (
        <CommonLayout>  
            {modalHolder}
            <ActiveSubscriptionContent subscription={selectedSubscription} 
                showActiveSubscription={showActiveSubscription}
                onCancel={onCancel}/>
            <PaymentForm Product={buyModalSubscription} Show={showBuyModal} onCancel={onBuyModalCancel} 
                onBuy={onBuy}/>
            
            <div style={{display: 'flex', justifyContent: 'center', flexWrap: 'wrap', padding: '0 80px'}}>
                {
                    subscriptions.map(subscription => 
                        <SubscriptionCard key={subscription.id} 
                            subscription={subscription}
                            setSelected={() => setSelected(subscription)}
                            onBuy={() => setBuySubsription(subscription)}
                            onExtend={() => setExtendSubscription(subscription)}/>)
                }
            </div>
        </CommonLayout>
    )
}