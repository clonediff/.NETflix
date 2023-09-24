import { Form, Input, Button, Modal } from "antd"
import styles from "../MainInfo.module.sass"
import "../MainInfo.css"
import USettingsFooter from "./usettings-footer"
import Gen2FACodeSendField from "../functions/Gen2FACodeSendField"
import { useNavigate } from "react-router-dom"
import { useState } from "react"
import { axiosInstance } from "../../../../AxiosInstance"

const ChangePassForm = () => {

    const navigate = useNavigate()

    const {content} = Gen2FACodeSendField();
    const [showModal, setShowModal] = useState(false)

    return(
        <>
            <Form className="settings-form" layout="vertical" onFinish={(values) => SendChangedData(values)}>
                <Form.Item
                    name="password"
                    label="Новый пароль"
                    rules={[
                    {
                        required: true,
                        message: 'Пожалуйста, введите пароль!',
                    },
                    ]}
                    hasFeedback>

                    <Input.Password />
                </Form.Item>

                <Form.Item
                    name="confirm"
                    label="Подтвердите пароль"
                    dependencies={['password']}
                    hasFeedback
                    rules={[
                    {
                        required: true,
                        message: 'Пожалуйста, подтвердите пароль!',
                    },
                    ({ getFieldValue }) => ({
                        validator(_, value) {
                        if (!value || getFieldValue('password') === value) {
                            return Promise.resolve();
                        }
                        return Promise.reject(new Error('Пароли должны совпадать!'));
                        },
                    }),
                    ]}>

                    <Input.Password />
                </Form.Item>
                <Form.Item >
                    {content}
                </Form.Item>
                <Form.Item className={styles.button}>
                    <Button className="settings-submit-button" type="primary" htmlType="submit">
                        Применить изменения
                    </Button>
                </Form.Item>
            </Form>
            
            <USettingsFooter linkDirection={'../change'} linkText={"Вернуться к основным настройкам"} />

            <Modal title=""
                open={showModal}
                footer={
                    <Button className="settings-submit-button" type="primary" onClick={() => navigate("../")}>Ok</Button>
                }>
                <p>Пароль изменён!</p>
            </Modal>
        </>
    )


    function SendChangedData (values) {
        axiosInstance.put('api/User/SetUserPassword', {
            password: values.password,
            code: values.code
        })
            .then(_ => {
                setShowModal(true)
            })
            // TODO: catch error
            .catch(error => console.log(error))
    }
}



export default ChangePassForm