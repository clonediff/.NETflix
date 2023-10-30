import { Link, useNavigate } from "react-router-dom";
import { Button,  Form, Input,DatePicker, Alert} from 'antd';
import { axiosInstance } from "../../../AxiosInstance"; 
import styles from "./RegistrationForm.module.sass"
import { useState } from "react";

export const RegistrationForm = () => {
    const navigator = useNavigate();
    const [form] = Form.useForm();
    const [errorMessage, setErrorMessage] = useState("");
    const [visible, setVisible] = useState(false);

    const onFinish = (values) => {
        let email = values.email;
        let password = values.password;
        let confirmPassword = values.confirm;
        let userName = values.nickname;
        let birthday = values.birthday;
        axiosInstance.post("Api/Auth/Register", 
        {
            email,
            password,
            confirmPassword, 
            userName,
            birthday
        })
          .then((response) => {
            console.log(response)
            navigator("/login")
          })
          .catch(error => {
            onFinishFailed(error.response.data)
          }
            );
        //navigate, if ok
    };

    const onFinishFailed = (errorMessage) => {
      setVisible(true);
      setErrorMessage(errorMessage);
    }

    const handleClose = () => {
      setVisible(false);
      setErrorMessage("");
    }
    
    return(<div className={styles.registration}>
    <Form
        className={styles.registration__form}
        layout="vertical"
        form={form}
        name="register"
        onFinish={onFinish}
        style={{maxWidth: 300}}
        scrollToFirstError
    >
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
      >
        <Input />
      </Form.Item>

      <Form.Item
        name="password"
        label="Пароль"
        rules={[
          {
            required: true,
            message: 'Пожалуйста, введите пароль!',
          },
        ]}
        hasFeedback
      >
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
        ]}
      >
        <Input.Password />
      </Form.Item>

      <Form.Item
        name="nickname"
        label="Логин"
        tooltip="Как вы хотите, чтобы вас называли другие пользователи?"
        rules={[
          {
            required: true,
            message: 'Пожалуйста, введите ваш логин!',
            whitespace: true,
          },
        ]}
      >
        <Input />
      </Form.Item>
      
      <Form.Item
      name="birthday" 
      label="Дата рождения"
      rules={[{
        required: true,
        message: "Пожалуйста, введите вашу дату рождения!",
      }]}>
          <DatePicker className={styles.birthday} format="YYYY-MM-DD"/>
      </Form.Item>

      {visible && <Alert classname={styles.alert} message={errorMessage} type="error" closable afterClose={handleClose} showIcon className={styles.errorMessage}></Alert>}
      <Form.Item className={styles.button}>
        <Button type="primary" htmlType="submit">
          Регистрация
        </Button>
      </Form.Item>
      <Form.Item>
        <label>Нажимая кнопку &quot;Регистрация&quot;, вы соглашаетесь с нашими <Link to="">Условиями использования</Link> и <Link to="">Политикой конфиденциальности</Link>.</label>
      </Form.Item>
    </Form>
    </div>);
}