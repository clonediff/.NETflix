import './simple-layout.css'

const SimpleLayout = ({ children }) => {
    return (
        <>
            <div className='simple-header'>
                <a href='/' className='simple-logo'>.Netflix</a>
            </div>
            { children }
        </>
    )
}

export default SimpleLayout