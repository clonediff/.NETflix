import { useEffect, useState } from 'react'
import BurgerMenu from '../main-page/burger-menu/burger-menu'
import BurgerPanel from '../main-page/burger-panel/burger-panel'
import Header from '../main-page/header/header'
import { ActiveSubscriptionContent } from '../profile-page/subscription/active-subscription-content/ActiveSubscriptionContent'
import { SubscriptionCard } from './subscription-card/subscription-card'
import { PaymentForm } from '../profile-page/main-info/components/payment-form/payment-form'
import { axiosInstance } from '../../AxiosInstance'

export const SubscriptionsPage = () => {

    const [subscriptions, setSubscriptions] = useState([
        {
            id: 1,
            name: 'simple',
            cost: 50,
            duration: 60,
            movies: ['film1', 'film2', 'film3'],
        },
        {
            id: 2,
            name: 'complex',
            cost: 30,
            duration: 30,
            movies: ['film1', 'film3', 'film5', 'film7'],
        }
    ])

    useEffect(() => {
        /*
        axiosInstance.get('subscriptions')
            .then(response => response.data)
            .then(data => setSubscriptions(data))
        */
    }, [])

    const [selectedSubscription, setSelectedSubscription] = useState(undefined)
    const [showActiveSubscription, setShowActiveSubscription] = useState(false)

    const [buyModalSubscription, setBuyModalSubscription] = useState(undefined)
    const [showBuyModal, setShowBuyModal] = useState(false)

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
        setShowBuyModal(true)
    }

    const onBuyModalCancel = () => {
        setShowBuyModal(false)
        setBuyModalSubscription(undefined)
    }

    return (
    <>
        <BurgerMenu />
        <BurgerPanel />
        <Header />
        <ActiveSubscriptionContent subscription={selectedSubscription} 
            showActiveSubscription={showActiveSubscription}
            onCancel={onCancel}/>
        <PaymentForm Product={buyModalSubscription} Show={showBuyModal} onCancel={onBuyModalCancel}/>
        
        <div style={{display: 'flex', justifyContent: 'center', flexWrap: 'wrap', padding: '0 80px'}}>
            {
                subscriptions.map(subscription => 
                    <SubscriptionCard key={subscription.id} 
                        subscription={subscription}
                        setSelected={() => setSelected(subscription)}
                        onBuy={() => {setBuySubsription(subscription)}}/>)
            }
        </div>
    </>)
}