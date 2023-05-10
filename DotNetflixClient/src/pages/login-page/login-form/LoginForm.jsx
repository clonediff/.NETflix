import { useNavigate } from "react-router-dom";
import { Button, Checkbox, Form, Input } from 'antd';
import styles from "./LoginForm.module.sass"
import { axiosInstance } from "../../../AxiosInstance"; 
import { useCallback, useEffect } from "react";
import GoogleButton from 'react-google-button';

const { REACT_APP_GOOGLE_CLIENT_ID, REACT_APP_BASE_BACKEND_URL } = process.env;

export const LoginForm = () => {
    const navigate = useNavigate();

    const onFinish = (values) => {
        console.log('Success:', values);
        let username = values.username;
        let password = values.password;
        let remember = values.remember;
        axiosInstance.post("Api/Auth/Login", 
        {
          username, 
          password, 
          remember
        })
          .then((response) => {
            console.log(response)
            localStorage.setItem('authenticated', true)
            navigate("/")
          })
          .catch(error => console.log(error));
        //send request to server
        //navigate, if ok
    };
    
    const onFinishFailed = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    const openGoogleLoginPage = useCallback(() => {
      const googleAuthUrl = 'https://accounts.google.com/o/oauth2/v2/auth';
      const redirectUri = 'api/oauth/google';
  
      const scope = ['https://www.googleapis.com/auth/userinfo.profile',
       'https://www.googleapis.com/auth/userinfo.email'].join(' ');
  
      const params = {
        response_type: 'code',
        client_id: REACT_APP_GOOGLE_CLIENT_ID,
        redirect_uri: `${REACT_APP_BASE_BACKEND_URL}/${redirectUri}`,
        prompt: 'select_account',
        access_type: 'offline',
        scope
      };
  
      const urlParams = new URLSearchParams(params).toString();
  
      window.location = `${googleAuthUrl}?${urlParams}`;

      localStorage.setItem('authenticated', true)
    }, []);

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
      <div className={styles.socials}>
          Или
          <GoogleButton
          style={{width: "13em", fontSize: "14px"}}
          onClick={openGoogleLoginPage}
          label="Sign in with Google">
          </GoogleButton>
        </div>
    </div>
        );
}