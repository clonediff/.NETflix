using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddEnumsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Новинки" },
                    { 2, "Топ-10 лучших фильмов" },
                    { 3, "Топ-10 лучших российских фильмов" },
                    { 4, "Топ-10 лучших сериалов" },
                    { 5, "Выбор редакции" },
                    { 6, "Группа 11-106 рекомендует" },
                    { 7, "Киновселенная Marvel" },
                    { 8, "Непревзойдённый Райан Гослинг" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "Австралия", "Avstraliya" },
                    { 2, "Австрия", "Avstriya" },
                    { 3, "Азербайджан", "Azerbaydzhan" },
                    { 4, "Албания", "Albaniya" },
                    { 5, "Алжир", "Alzhir" },
                    { 6, "Американские Виргинские острова", "Amerikanskie-Virginskie-ostrova" },
                    { 7, "Американское Самоа", "Amerikanskoe-Samoa" },
                    { 8, "Ангола", "Angola" },
                    { 9, "Андорра", "Andorra" },
                    { 10, "Антарктида", "Antarktida" },
                    { 11, "Антигуа и Барбуда", "Antigua-i-Barbuda" },
                    { 12, "Антильские Острова", "Antilskie-Ostrova" },
                    { 13, "Аргентина", "Argentina" },
                    { 14, "Армения", "Armeniya" },
                    { 15, "Аруба", "Aruba" },
                    { 16, "Афганистан", "Afganistan" },
                    { 17, "Багамы", "Bagamy" },
                    { 18, "Бангладеш", "Bangladesh" },
                    { 19, "Барбадос", "Barbados" },
                    { 20, "Бахрейн", "Bahreyn" },
                    { 21, "Беларусь", "Belarus" },
                    { 22, "Белиз", "Beliz" },
                    { 23, "Бельгия", "Belgiya" },
                    { 24, "Бенин", "Benin" },
                    { 25, "Берег Слоновой кости", "Bereg-Slonovoy-kosti" },
                    { 26, "Бермуды", "Bermudy" },
                    { 27, "Бирма", "Birma" },
                    { 28, "Болгария", "Bolgariya" },
                    { 29, "Боливия", "Boliviya" },
                    { 30, "Босния", "Bosniya" },
                    { 31, "Босния и Герцеговина", "Bosniya-i-Gercegovina" },
                    { 32, "Ботсвана", "Botsvana" },
                    { 33, "Бразилия", "Braziliya" },
                    { 34, "Бруней-Даруссалам", "Bruney-Darussalam" },
                    { 35, "Буркина-Фасо", "Burkina-Faso" },
                    { 36, "Бурунди", "Burundi" },
                    { 37, "Бутан", "Butan" },
                    { 38, "Вануату", "Vanuatu" },
                    { 39, "Ватикан", "Vatikan" },
                    { 40, "Великобритания", "Velikobritaniya" },
                    { 41, "Венгрия", "Vengriya" },
                    { 42, "Венесуэла", "Venesuela" },
                    { 43, "Виргинские Острова", "Virginskie-Ostrova" },
                    { 44, "Внешние малые острова США", "Vneshnie-malye-ostrova-SShA" },
                    { 45, "Вьетнам", "Vetnam" },
                    { 46, "Вьетнам Северный", "Vetnam-Severnyy" },
                    { 47, "Габон", "Gabon" },
                    { 48, "Гаити", "Gaiti" },
                    { 49, "Гайана", "Gayana" },
                    { 50, "Гамбия", "Gambiya" },
                    { 51, "Гана", "Gana" },
                    { 52, "Гваделупа", "Gvadelupa" },
                    { 53, "Гватемала", "Gvatemala" },
                    { 54, "Гвинея", "Gvineya" },
                    { 55, "Гвинея-Бисау", "Gvineya-Bisau" },
                    { 56, "Германия", "Germaniya" },
                    { 57, "Германия (ГДР)", "Germaniya-(GDR)" },
                    { 58, "Германия (ФРГ)", "Germaniya-(FRG)" },
                    { 59, "Гибралтар", "Gibraltar" },
                    { 60, "Гондурас", "Gonduras" },
                    { 61, "Гонконг", "Gonkong" },
                    { 62, "Гренада", "Grenada" },
                    { 63, "Гренландия", "Grenlandiya" },
                    { 64, "Греция", "Greciya" },
                    { 65, "Грузия", "Gruziya" },
                    { 66, "Гуам", "Guam" },
                    { 67, "Дания", "Daniya" },
                    { 68, "Джибути", "Dzhibuti" },
                    { 69, "Доминика", "Dominika" },
                    { 70, "Доминикана", "Dominikana" },
                    { 71, "Египет", "Egipet" },
                    { 72, "Заир", "Zair" },
                    { 73, "Замбия", "Zambiya" },
                    { 74, "Западная Сахара", "Zapadnaya-Sahara" },
                    { 75, "Зимбабве", "Zimbabve" },
                    { 76, "Израиль", "Izrail" },
                    { 77, "Индия", "Indiya" },
                    { 78, "Индонезия", "Indoneziya" },
                    { 79, "Иордания", "Iordaniya" },
                    { 80, "Ирак", "Irak" },
                    { 81, "Иран", "Iran" },
                    { 82, "Ирландия", "Irlandiya" },
                    { 83, "Исландия", "Islandiya" },
                    { 84, "Испания", "Ispaniya" },
                    { 85, "Италия", "Italiya" },
                    { 86, "Йемен", "Yemen" },
                    { 87, "Кабо-Верде", "Kabo-Verde" },
                    { 88, "Казахстан", "Kazahstan" },
                    { 89, "Каймановы острова", "Kaymanovy-ostrova" },
                    { 90, "Камбоджа", "Kambodzha" },
                    { 91, "Камерун", "Kamerun" },
                    { 92, "Канада", "Kanada" },
                    { 93, "Катар", "Katar" },
                    { 94, "Кения", "Keniya" },
                    { 95, "Кипр", "Kipr" },
                    { 96, "Киргизия", "Kirgiziya" },
                    { 97, "Кирибати", "Kiribati" },
                    { 98, "Китай", "Kitay" },
                    { 99, "Колумбия", "Kolumbiya" },
                    { 100, "Коморы", "Komory" },
                    { 101, "Конго", "Kongo" },
                    { 102, "Конго (ДРК)", "Kongo-(DRK)" },
                    { 103, "Корея", "Koreya" },
                    { 104, "Корея Северная", "Koreya-Severnaya" },
                    { 105, "Корея Южная", "Koreya-Yuzhnaya" },
                    { 106, "Косово", "Kosovo" },
                    { 107, "Коста-Рика", "Kosta-Rika" },
                    { 108, "Кот-д’Ивуар", "Kot-d'Ivuar" },
                    { 109, "Куба", "Kuba" },
                    { 110, "Кувейт", "Kuveyt" },
                    { 111, "Лаос", "Laos" },
                    { 112, "Латвия", "Latviya" },
                    { 113, "Лесото", "Lesoto" },
                    { 114, "Либерия", "Liberiya" },
                    { 115, "Ливан", "Livan" },
                    { 116, "Ливия", "Liviya" },
                    { 117, "Литва", "Litva" },
                    { 118, "Лихтенштейн", "Lihtenshteyn" },
                    { 119, "Люксембург", "Lyuksemburg" },
                    { 120, "Маврикий", "Mavrikiy" },
                    { 121, "Мавритания", "Mavritaniya" },
                    { 122, "Мадагаскар", "Madagaskar" },
                    { 123, "Макао", "Makao" },
                    { 124, "Македония", "Makedoniya" },
                    { 125, "Малави", "Malavi" },
                    { 126, "Малайзия", "Malayziya" },
                    { 127, "Мали", "Mali" },
                    { 128, "Мальдивы", "Maldivy" },
                    { 129, "Мальта", "Malta" },
                    { 130, "Марокко", "Marokko" },
                    { 131, "Мартиника", "Martinika" },
                    { 132, "Маршалловы острова", "Marshallovy-ostrova" },
                    { 133, "Мексика", "Meksika" },
                    { 134, "Мозамбик", "Mozambik" },
                    { 135, "Молдова", "Moldova" },
                    { 136, "Монако", "Monako" },
                    { 137, "Монголия", "Mongoliya" },
                    { 138, "Монтсеррат", "Montserrat" },
                    { 139, "Мьянма", "Myanma" },
                    { 140, "Намибия", "Namibiya" },
                    { 141, "Непал", "Nepal" },
                    { 142, "Нигер", "Niger" },
                    { 143, "Нигерия", "Nigeriya" },
                    { 144, "Нидерланды", "Niderlandy" },
                    { 145, "Никарагуа", "Nikaragua" },
                    { 146, "Новая Зеландия", "Novaya-Zelandiya" },
                    { 147, "Новая Каледония", "Novaya-Kaledoniya" },
                    { 148, "Норвегия", "Norvegiya" },
                    { 149, "ОАЭ", "OAE" },
                    { 150, "Оккупированная Палестинская территория", "Okkupirovannaya-Palestinskaya-territoriya" },
                    { 151, "Оман", "Oman" },
                    { 152, "Остров Мэн", "Ostrov-Men" },
                    { 153, "Острова Кука", "Ostrova-Kuka" },
                    { 154, "Пакистан", "Pakistan" },
                    { 155, "Палау", "Palau" },
                    { 156, "Палестина", "Palestina" },
                    { 157, "Панама", "Panama" },
                    { 158, "Папуа - Новая Гвинея", "Papua---Novaya-Gvineya" },
                    { 159, "Парагвай", "Paragvay" },
                    { 160, "Перу", "Peru" },
                    { 161, "Польша", "Polsha" },
                    { 162, "Португалия", "Portugaliya" },
                    { 163, "Пуэрто Рико", "Puerto-Riko" },
                    { 164, "Реюньон", "Reyunon" },
                    { 165, "Российская империя", "Rossiyskaya-imperiya" },
                    { 166, "Россия", "Rossiya" },
                    { 167, "Руанда", "Ruanda" },
                    { 168, "Румыния", "Rumyniya" },
                    { 169, "СССР", "SSSR" },
                    { 170, "США", "SShA" },
                    { 171, "Сальвадор", "Salvador" },
                    { 172, "Самоа", "Samoa" },
                    { 173, "Сан-Марино", "San-Marino" },
                    { 174, "Саудовская Аравия", "Saudovskaya-Araviya" },
                    { 175, "Свазиленд", "Svazilend" },
                    { 176, "Северная Македония", "Severnaya-Makedoniya" },
                    { 177, "Сейшельские острова", "Seyshelskie-ostrova" },
                    { 178, "Сенегал", "Senegal" },
                    { 179, "Сент-Винсент и Гренадины", "Sent-Vinsent-i-Grenadiny" },
                    { 180, "Сент-Китс и Невис", "Sent-Kits-i-Nevis" },
                    { 181, "Сент-Люсия ", "Sent-Lyusiya-" },
                    { 182, "Сербия", "Serbiya" },
                    { 183, "Сербия и Черногория", "Serbiya-i-Chernogoriya" },
                    { 184, "Сиам", "Siam" },
                    { 185, "Сингапур", "Singapur" },
                    { 186, "Сирия", "Siriya" },
                    { 187, "Словакия", "Slovakiya" },
                    { 188, "Словения", "Sloveniya" },
                    { 189, "Соломоновы Острова", "Solomonovy-Ostrova" },
                    { 190, "Сомали", "Somali" },
                    { 191, "Судан", "Sudan" },
                    { 192, "Суринам", "Surinam" },
                    { 193, "Сьерра-Леоне", "Serra-Leone" },
                    { 194, "Таджикистан", "Tadzhikistan" },
                    { 195, "Таиланд", "Tailand" },
                    { 196, "Тайвань", "Tayvan" },
                    { 197, "Танзания", "Tanzaniya" },
                    { 198, "Тимор-Лесте", "Timor-Leste" },
                    { 199, "Того", "Togo" },
                    { 200, "Тонга", "Tonga" },
                    { 201, "Тринидад и Тобаго", "Trinidad-i-Tobago" },
                    { 202, "Тувалу", "Tuvalu" },
                    { 203, "Тунис", "Tunis" },
                    { 204, "Туркменистан", "Turkmenistan" },
                    { 205, "Турция", "Turciya" },
                    { 206, "Уганда", "Uganda" },
                    { 207, "Узбекистан", "Uzbekistan" },
                    { 208, "Украина", "Ukraina" },
                    { 209, "Уоллис и Футуна", "Uollis-i-Futuna" },
                    { 210, "Уругвай", "Urugvay" },
                    { 211, "Фарерские острова", "Farerskie-ostrova" },
                    { 212, "Федеративные Штаты Микронезии", "Federativnye-Shtaty-Mikronezii" },
                    { 213, "Фиджи", "Fidzhi" },
                    { 214, "Филиппины", "Filippiny" },
                    { 215, "Финляндия", "Finlyandiya" },
                    { 216, "Фолклендские острова", "Folklendskie-ostrova" },
                    { 217, "Франция", "Franciya" },
                    { 218, "Французская Гвиана", "Francuzskaya-Gviana" },
                    { 219, "Французская Полинезия", "Francuzskaya-Polineziya" },
                    { 220, "Хорватия", "Horvatiya" },
                    { 221, "ЦАР", "CAR" },
                    { 222, "Чад", "Chad" },
                    { 223, "Черногория", "Chernogoriya" },
                    { 224, "Чехия", "Chehiya" },
                    { 225, "Чехословакия", "Chehoslovakiya" },
                    { 226, "Чили", "Chili" },
                    { 227, "Швейцария", "Shveycariya" },
                    { 228, "Швеция", "Shveciya" },
                    { 229, "Шри-Ланка", "Shri-Lanka" },
                    { 230, "Эквадор", "Ekvador" },
                    { 231, "Экваториальная Гвинея", "Ekvatorialnaya-Gvineya" },
                    { 232, "Эритрея", "Eritreya" },
                    { 233, "Эстония", "Estoniya" },
                    { 234, "Эфиопия", "Efiopiya" },
                    { 235, "ЮАР", "YuAR" },
                    { 236, "Югославия", "Yugoslaviya" },
                    { 237, "Югославия (ФР)", "Yugoslaviya-(FR)" },
                    { 238, "Ямайка", "Yamayka" },
                    { 239, "Япония", "Yaponiya" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "аниме", "anime" },
                    { 2, "биография", "biografiya" },
                    { 3, "боевик", "boevik" },
                    { 4, "вестерн", "vestern" },
                    { 5, "военный", "voennyy" },
                    { 6, "детектив", "detektiv" },
                    { 7, "детский", "detskiy" },
                    { 8, "для взрослых", "dlya-vzroslyh" },
                    { 9, "документальный", "dokumentalnyy" },
                    { 10, "драма", "drama" },
                    { 11, "игра", "igra" },
                    { 12, "история", "istoriya" },
                    { 13, "комедия", "komediya" },
                    { 14, "концерт", "koncert" },
                    { 15, "короткометражка", "korotkometrazhka" },
                    { 16, "криминал", "kriminal" },
                    { 17, "мелодрама", "melodrama" },
                    { 18, "музыка", "muzyka" },
                    { 19, "мультфильм", "multfilm" },
                    { 20, "мюзикл", "myuzikl" },
                    { 21, "новости", "novosti" },
                    { 22, "приключения", "priklyucheniya" },
                    { 23, "реальное ТВ", "realnoe-TV" },
                    { 24, "семейный", "semeynyy" },
                    { 25, "спорт", "sport" },
                    { 26, "ток-шоу", "tok-shou" },
                    { 27, "триллер", "triller" },
                    { 28, "ужасы", "uzhasy" },
                    { 29, "фантастика", "fantastika" },
                    { 30, "фильм-нуар", "film-nuar" },
                    { 31, "фэнтези", "fentezi" },
                    { 32, "церемония", "ceremoniya" }
                });

            migrationBuilder.InsertData(
                table: "Professions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "актеры" },
                    { 2, "актеры дубляжа" },
                    { 3, "композиторы" },
                    { 4, "монтажеры" },
                    { 5, "операторы" },
                    { 6, "продюсеры" },
                    { 7, "редакторы" },
                    { 8, "режиссеры" },
                    { 9, "художники" }
                });

            migrationBuilder.InsertData(
                table: "Types",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "animated-series", "animated-series" },
                    { 2, "anime", "anime" },
                    { 3, "cartoon", "cartoon" },
                    { 4, "mini-series", "mini-series" },
                    { 5, "movie", "movie" },
                    { 6, "tv-series", "tv-series" },
                    { 7, "tv-show", "tv-show" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Professions",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Types",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
