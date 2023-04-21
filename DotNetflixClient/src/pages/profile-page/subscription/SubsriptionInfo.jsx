import { useState } from "react"
import { PaymentForm } from "../main-info/components/payment-form/payment-form"

export const SubscriptionInfo = () => {
    const [showModal, setShowModal] = useState(false)
    return (
        <>
        <p>Пока здесь пусто</p>
        <PaymentForm Product={{"Cost": 23, "Name": "Simple", "Id": 0}} Show={showModal} SetShow={setShowModal}></PaymentForm>
        <button onClick={()=>{setShowModal(true)}}></button>
    </>)
}