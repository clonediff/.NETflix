import Header from "../main-page/header/header";
import styles from "./Profile.module.sass"
import "../../constants.css"
import { MainInfo } from "./main-info/MainInfo";
import { useEffect, useState } from "react";
import { SubscriptionInfo } from "./subscription/SubsriptionInfo";

export const ProfilePage = () => {
    const user = {
        id: 1,
        login: "Admin",
        email: "example@example.com",
        birthdate: '10.06.2003',
        password: "65e84be33532fb784c48129675f9eff3a682b27168c0ea744b2cf58ee02337c5",
        enabled2FA: false,
        role: {
            id: 1,
            name: "Admin"
        }
    }

    const [navigationState, setNavigationState] = useState(0)
    
    const tabs = [
    {
        title: 'Основная информация',
        body: <MainInfo user={user}/>
    }, 
    {
        title: 'Управление подпиской',
        body: <SubscriptionInfo/>
    }]

    useEffect(() => {
        console.log(navigationState)
    }, [navigationState])

    return (
        <div className="pageStyle">
            <Header/>
            <div className={styles.mainDiv}>
                <div className={styles.wrapper}>
                    <div className={styles.sidebar}>
                        {tabs.map((item, index) => (
                            <a onClick={() => setNavigationState(index)} >{item.title}</a>
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