import {Link} from "react-router-dom"
import "../MainInfo.css"

const USettingsFooter = ({linkDirection, linkText}) => {
    return(
        <>
            <div style={{width:"100%", height:"2px", backgroundColor:"black"}}></div>
            <Link className="settings-return-link settings-link" to={linkDirection}>
                {linkText}
            </Link>
        </>
    )    
}

export default USettingsFooter