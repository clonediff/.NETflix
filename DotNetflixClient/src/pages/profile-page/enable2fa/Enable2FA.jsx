import USettingsFooter from "../main-info/components/usettings-footer"
import { TitleValue } from "../title-value/TitleValue"
import { axiosInstance } from "../../../AxiosInstance"
import { useEffect, useState } from "react"
import "../main-info/MainInfo.css"
import { Input, Form, Button, Modal } from "antd"
import { useNavigate } from "react-router-dom"

export const Enable2FA = ({user, setUser}) => {

    const navigate = useNavigate()

    const [codeSend, setCodeSend] = useState(false)
    const [remainedToResend, setRemainedToResend] = useState(0)
    const [showModal, setShowModal] = useState(false)

    useEffect(() => {
        remainedToResend > 0 && setTimeout(() => setRemainedToResend(x => x - 1), 1000)
    }, [remainedToResend])

    const sendCode = () => {
        axiosInstance.get('api/Token/Send2FAToken')
            .then(_ => {
                setCodeSend(true)
                setRemainedToResend(120)
            })
            // TODO: catch error
            .catch(error => console.log(error))
    }

    const sendEnableRequest = (val) => {
        axiosInstance.post('api/User/Enable2FA', {
            token: val.code
        })
            .then(_ => {
                setUser(x => ({...x, enabled2FA: true}))
                setShowModal(true)
            })
            // TODO: catch error
            .catch(error => console.log(error))
    }

    const handleOk = () => {
        navigate("../")
    }

    return (
    <>
        <TitleValue title="Email" value={user.email}/>
        <Button className="settings-submit-button settings-form" 
            type="primary" 
            onClick={sendCode}
            disabled={remainedToResend !== 0}>Отправить код</Button>
        {
            codeSend &&
            <Form onFinish={sendEnableRequest}
                className="settings-form"
                layout="vertical">
                <Form.Item
                    label="Код"
                    name="code"
                    rules={[
                        {
                            required: true,
                            message: 'Введите код из email'
                        }
                    ]}
                    style={{marginBottom: 0}}>
                        <Input autoComplete="off"/>
                </Form.Item>
                {   remainedToResend ?
                    <span>Повторно запросить код через {getTimeString(remainedToResend)}</span> :
                    <span>Можно запросить код повторно</span>
                }
                <Form.Item>
                    <Button className="settings-submit-button" type="primary" htmlType="submit">Подтвердить</Button>
                </Form.Item>
            </Form>
        }
        <USettingsFooter linkDirection="../" linkText="Вернуться к информации о пользователе"/>
        <Modal title=""
                open={showModal}
                footer={
                    <Button className="settings-submit-button" type="primary" onClick={handleOk}>Ok</Button>
                }>
            <p>Двухфакторная аутентификация подключена</p>
        </Modal>
    </>)
}

function getTimeString(seconds){
    let minutes = ('0' + Math.floor(seconds/60)).slice(-2)
    let cseconds = ('0' + Math.floor(seconds % 60)).slice(-2)
    return `${minutes}:${cseconds}`
}