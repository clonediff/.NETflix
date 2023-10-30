import SimpleLayout from "../../../layouts/simple-layout/simple-layout";
import { Link } from "react-router-dom";
import { RegistrationForm } from "../registration-form-container/RegistrationForm";
import styles from "./RegistrationPage.module.sass"

export const RegistrationPage = () => {
    return(
        <div className={styles.registration_page}>
            <SimpleLayout>
                <div className={styles.registration}>
                    <div className={styles.registration_wrapper}>
                        <RegistrationForm></RegistrationForm>
                        <p>Есть аккаунт? <Link className={styles.link} to="/login">Авторизация</Link></p>
                    </div>
                </div>
            </SimpleLayout>
        </div>
    );
}