import moment from 'moment'

export const initUpdatedFilm = (filmId, newFilmData, oldFilmData, seasonsToDelete, peopleToDelete, 
    trailersToDelete, postersToDelete, trailersMetaDataToDelete, postersMetaDataToDelete) => {
    const formData = new FormData()

    formData.append('id', filmId)
    formData.append('name', newFilmData.name)
    formData.append('year', newFilmData.year)
    newFilmData.description && formData.append('description', newFilmData.description)
    newFilmData.shortDescription && formData.append('shortDescription', newFilmData.shortDescription)
    newFilmData.slogan && formData.append('slogan', newFilmData.slogan)
    formData.append('movieLength', newFilmData.movieLength)
    newFilmData.ageRating && formData.append('ageRating', newFilmData.ageRating)
    newFilmData.rating && formData.append('rating', newFilmData.rating)
    newFilmData.posterUrl && formData.append('posterUrl', newFilmData.posterUrl)
    formData.append('type', newFilmData.type.value ?? newFilmData.type)
    newFilmData.category && formData.append('category', newFilmData.category.value ?? newFilmData.category)
    initUpdatedFilmBudget(oldFilmData, newFilmData, formData)
    initUpdatedFilmFees(oldFilmData, newFilmData, formData)
    newFilmData.countries.map(c => c.value ?? c).forEach(c => formData.append('countries[]', c))
    newFilmData.genres.map(g => g.value ?? g).forEach(g => formData.append('genres[]', g)),
    (newFilmData.seasons && newFilmData.seasons.length > 0) && newFilmData.seasons.map((s, i) => ({ id: i < oldFilmData.seasons?.length ?? 0 ? oldFilmData.seasons[i].id : 0, number: s.number, episodesCount: s.episodesCount }))
        .forEach((s, index) => {
            formData.append(`seasons[${index}][id]`, s.id)
            formData.append(`seasons[${index}][number]`, s.number)
            formData.append(`seasons[${index}][episodesCount]`, s.episodesCount)
        }),
    newFilmData.people
        .filter(p => oldFilmData.filmCrew.every(old => (old.id !== p.id?.value ?? p.id) && (old.professionId !== p.professionId.value ?? p.professionId)))
        .map(p => ({ id: p.id?.value ?? p.id, name: p.name, photo: p.photo, professionId: p.professionId.value ?? p.professionId }))
        .forEach((p, index) => {
            formData.append(`peopleToAdd[${index}][id]`, p.id)
            !p.id && formData.append(`peopleToAdd[${index}][name]`, p.name)
            !p.id && formData.append(`peopleToAdd[${index}][photo]`, p.photo)
            formData.append(`peopleToAdd[${index}][professionId]`, p.professionId)
        })
    seasonsToDelete.forEach(s => formData.append('seasonsToDelete[]', s))
    peopleToDelete.forEach((p, index) => {
        formData.append(`peopleToDelete[${index}][personId]`, p.personId)
        formData.append(`peopleToDelete[${index}][professionId]`, p.professionId)
    })
    trailersToDelete.concat(postersToDelete).forEach(f => formData.append('filesToDelete[]', f))
    newFilmData.trailersMetaData?.map((m, i) => ({ id: i < ((oldFilmData.trailersMetaData?.length ?? 0) - trailersMetaDataToDelete.length) ? oldFilmData.trailersMetaData[i].id : undefined, language: m.language.value ?? m.language, resolution: m.resolution.value ?? m.resolution, name: m.name, date: m.date, video: m.video }))
        .filter(t => oldFilmData.trailersMetaData.every(old => {
            const oldDate = new Date(old.date)
            return !t.id || old.name !== t.name || oldDate.getFullYear() !== t.date.year() || oldDate.getMonth() !== t.date.month() || oldDate.getDate() !== t.date.date() || old.language !== t.language || old.resolution !== t.resolution
        }))
        .forEach((m, index) => {
            m.id && formData.append(`trailersMetaData[${index}][id]`, m.id)
            formData.append(`trailersMetaData[${index}][name]`, m.name)
            formData.append(`trailersMetaData[${index}][date]`, m.date.format('YYYY-MM-DD'))
            formData.append(`trailersMetaData[${index}][language]`, m.language)
            formData.append(`trailersMetaData[${index}][resolution]`, m.resolution)
            m.video && formData.append('trailers', m.video.file)
            m.video && formData.append('filesToAdd[]', m.name)
        })
    newFilmData.postersMetaData?.map((m, i) => ({ id: i < ((oldFilmData.postersMetaData?.length ?? 0) - postersMetaDataToDelete.length) ? oldFilmData.postersMetaData[i].id : undefined, name: m.name, resolution: m.resolution, picture: m.picture }))
        .filter(p => oldFilmData.postersMetaData.every(old => !p.id || old.name !== p.name || old.resolution !== p.resolution))
        .forEach((m, index) => {
            m.id && formData.append(`postersMetaData[${index}][id]`, m.id)
            formData.append(`postersMetaData[${index}][name]`, m.name)
            formData.append(`postersMetaData[${index}][resolution]`, m.resolution)
            m.picture && formData.append('posters', m.picture.file)
            m.picture && formData.append('filesToAdd[]', m.name)
        })
    trailersMetaDataToDelete.concat(postersMetaDataToDelete).forEach(m => formData.append('metaDataToDelete[]', m))

    return formData
}

