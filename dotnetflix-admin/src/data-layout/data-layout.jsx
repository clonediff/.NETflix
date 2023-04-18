import { Button, Form, Input, Pagination } from 'antd'
import CustomSpin from '../custom-spin/custom-spin'
import './data-layout.css'

const DataLayout = ({ isLoading, onSearch, dataCount, onPageChanged, children, searchPlaceholder }) => {
    return (
        <>
        {
            !isLoading
            ?
            <>
                <Form onFinish={ onSearch }>
                    <Form.Item name='name' noStyle>
                        <Input.Search placeholder={ searchPlaceholder } className='data-search' />
                    </Form.Item>
                    <Form.Item hidden noStyle>
                        <Button htmlType='submit'></Button>
                    </Form.Item>
                </Form>
                <div className='data-list'>
                    { children }
                </div>
                <Pagination 
                    className='pagination'
                    responsive
                    showSizeChanger={ false }
                    pageSize={ 25 }
                    total={ dataCount }
                    onChange={ onPageChanged } />
            </>
            :
            <CustomSpin />
        }
    </>
    )
}

export default DataLayout