import { Form, Input, Button, DatePicker, Modal } from "antd"
import { TitleValue } from "../../../title-value/TitleValue"
import "./payment-form.css"

export const PaymentForm = ({Product, Show, SetShow}) => {

    // Product structure: Cost, Name, Id
    return(
        <Modal className="payment-modal" open={Show} closable="false" footer={ null } onCancel={() => { SetShow(false) }}>
            <Form className="payment-form" layout="vertical">
                <Form.Item
                    style={{color: "white"}}
                    label="Номер карты"
                    name="cardnum"
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
                    name="validtime"
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
                <Form.Item name="prodId" initialValue={Product.Id} style={{height: "0px", width: "0px", margin: "0px"}}/>
                <TitleValue title={"Товар"} value={Product.Name}></TitleValue>
                <TitleValue title={"Цена"} value={Product.Cost}></TitleValue>
                <Form.Item style={{display: "flex", justifyContent: "center"}}>
                    <Button type="primary">Подтвердить</Button>
                </Form.Item>
            </Form>
        </Modal>)
}