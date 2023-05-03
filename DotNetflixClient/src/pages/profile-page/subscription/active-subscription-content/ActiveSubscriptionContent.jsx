import { Modal } from "antd"
import { PaginationBlock } from "../../../../libs/pagination-block/PaginationBlock"
import { useState } from "react"

export const ActiveSubscriptionContent = ({subscription, showActiveSubscription, onCancel}) => {
    const [page, setPage] = useState(1)
    return (
        <Modal open={showActiveSubscription} footer={null} onCancel={onCancel}>
            {subscription && 
                <>
                    <div style={{fontSize: 18}}>
                        Тариф <b>{subscription.name}</b>
                    </div>
                    <div style={{display: 'flex', justifyContent: 'space-between'}}>
                        <span>Стоимость: <b>{subscription.cost} руб.</b></span>
                        {
                            subscription.to ?
                            <span>Действует до: <b>{subscription.to}</b></span>:
                            <span>Офрмляется на <b>
                                { subscription.duration ?
                                    <>{subscription.duration} дней</> :
                                    <>бессрочно</> }</b></span>
                        }
                    </div>
                    <div>
                        Доступные фильмы:
                        <PaginationBlock pageState={[page, setPage]} pageSize={10} paginationClassName="">
                            {subscription.movies.map((film, id) => (
                                <div key={id}>{film}</div>
                            ))}
                        </PaginationBlock>
                    </div>
                </>} 
        </Modal>
    )
}