const initUpdatedFilmFees = (oldFilmData, newFilmData, formData) => {
    formData.append('fees[id]', oldFilmData.fees?.id ?? 0)

    newFilmData.feesWorld && formData.append('fees[feesWorld][id]', oldFilmData.fees?.feesWorld?.id ?? 0)
    newFilmData.feesWorld && formData.append('fees[feesWorld][value]', newFilmData.feesWorld)
    newFilmData.feesWorld && formData.append('fees[feesWorld][currency]', newFilmData.feesWorldCurrency)

    newFilmData.feesRussia && formData.append('fees[feesRussia][id]', oldFilmData.fees?.feesRussia?.id ?? 0)
    newFilmData.feesRussia && formData.append('fees[feesRussia][value]', newFilmData.feesRussia)
    newFilmData.feesRussia && formData.append('fees[feesRussia][currency]', newFilmData.feesRussiaCurrency)
    
    newFilmData.feesUsa && formData.append('fees[feesUsa][id]', oldFilmData.fees?.feesUsa?.id ?? 0)
    newFilmData.feesUsa && formData.append('fees[feesUsa][value]', newFilmData.feesUsa)
    newFilmData.feesUsa && formData.append('fees[feesUsa][currency]', newFilmData.feesUsaCurrency)
}

const initUpdatedFilmBudget = (oldFilmData, newFilmData, formData) => {
    formData.append('budget[id]', oldFilmData.budget?.id ?? 0)
    newFilmData.budget && formData.append('budget[value]', newFilmData.budget)
    newFilmData.budget && formData.append('budget[currency]', newFilmData.budgetCurrency)
}

export const initForm = (film) => {
    return {
        name: film.name,
        year: film.year,
        description: film.description,
        shortDescription: film.shortDescription,
        slogan: film.slogan,
        rating: film.rating,
        ageRating: film.ageRating,
        movieLength: film.movieLength,
        posterUrl: film.posterUrl,
        type: { label: film.type.name, value: film.type.id },
        category: !film.category ? null : { label: film.category.name, value: film.category.id },
        budget: film.budget?.value,
        budgetCurrency: film.budget?.currency,
        feesWorld: film.fees?.feesWorld?.value,
        feesWorldCurrency: film.fees?.feesWorld?.currency,
        feesRussia: film.fees?.feesRussia?.value,
        feesRussiaCurrency: film.fees?.feesRussia?.currency,
        feesUsa: film.fees?.feesUsa?.value,
        feesUsaCurrency: film.fees?.feesUsa?.currency,
        genres: film.genres.map(g => ({ label: g.name, value: g.id })),
        countries: film.countries.map(c => ({ label: c.name, value: c.id })),
        seasons: film.seasons.map(s => ({ number: s.number, episodesCount: s.episodesCount })),
        people: film.filmCrew.map(fc => ({ id: { label: fc.name, value: fc.id }, professionId: { label: fc.professionName, value: fc.professionId }})),
        trailersMetaData: film.trailersMetaData.map(tmd => ({ name: tmd.name, date: moment(tmd.date), language: { label: tmd.language, value: tmd.language }, resolution: { label: tmd.resolution, value: tmd.resolution } })),
        postersMetaData: film.postersMetaData.map(pmd => ({ name: pmd.name, resolution: pmd.resolution }))
    }
}