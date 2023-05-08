import { Pagination } from "antd"

export const PaginationBlock = ({ children, pageSize, pageState, paginationClassName }) => {
    const [page, setPage] = pageState

    const onPageChanged = (page, _) => {
        setPage(page)
    }

    return (
    <>
        {children.slice(pageSize * (page - 1), pageSize * page)}
        {
            children.length > pageSize &&
            <Pagination
                className={paginationClassName && null}
                responsive
                showSizeChanger={false}
                pageSize={pageSize}
                total={children.length}
                onChange={onPageChanged}/>
        }
    </>)
}