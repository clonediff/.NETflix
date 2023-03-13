import { useNavigate } from "react-router-dom";
import { Button, Checkbox, Form, Input } from 'antd';
import styles from "./LoginForm.module.sass"
import { axiosInstance } from "../../../AxiosInstance"; 

export const LoginForm = () => {
    const navigate = useNavigate();

    const onFinish = (values) => {
        console.log('Success:', values);
        let username = values.username;
        let password = values.password;
        let remember = values.remember;
        /*axiosInstance.post("/login", {username, password, remember})
        .then((response) => alert(response))
        .catch(error => alert(error));*/
        //send request to server
        //navigate, if ok
    };
    const onFinishFailed = (errorInfo) => {
        console.log('Failed:', errorInfo);

    };

    return(<div className={styles.login}>
      <Form
      className={styles.login__form}
        layout="horizontal"
        name="netflix"
        labelCol={{
          span: 8,
        }}
        wrapperCol={{
          span: 16,
        }}
        initialValues={{
          remember: true,
        }}
        onFinish={onFinish}
        onFinishFailed={onFinishFailed}
        autoComplete="off"
      >
        <Form.Item
          label="Логин"
          name="username"
          rules={[
            {
              required: true,
              message: 'Пожалуйста, введите ваш логин!',
            },
          ]}
        >
          <Input /* onChange={e => setLogin(e.target.value)} *//>
        </Form.Item>
    
        <Form.Item
          label="Пароль"
          name="password"
          rules={[
            {
              required: true,
              message: 'Пожалуйста, введите ваш пароль!',
            },
          ]}
        >
          <Input.Password /* onChange={e => setPassword(e.target.value)} *//>
        </Form.Item>
    
        <Form.Item
        className={styles.item}
          name="remember"
          valuePropName="checked"
          wrapperCol={{
            offset: 8,
            span: 16,
          }}
        >
          <Checkbox /* onChange={(e) => setRemember(e.target.checked)} */>Запомнить меня</Checkbox>
        </Form.Item>
    
        <Form.Item
          className={styles.item}
          wrapperCol={{
            offset: 8,
            span: 16,
          }}
        >
          <Button type="primary" htmlType="submit">
            Войти
          </Button>
        </Form.Item>
      </Form>
    </div>
        );
}