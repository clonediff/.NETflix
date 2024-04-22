class Queries {

  static const allFilmsQueryName = 'allFilms';
  static const allFilmsQuery = '''
    query {
      $allFilmsQueryName {
        key,
        value {
          id,
          name,
          rating,
          posterUrl
        }
      }
    }
  ''';


}
