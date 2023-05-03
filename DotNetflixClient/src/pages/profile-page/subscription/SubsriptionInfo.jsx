import { useEffect, useState } from "react"
import { ActiveSubscriptionContent } from "./active-subscription-content/ActiveSubscriptionContent"
import { ExpandableBlock } from "../../../libs/expandable-block/ExpandableBlock"
import "./subscriptions.css"
import USettingsFooter from "../main-info/components/usettings-footer"
import { axiosInstance } from "../../../AxiosInstance"

export const SubscriptionInfo = ({ userData }) => {
    const [subscriptions, setSubscriptions] = useState([])
    const [showActiveSubscription, setShowActiveSubscription] = useState(false)
    const [selectedAS, setSelectedAS] = useState(undefined)

    const tempDict = {
        '1': {
            movies: ['film1', 'film2', 'film3'],
            cost: 50
        },
        '2': {
            movies: ['film1', 'film3', 'film5', 'film7'],
            cost: 30
        },
        '3': {
            movies: ['film1', 'film3', 'film5', 'film7'],
            cost: 30
        },
        '4': {
            movies: ['film1', 'film3', 'film5', 'film7'],
            cost: 30
        },
        '5': {
            movies: ['film1', 'film3', 'film5', 'film7'],
            cost: 30
        },
        '6': {
            movies: ['film1', 'film3', 'film5', 'film7'],
            cost: 30
        },
        '7': {
            movies: ['film1', 'film3', 'film5', 'film7'],
            cost: 30
        }
    }

    useEffect(() => {
        axiosInstance.get(`userSubscriptionsBrief?userId=${userData.id}`)
            .then(response => response.data)
            // subscription: id, name, to
            .then(data => setSubscriptions(data))
        setSubscriptions(x => ([
                {
                    id: 1,
                    name: 'simple',
                    to: '01.05.2023'
                },
                {
                    id: 2,
                    name: 'complex',
                    to: '02.05.2023'
                },
                {
                    id: 3,
                    name: 'complex',
                    to: '02.05.2023'
                },
                {
                    id: 4,
                    name: 'complex',
                    to: '02.05.2023'
                },
                {
                    id: 5,
                    name: 'complex',
                    to: '02.05.2023'
                },
                {
                    id: 6,
                    name: 'complex',
                    to: '02.05.2023'
                },
                {
                    id: 7,
                    name: 'complex',
                    to: '02.05.2023'
                }
            ]))
    }, [])

    function setSelected(subscription){
        // axiosInstance.get(`subscriptionById?id=${subscription.id}`)
        //     .then(response => response.data)
        //     .then(data => setSelectedAS(data))
        setSelectedAS({
            ...subscription,
            ...tempDict[subscription.id]
        })
        setShowActiveSubscription(true)
    }

    function onCanel(){
        setShowActiveSubscription(false)
        setSelectedAS(undefined)
    }

    return (
        <>
            <ActiveSubscriptionContent subscription={selectedAS} 
                showActiveSubscription={showActiveSubscription}
                onCancel={onCanel}/>
            {
                subscriptions.length > 0 &&
                <>
                    <p>Активные подписки:</p>
                    <ExpandableBlock length={5} >
                        {subscriptions.map(subscription => (
                            <div className="subscription-div" key={subscription.id}>
                                <a className="pointer" 
                                    style={{display: 'flex', justifyContent: 'space-between', padding: '3px 10px'}} 
                                    onClick={() => setSelected(subscription)}>
                                    <span>{subscription.name}</span>
                                    {
                                        subscription.to ?
                                        <span>Действует до {subscription.to}</span>:
                                        <span>Действует бессрочно</span>
                                    }
                                </a>
                            </div>))}
                    </ExpandableBlock>
                </>
            }
            <USettingsFooter linkDirection="/subscriptions" linkText="Информацию о других подписках можно посмотреть здесь"/>
        </>)
}