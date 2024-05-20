import { useNavigate } from "react-router-dom";
import { Alert, Button, Form, Input } from 'antd';
import "./login-page.css"
import { axiosInstance } from '../../clients'
import { useState } from "react";

export const LoginPage = () => {
  const [form] = Form.useForm();
  const navigate = useNavigate();
  const [errorMessage, setErrorMessage] = useState("");
  const [visible, setVisible] = useState(false);

    const onFinish = (values) => {
      console.log('Success:', values);
      let username = values.username;
      let password = values.password;
      axiosInstance.post("Api/AdminAuth/Login", 
      {
        username, 
        password, 
      })
        .then((response) => {
          console.log(response)
          localStorage.setItem('authenticated', true)
          navigate("/")
        })
        .catch(error => {
          onFinishFailed(error.response.data)
        });
      //send request to server
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
  
    return(
      <div style={{display: "flex", alignContent: "center", justifyContent: "center", alignItems: "center"}}>
        <div className="login">
        <Form
        className="login__form"
          layout="horizontal"
          name="netflix"
          form={form}
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
          
          {visible && <Alert classname="alert" message={errorMessage} type="error" closable afterClose={handleClose} showIcon className="errorMessage"></Alert>}

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
      </div>
      </div>);
}