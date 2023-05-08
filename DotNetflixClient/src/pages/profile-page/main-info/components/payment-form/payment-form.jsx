import { Form, Input, Button, DatePicker, Modal } from "antd"
import { TitleValue } from "../../../title-value/TitleValue"
import "./payment-form.css"

export const PaymentForm = ({Product, Show, onCancel, onBuy}) => {

    // Product structure: Cost, Name, Id
    return(
        <Modal className="payment-modal" open={Show} closable="false" footer={ null } onCancel={onCancel}>
            { Product &&
                <Form className="payment-form" layout="vertical"
                    onFinish={onBuy}>
                    <Form.Item
                        style={{color: "white"}}
                        label="Номер карты"
                        name="cardnumber"
                        rules={[
                            {
                            required: true,
                            message: 'Пожалуйста, введите номер вашей карты!',
                            },]}>

                        <Input type="number" />
                    </Form.Item>
                    <Form.Item
                        label="Владелец карты"
                        name="cardholder"
                        rules={[
                            {
                            required: true,
                            message: 'Пожалуйста, введите имя и фамилию владельца карты!',
                            },]}>

                        <Input />
                    </Form.Item>
                    <Form.Item
                        label="Срок действия"
                        name="expirationDate"
                        rules={[
                            {
                            required: true,
                            message: 'Пожалуйста, введите срок действия карты!',
                            },]}>

                        <DatePicker format="MM-YYYY"/>
                    </Form.Item>
                    <Form.Item
                        style={{width: "80px"}}
                        label="CVV/CVC"
                        name="CVV_CVC"
                        rules={[
                            {
                                required: true,
                                message: 'Пожалуйста, введите трехзначный код на обратной стороне карты!',
                            },
                            {
                                max: 3,
                                min: 3,
                                message: 'Введите 3 цифры',
                            }]}>
                                
                        <Input type="number" />
                    </Form.Item>
                    <Form.Item name="prodId" initialValue={Product.id} style={{height: "0px", width: "0px", margin: "0px"}}/>
                    <TitleValue title={"Товар"} value={Product.name}></TitleValue>
                    <TitleValue title={"Цена"} value={Product.cost}></TitleValue>
                    <Form.Item style={{display: "flex", justifyContent: "center"}}>
                        <Button type="primary" htmlType="submit">Подтвердить</Button>
                    </Form.Item>
                </Form>
            }
        </Modal>)
}