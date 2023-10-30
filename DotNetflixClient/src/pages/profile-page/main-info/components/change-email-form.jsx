import { Form, Input, Button, Modal } from "antd"
import styles from "../MainInfo.module.sass"
import "../MainInfo.css"
import USettingsFooter from "./usettings-footer"
import Gen2FACodeSendField from "../functions/Gen2FACodeSendField"
import { useState } from "react"
import { useNavigate } from "react-router-dom"
import { axiosInstance } from "../../../../AxiosInstance"

const ChangeEmailForm = ({userData, setUserData}) => {
    
    const navigate = useNavigate()

    const [newEmail, setNewEmail] = useState('')
    const {content} = Gen2FACodeSendField('SendChangeMailToken', newEmail);
    const [showModal, setShowModal] = useState(false)

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

                    <Input onChange={e => setNewEmail(e.target.value)} />
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
                <p>Почта изменена!</p>
            </Modal>
        </>
    )

    function SendChangedData (values) {
        axiosInstance.put('api/User/SetUserMail', {
            email: values.email,
            token: values.code
        })
            .then(_ => {
                setUserData(_ => ({...userData, email: values.email}))
                setShowModal(true)
            })
            // TODO: catch error
            .catch(error => console.log(error))
    }
}

export default ChangeEmailForm