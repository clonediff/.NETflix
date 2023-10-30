import SimpleLayout from "../../../layouts/simple-layout/simple-layout";
import { Link } from "react-router-dom";
import { LoginForm } from "../login-form/LoginForm";
import styles from "./LoginPage.module.sass"

export const LoginPage = () => {
    
//TODO сделать адаптивную вёрстку

    return(
        <div className={styles.login_page}>
            <SimpleLayout>
                <div className={styles.login}>
                    <div className={styles.login_wrapper}>
                        <LoginForm></LoginForm>
                        <p>Впервые на ДотНЕТфликс? <Link className={styles.link} to="/registration">Регистрация</Link></p>
                    </div>
                </div>
            </SimpleLayout>
        </div>
    );
}