import { Form, Input, Button, DatePicker } from "antd"
import { Link} from "react-router-dom"
import styles from "../MainInfo.module.sass"
import "../MainInfo.css"
import moment from 'moment'
import USettingsFooter from "./usettings-footer"
import React from "react"

const ChangeUSettingsForm = ({userData, setUserData }) => {  
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
                <Input />
                </Form.Item>
            
                <Form.Item
                name="birthday" 
                label="Дата рождения"
                rules={[{
                    required: true,
                    message: "Пожалуйста, введите вашу дату рождения!",
                }]}
                initialValue = {moment(userData.birthdate)}>
                    
                    <DatePicker className={styles.birthday} format="YYYY-MM-DD"/>                    
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
        </>
    )


    function SendChangedData (values) {

        let stringDate = values.birthday._i === undefined? NormalizeDate(values.birthday) : values.birthday._i

        let bodyFormData = new FormData();

        bodyFormData.append('username', values.username)
        bodyFormData.append('birthday', stringDate)

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
        copy.login = values.username
        copy.birthdate = stringDate

        setUserData(copy)
    }
}

function NormalizeDate(date){
    let year = date.$y
    let month = date.$M + 1
    let day = date.$D

    return `${year}.${div(month, 10) === 0? '0' + month : month}.${div(day, 10) === 0? '0' + day : day}`

    function div(val, by){
        return (val - val % by) / by;
    }
}

export default ChangeUSettingsForm