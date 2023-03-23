import { Form, Input, Button } from "antd"
import styles from "../MainInfo.module.sass"
import "../MainInfo.css"
import USettingsFooter from "./usettings-footer"
import Field2FACode from "./field-2FA-code"

const ChangeEmailForm = ({userData, setUserData}) => {
    return(
        <>
            <Form className="settings-form" layout="vertical" onFinish={(values) => {SendChangedData(values)}}>
                <Form.Item
                    name="email"
                    label="Электронная почта"
                    rules={[
                    {
                        type: 'email',
                        message: 'Введённые данные не соответствуют электронной почте!',
                    },
                    {
                        required: true,
                        message: 'Пожалуйста, введите электронную почту!',
                    },
                    ]}
                    initialValue = {userData.email}>

                    <Input />
                </Form.Item>
                <Form.Item >
                    <Field2FACode/>
                </Form.Item>
                <Form.Item className={styles.button}>
                    <Button className="settings-submit-button" type="primary" htmlType="submit">
                        Применить изменения
                    </Button>
                </Form.Item>             
            </Form>
            <USettingsFooter linkDirection={'../change'} linkText={"Вернуться к основным настройкам"} />
        </>
    )

    function SendChangedData (values) {

        console.log(values)

        let bodyFormData = new FormData();

        bodyFormData.append('email', values.email)
        bodyFormData.append('fadata', values.fadata)

        /*axiosInstance({
        method: "post",
        url: "/calc", //поменять
        data: bodyFormData,
        headers: { "Content-Type": "multipart/form-data" },
        })
        .then(function (response) {
            setRes(response.data)
        })
        .catch(function (response) {
            //handle error
            console.log(response);
        });*/

        //если успех
        let copy = { ...userData }
        copy.email = values.email
        
        setUserData(copy)
    }
}

export default ChangeEmailForm