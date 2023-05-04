import { Modal } from "antd"
import { PaginationBlock } from "../../../../libs/pagination-block/PaginationBlock"
import { useState } from "react"
import { formatDate } from "../../../../libs/functions"

export const ActiveSubscriptionContent = ({subscription, showActiveSubscription, onCancel}) => {
    const [page, setPage] = useState(1)
    return (
        <Modal open={showActiveSubscription} footer={null} onCancel={() => {onCancel(); setPage(1)}}>
            {subscription && 
                <>
                    <div style={{fontSize: 18}}>
                        Тариф <b>{subscription.name}</b>
                    </div>
                    <div style={{display: 'flex', justifyContent: 'space-between'}}>
                        <span>Стоимость: <b>{subscription.cost} руб.</b></span>
                        {
                            subscription.expires !== undefined ?
                            <span>Действует 
                                {   subscription.expires ?
                                    <> до: <b>{formatDate(subscription.expires)}</b></> :
                                    <> <b>бессрочно</b></>}</span>:
                            <span>Офрмляется 
                                { subscription.periodInDays ?
                                    <> на <b>{subscription.periodInDays} дней</b></> :
                                    <> <b>навсегда</b></> }</span>
                        }
                    </div>
                    <div>
                        Доступные фильмы:
                        <PaginationBlock pageState={[page, setPage]} pageSize={10} paginationClassName="">
                            {subscription.filmNames.map((film, id) => (
                                <div key={id}>{film}</div>
                            ))}
                        </PaginationBlock>
                    </div>
                </>} 
        </Modal>
    )
}