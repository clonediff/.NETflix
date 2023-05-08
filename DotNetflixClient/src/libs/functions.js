export const formatDate = (dateString) => {
    let date = new Date(dateString)
    let days = ('0' + date.getDate()).slice(-2)
    let months = ('0' + (date.getMonth() + 1)).slice(-2)
    return `${days}.${months}.${date.getFullYear()}`
}
