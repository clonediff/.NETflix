import { Form, Input, Button, DatePicker, Modal } from "antd"
import { Link, useNavigate } from "react-router-dom"
import styles from "../MainInfo.module.sass"
import "../MainInfo.css"
import USettingsFooter from "./usettings-footer"
import { axiosInstance } from "../../../../AxiosInstance"
import { useState } from "react"

const ChangeUSettingsForm = ({userData, setUserData }) => {  
    
    const navigate = useNavigate()
    
    const [dateChange, setDateChange]= useState(false)
    const [loginChange, setLoginChange]= useState(false)
    const [showModal, setShowModal] = useState(false)

    return(
        <>
            <Form className="settings-form" layout="vertical" onFinish={(values) => SendChangedData(values)}>
                <Form.Item
                label="Логин"
                name="username"
                rules={[
                    {
                    required: true,
                    message: 'Пожалуйста, введите ваш логин!',
                    },
                ]}
                initialValue = {userData.login}>
                    {loginChange?
                        <Input />:
                        <div style={{display:"flex", backgroundColor:"white", maxWidth:"276px", height:"22px", border:"1px solid #d9d9d9", borderRadius:"6px", padding:"4px 11px 4px", lineHeight:"1.5714285714285714", justifyContent:"space-between"}}>
                            {userData.login != undefined && userData.login}
                            <svg style={{display:"flex"}} width="20px" height="20px" viewBox="0 0 24 24" data-name="24x24/On Light/Edit" xmlns="http://www.w3.org/2000/svg" onClick={() => setLoginChange(!loginChange)}>
                                <rect id="view-box" width="24" height="24" fill="none"/>
                                <path id="Shape" d="M.75,17.5A.751.751,0,0,1,0,16.75V12.569a.755.755,0,0,1,.22-.53L11.461.8a2.72,2.72,0,0,1,3.848,0L16.7,2.191a2.72,2.72,0,0,1,0,3.848L5.462,17.28a.747.747,0,0,1-.531.22ZM1.5,12.879V16h3.12l7.91-7.91L9.41,4.97ZM13.591,7.03l2.051-2.051a1.223,1.223,0,0,0,0-1.727L14.249,1.858a1.222,1.222,0,0,0-1.727,0L10.47,3.91Z" transform="translate(3.25 3.25)" fill="black"/>
                            </svg> 
                        </div>
                    }                
                </Form.Item>
            
                <Form.Item
                name="birthday" 
                label="Дата рождения">
                    {dateChange?
                        <DatePicker className={styles.birthday} format="YYYY-MM-DD"/>:
                        <div style={{display:"flex", backgroundColor:"white", maxWidth:"136px", height:"22px", border:"1px solid #d9d9d9", borderRadius:"6px", padding:"4px 11px 4px", lineHeight:"1.5714285714285714", justifyContent:"space-between"}}>
                            {userData.birthdate != undefined && userData.birthdate.toString().split('T')[0]}
                            <svg style={{display:"flex"}} width="20px" height="20px" viewBox="0 0 24 24" data-name="24x24/On Light/Edit" xmlns="http://www.w3.org/2000/svg" onClick={() => setDateChange(!dateChange)}>
                                <rect id="view-box" width="24" height="24" fill="none"/>
                                <path id="Shape" d="M.75,17.5A.751.751,0,0,1,0,16.75V12.569a.755.755,0,0,1,.22-.53L11.461.8a2.72,2.72,0,0,1,3.848,0L16.7,2.191a2.72,2.72,0,0,1,0,3.848L5.462,17.28a.747.747,0,0,1-.531.22ZM1.5,12.879V16h3.12l7.91-7.91L9.41,4.97ZM13.591,7.03l2.051-2.051a1.223,1.223,0,0,0,0-1.727L14.249,1.858a1.222,1.222,0,0,0-1.727,0L10.47,3.91Z" transform="translate(3.25 3.25)" fill="black"/>
                            </svg> 
                        </div>
                    }                    
                      
                </Form.Item>

                <Form.Item className={styles.button}>
                    <Button className="settings-submit-button" type="primary" htmlType="submit">
                        Применить изменения
                    </Button>
                </Form.Item>
            </Form>
            {userData.enabled2FA ? 
                    <div className="settings-tfa-enabled">
                        <Link className="settings-link" to="./email">
                            Изменить почту
                        </Link>
                        <Link className="settings-link" to="./pass">
                            Изменить пароль
                        </Link>
                    </div>
                :"Подключите двухфакторную аутентификацию чтобы сменить пароль или почту"}
            <USettingsFooter linkDirection={'../'} linkText={"Вернуться к информации о пользователе"} />

            <Modal title=""
                open={showModal}
                footer={
                    <Button className="settings-submit-button" type="primary" onClick={() => navigate("../")}>Ok</Button>
                }>
                <p>Данные сохранены</p>
            </Modal>
        </>
    )


    function SendChangedData (values) {

        axiosInstance.put('api/User/SetUserData', {
            birthdate : values.birthday === undefined? userData.birthdate : values.birthday.$d,
            username: values.username
        })
            .then(_ => {
                setUserData(_ => ({...userData, login: values.username, birthdate: values.birthday === undefined? userData.birthdate : values.birthday.$d}))
                setShowModal(true)
            })
            // TODO: catch error
            .catch(error => console.log(error))
    }
}

export default ChangeUSettingsForm