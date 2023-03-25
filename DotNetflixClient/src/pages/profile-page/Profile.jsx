import Header from "../main-page/header/header";
import styles from "./Profile.module.sass"
import "../../constants.css"
import { MainInfo } from "./main-info/MainInfo";
import { useEffect, useState } from "react";
import { SubscriptionInfo } from "./subscription/SubsriptionInfo";

export const ProfilePage = () => {
    const [userData, setUserData] = useState(
    {
        id: 1,
        login: "Admin",
        email: "example@example.com",
        birthdate: '2003.06.10',
        enabled2FA: false,
        role: {
            id: 1,
            name: "Admin"
        }
    })

    const [navigationState, setNavigationState] = useState(0)
    
    const tabs = [
    {
        title: 'Основная информация',
        body: <MainInfo userData={userData} setUserData = {setUserData}/>
    }, 
    {
        title: 'Управление подпиской',
        body: <SubscriptionInfo/>
    }]

    return (
        <div className="pageStyle">
            <Header/>
            <div className={styles.mainDiv}>
                <div className={styles.sidebar_wrapper}>
                    <div className={styles.sidebar}>
                        {tabs.map((item, index) => (
                            <a onClick={() => setNavigationState(index)} key={index}
                            className={navigationState === index && styles.active}>{item.title}</a>
                        ))}
                    </div>
                </div>
                <div className={styles.contentDiv}>
                    <h1>{tabs[navigationState].title}</h1>
                    {tabs[navigationState].body}
                </div>
            </div>
        </div>
    )
}