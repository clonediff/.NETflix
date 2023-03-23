import { Route, Routes, Link} from "react-router-dom"
import { TitleValue } from "../title-value/TitleValue"
import styles from "./MainInfo.module.sass"
import "./MainInfo.css"
import ChangeEmailForm from "./components/change-email-form"
import ChangePassForm from "./components/change-pass-form"
import ChangeUSettingsForm from "./components/change-usettings-form"

export const MainInfo = ({userData, setUserData}) => {
    console.log(setUserData.type)
    return (
        <div>
            <Routes>
                <Route path="/" element={
                    <>
                        <Link to='./change' className={styles.editBtn}>
                            Изменить
                            <svg width="20px" height="20px" viewBox="0 0 24 24" id="_24x24_On_Light_Edit" data-name="24x24/On Light/Edit" xmlns="http://www.w3.org/2000/svg">
                                <rect id="view-box" width="24" height="24" fill="none"/>
                                <path id="Shape" d="M.75,17.5A.751.751,0,0,1,0,16.75V12.569a.755.755,0,0,1,.22-.53L11.461.8a2.72,2.72,0,0,1,3.848,0L16.7,2.191a2.72,2.72,0,0,1,0,3.848L5.462,17.28a.747.747,0,0,1-.531.22ZM1.5,12.879V16h3.12l7.91-7.91L9.41,4.97ZM13.591,7.03l2.051-2.051a1.223,1.223,0,0,0,0-1.727L14.249,1.858a1.222,1.222,0,0,0-1.727,0L10.47,3.91Z" transform="translate(3.25 3.25)" fill="#fff"/>
                            </svg>
                        </Link>
                        <TitleValue title="Login" value={userData.login}/>
                        <TitleValue title="Email" value={userData.email}/>
                        <TitleValue title="Birthdate" value={formatDate(userData.birthdate)}/>
                        <TitleValue title="Age" value={getAge(userData.birthdate)}/>
                        {
                            userData.role.id === 1 &&
                            <TitleValue title="Role" value={userData.role.name}/>
                        }
                        {
                            !userData.enabled2FA &&
                            <TitleValue title="Подключить двухфакторную аутентификацию" 
                                value={<a href="#">Подключить</a>}/>
                        }
                        {
                            userData.enabled2FA &&
                            <h3>Двухфакторная аутентификация подключена</h3>
                        }
                    </>
                }/>
                <Route path="/change" element={<ChangeUSettingsForm userData = {userData} setUserData={setUserData}/>} />
                {
                    userData.enabled2FA === true && 
                    <>
                        <Route path="/change/pass" element={<ChangePassForm/>}/>
                        <Route path="/change/email" element={<ChangeEmailForm userData = {userData} setUserData={setUserData}/>}/>
                    </>
                }
            </Routes>
        </div>
    )
}

function formatDate(date){
    return new Date(date).toLocaleDateString('ru-ru')
}

function getAge(birthdate){
    return new Date(Date.now() - new Date(birthdate)).getFullYear() - 1970;
}