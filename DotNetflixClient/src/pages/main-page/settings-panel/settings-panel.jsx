import './settings-panel.css'

const SettingsPanel = ({ topProp }) => {
    return (
        <div style={ topProp } className='settings-panel'>
            <div className='settings-panel-label'>
                Год выхода
            </div>
            <input type='search' className='settings-panel-input'/>
            <div className='settings-panel-label'>
                Страна производства
            </div>
            <input type='search' className='settings-panel-input' />
            <div className='settings-panel-label'>
                Жанры
            </div>
            <input type='search' className='settings-panel-input' />
            <div className='settings-panel-label'>
                Актёры
            </div>
            <input type='search' className='settings-panel-input' />
            <div className='settings-panel-label'>
                Режиссёр
            </div>
            <input type='search' className='settings-panel-input' />
        </div>
    )
}

export default SettingsPanel