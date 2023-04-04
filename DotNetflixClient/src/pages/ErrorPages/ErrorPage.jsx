import { useNavigate } from "react-router-dom";
import { ErrorDto } from "../../libs/error-info/error-info";
import Header from "../main-page/header/header";
import styles from "./ErrorPage.module.sass";
import { Button } from 'antd';

export const ErrorPage = ({errorNumber}) => {

    let navigate = useNavigate();
    let errorDto = new ErrorDto(errorNumber);
    return(<div className={styles.error}>
        <Header></Header>
        <div className={styles.wrapper} 
            style={{backgroundImage: `linear-gradient( rgba(0, 0, 0, 0.4), rgba(0, 0, 0, 0.4) ),url(${errorDto.imageURL})`}}>
            <div className={styles.errorPage}>
                <div className={styles.errorInfo}>
                    <h1>{errorNumber}</h1>
                    <h2>{errorDto.errorMessage}</h2>
                    <Button danger type="primary" 
                        style={{marginTop : "25px"}} 
                        onClick={e => {navigate("/")}}>На домашнюю страницу</Button>
                </div>
            </div>
        </div>
    </div>)
}