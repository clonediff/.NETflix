import { Link } from "react-router-dom";
import styles from "./RegistrationPage.module.sass"
import { RegistrationForm } from "../registration-form-container/RegistrationForm";
import Header from "../../main-page/header/header";

export const RegistrationPage = () => {
    return(
        <div className={styles.registration_page}>
            <Header>
            </Header>
            <div className={styles.registration}>
                <div className={styles.registration_wrapper}>
                    <RegistrationForm></RegistrationForm>
                    <p>Есть аккаунт? <Link className={styles.link} to="/login">Авторизация</Link></p>
                </div>
            </div>
        </div>
        );
}