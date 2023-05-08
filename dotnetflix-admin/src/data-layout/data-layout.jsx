import { Button, Form, Input, Pagination, Space } from 'antd'
import CustomSpin from '../custom-spin/custom-spin'
import './data-layout.css'

const DataLayout = ({ 
    isLoading, 
    onSearch, 
    dataCount, 
    onPageChanged, 
    pageSize, 
    children, 
    searchPlaceholder, 
    onSearchClear = () => {} }) => {

    const [form] = Form.useForm()

    const handleUpdate = () => {
        form.setFieldValue('name', undefined)
        onSearchClear()
    } 

    return (
        <>
        {
            !isLoading
            ?
            <>
                <Form onFinish={ onSearch } form={ form }>
                    <Space>
                        <Form.Item name='name' noStyle>
                            <Input.Search placeholder={ searchPlaceholder } className='data-search' />
                        </Form.Item>
                        <Button style={{ marginBottom: 24 }} type='primary' onClick={ handleUpdate }>Очистить</Button>
                    </Space>
                    <Form.Item hidden noStyle>
                        <Button htmlType='submit'></Button>
                    </Form.Item>
                </Form>
                { children }
                <Pagination 
                    className='pagination'
                    responsive
                    showSizeChanger={ false }
                    pageSize={ pageSize }
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