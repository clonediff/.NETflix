import { useState } from 'react'
import { axiosInstance } from '../../clients'
import { Button } from 'antd'
import SettingsModal from './settings-modal'
import FilmsModal from './films-modal'
import '../../data-layout/border-styles.css'
import '../../data-layout/buttons-styles.css'
import '../../data-layout/data-layout.css'


const Subscription = ({ subscription, modal, modalHolder, onChange }) => {

    const [openSettings, setOpenSettings] = useState(false)
    const [openFilms, setOpenFilms] = useState(false)
    const [isAvailable, setIsAvailable] = useState(subscription.isAvailable)

    const showSettingsModal = () => {
        setOpenSettings(true)
    }

    const hideSettingsModal = () => {
        setOpenSettings(false)
    }

    const showFilmsModal = () => {
        setOpenFilms(true)
    }

    const hideFilmsModal = () => {
        setOpenFilms(false)
    }

    const changeAvailability = (isAvailable) =>
        () => {
            axiosInstance.put('api/subscription/changeavailability', {
                id: subscription.id,
                isAvailable: isAvailable
            })
            .then(_ => {
                setIsAvailable(isAvailable)
                modal.success({
                    title: 'успешно обновлён статус подписки',
                    zIndex: 10001
                })
            })
            .catch(_ => {
                modal.error({
                    title: 'не удалось обновить статус подписки',
                    zIndex: 10001
                })
            })
        }

    const deleteSubscription = () => {
        axiosInstance.delete(`api/subscription/delete?subscriptionId=${subscription.id}`)
            .then(_ => {
                modal.success({
                    title: 'подписка успешно удалена',
                    zIndex: 10001,
                    afterClose: onChange
                })
            })
            .catch(_ => {
                modal.error({
                    title: 'не удалось удалить подписку',
                    zIndex: 10001
                })
            })
    }

    return (
        <>
            <div className='list-item'>
                { modalHolder }
                <span>{ subscription.name }</span>
                <div className='list-item-options'>
                    <Button type='primary' onClick={ showSettingsModal }>Настройки</Button>
                    <Button type='primary' onClick={ showFilmsModal }>Фильмы</Button>
                    {
                        isAvailable
                        ?
                        <button onClick={ changeAvailability(false) } className='ban-button ban-color right-border-radius left-border-radius'>Деактивировать</button>
                        :
                        <button onClick={ changeAvailability(true) } className='ban-button unban-color right-border-radius left-border-radius'>Активировать</button>
                    }
                    <Button type='primary' onClick={ deleteSubscription } danger disabled={ subscription.subscribersCount > 0 }>Удалить</Button>
                </div>
            </div>
            <SettingsModal 
                openSettings={ openSettings }
                hideSettingsModal={ hideSettingsModal }
                subscription={ subscription }
                onChange={ onChange } />
            <FilmsModal
                openFilms={ openFilms }
                hideFilmsModal={ hideFilmsModal }
                subscription={ subscription } />
        </>
    )
}

export default Subscription