import { Link } from "react-router-dom";
import Header from "../../main-page/header/header";
import { LoginForm } from "../login-form/LoginForm";
import styles from "./LoginPage.module.sass"

export const LoginPage = () => {
    
//TODO сделать адаптивную вёрстку

    return(
    <div className={styles.login_page}>
        <Header>
        </Header>
        <div className={styles.login}>
            <div className={styles.login_wrapper}>
                <LoginForm></LoginForm>
                <p>Впервые на ДотНЕТфликс? <Link className={styles.link} to="/registration">Регистрация</Link></p>
            </div>
        </div>
    </div>
    );
}