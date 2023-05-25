export const initUpdatedFilm = (filmId, newFilmData, oldFilmData, seasonsToDelete, oldFilmCrew, peopleToDelete) => {
    return {
        id: filmId,
        name: newFilmData.name,
        year: newFilmData.year,
        description: newFilmData.description,
        shortDescription: newFilmData.shortDescription,
        slogan: newFilmData.slogan,
        movieLength: newFilmData.movieLength,
        ageRating: newFilmData.ageRating,
        rating: newFilmData.rating,
        posterUrl: newFilmData.posterUrl,
        type: newFilmData.type.value ?? newFilmData.type,
        category: !newFilmData.category ? null : newFilmData.category.value ?? newFilmData.category,
        // budget: newFilmData.budget ? { id: oldFilmData.budget?.id, value: newFilmData.budget, currency: newFilmData.budgetCurrency } : null,
        budget: initUpdateFilmBudget(oldFilmData, newFilmData),
        fees: initUpdatedFilmFees(oldFilmData, newFilmData),
        countries: newFilmData.countries.map(c => c.value ?? c),
        genres: newFilmData.genres.map(g => g.value ?? g),
        seasons: newFilmData.seasons?.map((s, i) => ({ id: i < oldFilmData.seasons?.length ?? 0 ? oldFilmData.seasons[i].id : 0, number: s.number, episodesCount: s.episodesCount })),
        peopleToAdd: newFilmData.people
            .filter(p => oldFilmCrew.every(old => (old.personId !== p.id?.value ?? p.id) && (old.professionId !== p.professionId.value ?? p.professionId)))
            .map(p => ({ id: p.id?.value ?? p.id, name: p.name, photo: p.photo, professionId: p.professionId.value ?? p.professionId })),
        seasonsToDelete: seasonsToDelete,
        peopleToDelete: peopleToDelete
    }
}

const initUpdatedFilmFees = (oldFilmData, newFilmData) => {
    return !newFilmData.feesWorld && !newFilmData.feesRussia && !newFilmData.feesUsa
        ? 
        {
            id: oldFilmData.fees?.id ?? 0,
            feesWorld: null, 
            feesRussia: null,
            feesUsa: null
        }
        : 
        {
            id: oldFilmData.fees?.id ?? 0,
            feesWorld: newFilmData.feesWorld ? { id: oldFilmData.fees?.feesWorld?.id ?? 0, value: newFilmData.feesWorld, currency: newFilmData.feesWorldCurrency } : null, 
            feesRussia: newFilmData.feesRussia ? { id: oldFilmData.fees?.feesRussia?.id ?? 0, value: newFilmData.feesRussia, currency: newFilmData.feesRussiaCurrency } : null,
            feesUsa: newFilmData.feesUsa ? { id: oldFilmData.fees?.feesUsa?.id ?? 0, value: newFilmData.feesUsa, currency: newFilmData.feesUsaCurrency } : null
        }
}

const initUpdateFilmBudget = (oldFilmData, newFilmData) => {
    return !newFilmData.budget
        ?
        {
            id: oldFilmData.budget?.id ?? 0,
            value: null,
            currency: null
        }
        :
        {
            id: oldFilmData.budget?.id ?? 0,
            value: newFilmData.budget,
            currency: newFilmData.budgetCurrency
        }
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
        people: film.filmCrew.map(fc => ({ id: { label: fc.name, value: fc.id }, professionId: { label: fc.professionName, value: fc.professionId }}))
    }
}