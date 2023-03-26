import './film-skeleton.css'

export const HeaderSkeleton = () => {
    return (
        <div className='skeleton-header skeleton-animation'></div>
    )
}

export const FilmCardSkeleton = () => {
    return (
        <div className='skeleton-card film-card skeleton-animation'></div>
    )
}

export const PosterSkeleton = () => {
    return (
        <div className='skeleton-poster film-page-poster skeleton-animation'></div>
    )
}

export const TextSkeleton = ({ width }) => {
    return (
        <div style={{ width: width }} className='skeleton-text  skeleton-animation'></div>
    )
}