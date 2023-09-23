import { axiosInstance } from "../../../../AxiosInstance"
import { useState, useEffect } from "react"
import "../MainInfo.css"
import { Input, Form, Button } from "antd"

export default function Gen2FACodeSendField() {

    const [codeSend, setCodeSend] = useState(false)
    const [remainedToResend, setRemainedToResend] = useState(0)

    useEffect(() => {
        remainedToResend > 0 && setTimeout(() => setRemainedToResend(x => x - 1), 1000)
    }, [remainedToResend])

    const sendCode = () => {
        axiosInstance.get('api/TwoFactorAuth/SendCode')
            .then(_ => {
                setCodeSend(true)
                setRemainedToResend(120)
            })
            // TODO: catch error
            .catch(error => console.log(error))
    }

    let content = 
        <>            
            {
                codeSend &&
                <>
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
                </>
            }
            <Button className="settings-submit-button settings-form" 
                type="primary" 
                onClick={sendCode}
                disabled={remainedToResend !== 0}>Отправить код</Button>
        </>

    return {content}
}

function getTimeString(seconds){
    let minutes = ('0' + Math.floor(seconds/60)).slice(-2)
    let cseconds = ('0' + Math.floor(seconds % 60)).slice(-2)
    return `${minutes}:${cseconds}`
}