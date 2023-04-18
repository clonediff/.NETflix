import { Spin } from 'antd'
import './custom-spin.css'

const CustomSpin = () => {
    return (
        <Spin size='large' tip='Загрузка' className='spin'>
            <div></div>
        </Spin>
    )
}

export default CustomSpin