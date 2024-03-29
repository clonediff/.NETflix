import { Form } from 'antd'
import './settings-panel.css'

const SettingsPanel = () => {
    return (
        <div className='settings-panel'>
            <div className='settings-panel-label'>
                Год выхода
            </div>
            <Form.Item noStyle name='year' initialValue=''>
                <input type='search' className='settings-panel-input' autoComplete='off'/>
            </Form.Item>
            <div className='settings-panel-label'>
                Страна производства
            </div>
            <Form.Item noStyle name='country' initialValue=''>
                <input type='search' className='settings-panel-input' autoComplete='off'/>
            </Form.Item>
            <div className='settings-panel-label'>
                Жанры
            </div>
            <Form.Item noStyle name='genres' initialValue=''>
                <input type='search' placeholder='через запятую' className='settings-panel-input' autoComplete='off'/>
            </Form.Item>
            <div className='settings-panel-label'>
                Актёры
            </div>
            <Form.Item noStyle name='actors' initialValue=''>
                <input type='search' placeholder='через запятую' className='settings-panel-input' autoComplete='off'/>
            </Form.Item>
            <div className='settings-panel-label'>
                Режиссёр
            </div>
            <Form.Item noStyle name='director' initialValue=''>
                <input type='search' className='settings-panel-input' autoComplete='off'/>
            </Form.Item>
            <Form.Item noStyle>
                <button type='submit' hidden />
            </Form.Item>
        </div>
    )
}

export default SettingsPanel