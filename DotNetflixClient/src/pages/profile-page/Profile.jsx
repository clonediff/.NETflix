import CommonLayout from "../../layouts/common-layout/common-layout";
import { MainInfo } from "./main-info/MainInfo";
import { useEffect, useState } from "react";
import { SubscriptionInfo } from "./subscription/SubsriptionInfo";
import { axiosInstance } from "../../AxiosInstance";
import { useNavigate } from "react-router-dom";
import styles from "./Profile.module.sass"
import "../../constants.css"

export const ProfilePage = () => {
    const navigate = useNavigate()
    const [userData, setUserData] = useState({})

    useEffect(() => {
        axiosInstance.get("api/user/getuser")
            .then(response => {
                if (response.data)
                    setUserData(response.data)
                else
                    navigate("/login")
            })
            .catch((error) => {
                if(error.response.status === 404)
                    navigate("/login") 
            })
    }, [])

    const [navigationState, setNavigationState] = useState(0)
    
    const tabs = [
    {
        title: 'Основная информация',
        body: <MainInfo userData={userData} setUserData = {setUserData}/>
    }, 
    {
        title: 'Управление подпиской',
        body: <SubscriptionInfo />
    }]

    return (
        <div className="pageStyle">
            <CommonLayout>
                <div className={styles.mainDiv}>
                    <div className={styles.sidebar_wrapper}>
                        <div className={styles.sidebar}>
                            {tabs.map((item, index) => (
                                <a onClick={() => setNavigationState(index)} key={index}
                                className={navigationState === index ? styles.active : null}>{item.title}</a>
                            ))}
                        </div>
                    </div>
                    <div className={styles.contentDiv}>
                        <h1>{tabs[navigationState].title}</h1>
                        {tabs[navigationState].body}
                    </div>
                </div>
            </CommonLayout>
        </div>
    )
}