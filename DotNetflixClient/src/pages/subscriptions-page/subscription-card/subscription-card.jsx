import { Button } from "antd"
import "./subscription-card.css"

export const SubscriptionCard = ({ subscription, setSelected, onBuy }) => {

    return (
        <div className="subscription-card-wrapper">
            <div className="subscription-card-info"> 
                <div style={{marginTop: 5, fontSize: 20}}>Подписка <b>{subscription.name}</b></div>
                <div className="price-div">
                    <h3>{subscription.cost} ₽</h3>
                    <span><b>
                        { subscription.duration ?
                            <>за {subscription.duration} дней</> :
                            <>за всегда</>
                        }
                        </b></span>
                </div>
                <div className="movies-div">
                    Подключаемые фильмы:
                    <ul>
                        {subscription.movies
                        .slice(0, 3)
                            .map(movie => (
                            <li key={movie}>
                                {movie}
                            </li>
                        ))}
                        {
                            subscription.movies.length > 3 &&
                            <li>
                                <a className="pointer" onClick={setSelected}>и т.д.</a>
                            </li>
                        }
                    </ul>
                </div>
            </div>
            <Button type='primary' className="buy-btn" onClick={onBuy} >Оформить</Button>
        </div>
    )
}