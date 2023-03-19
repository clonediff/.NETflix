import { Link, useNavigate } from "react-router-dom";
import { Button,  Form, Input, InputNumber,DatePicker, Space } from 'antd';
import { axiosInstance } from "../../../AxiosInstance"; 
import styles from "./RegistrationForm.module.sass"


export const RegistrationForm = () => {
    const [form] = Form.useForm();
    const onFinish = (values) => {
        let email = values.email;
        let password = values.password;
        let nickname = values.nickname;
        let birthday = values.birthday;
        /*axiosInstance.post("/login", {email, password, nickname, age})
        .then((response) => alert(response))
        .catch(error => alert(error));*/
        //navigate, if ok
    };
    
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
        <Space direction="vertical">
          <DatePicker className={styles.birthday} format="YYYY-MM-DD"/>
        </Space>
      </Form.Item>

      <Form.Item className={styles.button}>
        <Button type="primary" htmlType="submit">
          Регистрация
        </Button>
      </Form.Item>
      <Form.Item>
        <label>Нажимая кнопку "Регистрация", вы соглашаетесь с нашими <Link to="">Условиями использования</Link> и <Link to="">Политикой конфиденциальности</Link>.</label>
      </Form.Item>
    </Form>
    </div>);
}