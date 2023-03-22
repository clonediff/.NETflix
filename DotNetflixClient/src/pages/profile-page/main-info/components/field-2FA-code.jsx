import { Form, Input, Button} from "antd"
import "../MainInfo.css"

const Field2FACode = () => {
    return(
        <>
            <Form.Item
                name="facode"
                label="Код подтверждения"
                rules={[
                {
                    required: true,
                    message: 'Пожалуйста, введите код подтверждения!',
                },
                ]}>
                <Input />
            </Form.Item>
            <Button className="settings-request-code" type="default" htmlType="button" onClick={SendCodeEmail}>Запросить код</Button>
        </>
    )
}

function SendCodeEmail () {
    //Логика запроса на сервер для отправки кода на почту
    console.log("Ok")
}

export default Field2FACode