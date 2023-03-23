import styles from "./TitleValue.module.sass"

export const TitleValue = ({ title, value }) => {
    return (
        <div className={styles.titleValue}>
            <h3>{title}:</h3>
            <p>{value}</p>
        </div>
    )
}