import { useEffect, useState } from "react"
import { ActiveSubscriptionContent } from "./active-subscription-content/ActiveSubscriptionContent"
import { ExpandableBlock } from "../../../libs/expandable-block/ExpandableBlock"
import "./subscriptions.css"
import USettingsFooter from "../main-info/components/usettings-footer"
import { axiosInstance } from "../../../AxiosInstance"
import { formatDate } from "../../../libs/functions"

export const SubscriptionInfo = () => {
    const [subscriptions, setSubscriptions] = useState([])
    const [showActiveSubscription, setShowActiveSubscription] = useState(false)
    const [selectedAS, setSelectedAS] = useState(undefined)

    useEffect(() => {
        axiosInstance.get(`api/user/GetAllUserSubscriptions`)
            .then(response => response.data)
            // subscription: id, name, to, cost
            .then(data => {
                setSubscriptions(data)
            })
    }, [])

    function setSelected(subscription){
        axiosInstance.get(`api/subscription/GetAllFilmNames?subscriptionId=${subscription.id}`)
            .then(response => response.data)
            .then(data => {
                setSelectedAS({...subscription, filmNames: data})
                setShowActiveSubscription(true)
            })
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
                                    <span>{subscription.subscriptionName}</span>
                                    {
                                        subscription.expires ?
                                        <span>Действует до {formatDate(subscription.expires)}</span>:
                                        <span>Действует бессрочно</span>
                                    }
                                </a>
                            </div>))}
                    </ExpandableBlock>
                </>
            }
            <USettingsFooter linkDirection="/subscriptions" linkText={`Информацию о ${subscriptions.length > 0 ? 'других' : ''} подписках можно посмотреть здесь`}/>
        </>)
}
