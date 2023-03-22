import { Form, Input, Button } from "antd"
import styles from "../MainInfo.module.sass"
import "../MainInfo.css"
import USettingsFooter from "./usettings-footer"
import Field2FACode from "./field-2FA-code"

const ChangePassForm = () => {
    return(
        <>
            <Form className="settings-form" layout="vertical">
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
}

function SendChangedData (values) {

    
}

export default ChangePassForm