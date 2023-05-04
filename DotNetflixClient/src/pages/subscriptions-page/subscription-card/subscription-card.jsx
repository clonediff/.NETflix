import { Button } from "antd"
import "./subscription-card.css"
import { axiosInstance } from "../../../AxiosInstance"
import { useEffect, useState } from "react"
import { useNavigate } from "react-router-dom"

export const SubscriptionCard = ({ subscription, setSelected, onBuy, onExtend }) => {
    const navigate = useNavigate()
    const [user, setUser] = useState(undefined)

    useEffect(() => {
        axiosInstance.get('api/user/getuser')
                .then(resp => resp.data)
                .then(data => setUser(data))
    }, [])

    return (
        <div className="subscription-card-wrapper">
            <div className="subscription-card-info"> 
                <div style={{marginTop: 5, fontSize: 20}}>Подписка <b>{subscription.name}</b></div>
                <div className="price-div">
                    <h3>{subscription.cost} ₽</h3>
                    <span><b>
                        { subscription.periodInDays ?
                            <>на {subscription.periodInDays} дней</> :
                            <>навсегда</>
                        }
                        </b></span>
                </div>
                <div className="movies-div">
                    Подключаемые фильмы:
                    <ul>
                        {subscription.filmNames
                        .slice(0, 3)
                            .map(movie => (
                            <li key={movie}>
                                {movie}
                            </li>
                        ))}
                        {
                            subscription.filmNames.length > 3 &&
                            <li>
                                <a className="pointer" onClick={setSelected}>и т.д.</a>
                            </li>
                        }
                    </ul>
                </div>
            </div>
            <Button type='primary' className="buy-btn" 
                onClick={
                    user ? 
                    (subscription.belongsToUser ? onExtend : onBuy) : 
                    () => navigate('/login')} 
                disabled={user === undefined || (subscription.periodInDays === null && subscription.belongsToUser)}>
                {
                    subscription.belongsToUser ?
                    'Продлить' :
                    'Оформить'
                }
            </Button>
        </div>
    )
}
