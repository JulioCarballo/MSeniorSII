using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSeniorSII
{
    public class General
    {
        public static Dictionary<string, string> Paises = new Dictionary<string, string>()
        {

            {"AF", "Afganistán"},
            {"AX", "Åland, Islas"},
            {"AL", "Albania"},
            {"DE", "Alemania"},
            {"AD", "Andorra"},
            {"AO", "Angola"},
            {"AI", "Anguila"},
            {"AQ", "Antártida"},
            {"AG", "Antigua y Barbuda"},
            {"SA", "Arabia Saudita"},
            {"DZ", "Argelia"},
            {"AR", "Argentina"},
            {"AM", "Armenia"},
            {"AW", "Aruba"},
            {"AU", "Australia"},
            {"AT", "Austria"},
            {"AZ", "Azerbaiyán"},
            {"BS", "Bahamas (las)"},
            {"BD", "Bangladesh"},
            {"BB", "Barbados"},
            {"BH", "Bahrein"},
            {"BE", "Bélgica"},
            {"BZ", "Belice"},
            {"BJ", "Benin"},
            {"BM", "Bermudas"},
            {"BY", "Belarús"},
            {"BO", "Bolivia (Estado Plurinacional de)"},
            {"BQ", "Bonaire, San Eustaquio y Saba"},
            {"BA", "Bosnia y Herzegovina"},
            {"BW", "Botswana"},
            {"BR", "Brasil"},
            {"BN", "Brunei Darussalam"},
            {"BG", "Bulgaria"},
            {"BF", "Burkina Faso"},
            {"BI", "Burundi"},
            {"BT", "Bhután"},
            {"CV", "Cabo Verde"},
            {"KH", "Camboya"},
            {"CM", "Camerún"},
            {"CA", "Canadá"},
            {"QA", "Qatar"},
            {"TD", "Chad"},
            {"CL", "Chile"},
            {"CN", "China"},
            {"CY", "Chipre"},
            {"CO", "Colombia"},
            {"KM", "Comoras (las)"},
            {"KP", "Corea (la República Popular Democrática de)"},
            {"KR", "Corea (la República de)"},
            {"CI", "Côte d'Ivoire"},
            {"CR", "Costa Rica"},
            {"HR", "Croacia"},
            {"CU", "Cuba"},
            {"CW", "Curaçao"},
            {"DK", "Dinamarca"},
            {"DM", "Dominica"},
            {"EC", "Ecuador"},
            {"EG", "Egipto"},
            {"SV", "El Salvador"},
            {"AE", "Emiratos Árabes Unidos (los)"},
            {"ER", "Eritrea"},
            {"SK", "Eslovaquia"},
            {"SI", "Eslovenia"},
            {"ES", "España"},
            {"US", "Estados Unidos de América (los)"},
            {"EE", "Estonia"},
            {"ET", "Etiopía"},
            {"PH", "Filipinas (las)"},
            {"FI", "Finlandia"},
            {"FJ", "Fiji"},
            {"FR", "Francia"},
            {"GA", "Gabón"},
            {"GM", "Gambia (la)"},
            {"GE", "Georgia"},
            {"GH", "Ghana"},
            {"GI", "Gibraltar"},
            {"GD", "Granada"},
            {"GR", "Grecia"},
            {"GL", "Groenlandia"},
            {"GP", "Guadeloupe"},
            {"GU", "Guam"},
            {"GT", "Guatemala"},
            {"GF", "Guayana Francesa"},
            {"GG", "Guernsey"},
            {"GN", "Guinea"},
            {"GW", "Guinea Bissau"},
            {"GQ", "Guinea Ecuatorial"},
            {"GY", "Guyana"},
            {"HT", "Haití"},
            {"HN", "Honduras"},
            {"HK", "Hong Kong"},
            {"HU", "Hungría"},
            {"IN", "India"},
            {"ID", "Indonesia"},
            {"IQ", "Iraq"},
            {"IR", "Irán (República Islámica de)"},
            {"IE", "Irlanda"},
            {"BV", "Bouvet, Isla"},
            {"IM", "Isla de Man"},
            {"CX", "Navidad, Isla de"},
            {"IS", "Islandia"},
            {"KY", "Caimán, (las) Islas"},
            {"CC", "Cocos / Keeling, (las) Islas"},
            {"CK", "Cook, (las) Islas"},
            {"FO", "Feroe, (las) Islas"},
            {"GS", "Georgia del Sur (la) y las Islas Sandwich del Sur"},
            {"HM", "Heard (Isla) e Islas McDonald"},
            {"FK", "Malvinas [Falkland], (las) Islas"},
            {"MP", "Marianas del Norte, (las) Islas"},
            {"MH", "Marshall, (las) Islas"},
            {"PN", "Pitcairn"},
            {"SB", "Salomón, Islas"},
            {"TC", "Turcas y Caicos, (las) Islas"},
            {"UM", "Islas Ultramarinas Menores de los Estados Unidos (las)"},
            {"VG", "Vírgenes británicas, Islas"},
            {"VI", "Vírgenes de los Estados Unidos, Islas"},
            {"IL", "Israel"},
            {"IT", "Italia"},
            {"JM", "Jamaica"},
            {"JP", "Japón"},
            {"JE", "Jersey"},
            {"JO", "Jordania"},
            {"KZ", "Kazajstán"},
            {"KE", "Kenya"},
            {"KG", "Kirguistán"},
            {"KI", "Kiribati"},
            {"KW", "Kuwait"},
            {"LA", "Lao, (la) República Democrática Popular"},
            {"LS", "Lesotho"},
            {"LV", "Letonia"},
            {"LB", "Líbano"},
            {"LR", "Liberia"},
            {"LY", "Libia"},
            {"LI", "Liechtenstein"},
            {"LT", "Lituania"},
            {"LU", "Luxemburgo"},
            {"MO", "Macao"},
            {"MK", "Macedonia (la ex República Yugoslava de)"},
            {"MG", "Madagascar"},
            {"MY", "Malasia"},
            {"MW", "Malawi"},
            {"MV", "Maldivas"},
            {"ML", "Malí"},
            {"MT", "Malta"},
            {"MA", "Marruecos"},
            {"MQ", "Martinique"},
            {"MU", "Mauricio"},
            {"MR", "Mauritania"},
            {"YT", "Mayotte"},
            {"MX", "México"},
            {"FM", "Micronesia (Estados Federados de)"},
            {"MD", "Moldova (la República de)"},
            {"MC", "Mónaco"},
            {"MN", "Mongolia"},
            {"ME", "Montenegro"},
            {"MS", "Montserrat"},
            {"MZ", "Mozambique"},
            {"MM", "Myanmar"},
            {"NA", "Namibia"},
            {"NR", "Nauru"},
            {"NP", "Nepal"},
            {"NI", "Nicaragua"},
            {"NE", "Níger (el)"},
            {"NG", "Nigeria"},
            {"NU", "Niue"},
            {"NF", "Norfolk, Isla"},
            {"NO", "Noruega"},
            {"NC", "Nueva Caledonia"},
            {"NZ", "Nueva Zelandia"},
            {"OM", "Omán"},
            {"NL", "Países Bajos (los)"},
            {"PK", "Pakistán"},
            {"PW", "Palau"},
            {"PS", "Palestina, Estado de"},
            {"PA", "Panamá"},
            {"PG", "Papua Nueva Guinea"},
            {"PY", "Paraguay"},
            {"PE", "Perú"},
            {"PF", "Polinesia Francesa"},
            {"PL", "Polonia"},
            {"PT", "Portugal"},
            {"PR", "Puerto Rico"},
            {"GB", "Reino Unido de Gran Bretaña e Irlanda del Norte (el)"},
            {"EH", "Sahara Occidental"},
            {"CF", "República Centroafricana (la)"},
            {"CZ", "Chequia"},
            {"CG", "Congo (el)"},
            {"CD", "Congo (la República Democrática del)"},
            {"DO", "Dominicana, (la) República"},
            {"RE", "Reunión"},
            {"RW", "Rwanda"},
            {"RO", "Rumania"},
            {"RU", "Rusia, (la) Federación de"},
            {"WS", "Samoa"},
            {"AS", "Samoa Americana"},
            {"BL", "Saint Barthélemy"},
            {"KN", "Saint Kitts y Nevis"},
            {"SM", "San Marino"},
            {"MF", "Saint Martin (parte francesa)"},
            {"PM", "San Pedro y Miquelón"},
            {"VC", "San Vicente y las Granadinas"},
            {"SH", "Santa Helena, Ascensión y Tristán de Acuña"},
            {"LC", "Santa Lucía"},
            {"ST", "Santo Tomé y Príncipe"},
            {"SN", "Senegal"},
            {"RS", "Serbia"},
            {"SC", "Seychelles"},
            {"SL", "Sierra leona"},
            {"SG", "Singapur"},
            {"SX", "Sint Maarten (parte neerlandesa)"},
            {"SY", "República Árabe Siria"},
            {"SO", "Somalia"},
            {"LK", "Sri Lanka"},
            {"SZ", "Swazilandia"},
            {"ZA", "Sudáfrica"},
            {"SD", "Sudán (el)"},
            {"SS", "Sudán del Sur"},
            {"SE", "Suecia"},
            {"CH", "Suiza"},
            {"SR", "Suriname"},
            {"SJ", "Svalbard y Jan Mayen"},
            {"TH", "Tailandia"},
            {"TW", "Taiwán (Provincia de China)"},
            {"TZ", "Tanzania, República Unida de"},
            {"TJ", "Tayikistán"},
            {"IO", "Territorio Británico del Océano Índico (el)"},
            {"TF", "Tierras Australes Francesas (las)"},
            {"TL", "Timor-Leste"},
            {"TG", "Togo"},
            {"TK", "Tokelau"},
            {"TO", "Tonga"},
            {"TT", "Trinidad y Tabago"},
            {"TN", "Túnez"},
            {"TM", "Turkmenistán"},
            {"TR", "Turquía"},
            {"TV", "Tuvalu"},
            {"UA", "Ucrania"},
            {"UG", "Uganda"},
            {"UY", "Uruguay"},
            {"UZ", "Uzbekistán"},
            {"VU", "Vanuatu"},
            {"VA", "Santa Sede (la)"},
            {"VE", "Venezuela (República Bolivariana de)"},
            {"VN", "Viet Nam"},
            {"WF", "Wallis y Futuna"},
            {"YE", "Yemen"},
            {"DJ", "Djibouti"},
            {"ZM", "Zambia"},
            {"ZW", "Zimbabwe"},

        };

        public static Dictionary<string, string> EstadosMiembros = new Dictionary<string, string>()
        {

            {"DE", "Alemania"},
            {"AT", "Austria"},
            {"BE", "Bélgica"},
            {"BG", "Bulgaria"},
            {"CZ", "Checa, Republica"},
            {"CY", "Chipre"},
            {"HR", "Croacia"},
            {"DK", "Dinamarca"},
            {"SK", "Eslovaquia"},
            {"SI", "Eslovenia"},
            {"ES", "España"},
            {"EE", "Estonia"},
            {"FI", "Finlandia"},
            {"FR", "Francia"},
            {"GR", "Grecia"},
            {"HU", "Hungría"},
            {"IE", "Irlanda"},
            {"IT", "Italia"},
            {"LV", "Letonia"},
            {"LT", "Lituania"},
            {"LU", "Luxemburgo"},
            {"MT", "Malta"},
            {"NL", "Países Bajos"},
            {"PL", "Polonia"},
            {"PT", "Portugal"},
            {"GB", "Reino Unido"},
            {"RU", "Rumanía" },
            {"SE", "Suecia"},
        };

        public static Dictionary<string, string> TipoOperIntracom = new Dictionary<string, string>()
        {

            {"A", @"El envío o recepción de bienes para la realización de los informes parciales o trabajos
                    mencionados en el artículo 70, apartado uno, número 7º, de la Ley del Impuesto (Ley 37/1992)."},
            {"B", @"Las transferencias de bienes y las adquisiciones intracomunitarias de bienes comprendidas 
                    en los artículos 9, apartado 3º, y 16, apartado 2º, de la Ley del Impuesto (Ley 37/1992)"},
        };

        public static Dictionary<string, string> ClaveDeclarado = new Dictionary<string, string>()
        {

            {"D", "Declarante" },
            {"R", "Remitente" },
        };

        /// <summary>
        /// Abre el formulario de búsqueda de paises.
        /// </summary>
        /// <returns>Pais seleccionado.</returns>
        public static string GetCountry()
        {
            FormCountries frmCountries = new FormCountries();
            frmCountries.ShowDialog();
            return frmCountries.SelectdCountry;
        }

        /// <summary>
        /// Abre el formulario de búsqueda de Estados Miembros de la UE.
        /// </summary>
        /// <returns>Estado seleccionado.</returns>
        public static string GetEstado()
        {
            FormEstadosUE frmEstados = new FormEstadosUE();
            frmEstados.ShowDialog();
            return frmEstados.SelectdCountry;
        }

        /// <summary>
        /// Abre el formulario de búsqueda del tipo de Operación instracomunitaria.
        /// </summary>
        /// <returns>Tipo Operacion seleccionada.</returns>
        public static string GetTipoOperIntracom()
        {
            FormTipoOperIntracom frmTipoOperIntra = new FormTipoOperIntracom();
            frmTipoOperIntra.ShowDialog();
            return frmTipoOperIntra.SelectedTipoOperIntra;
        }

        /// <summary>
        /// Abre el formulario de búsqueda de Clave Declarado para las operaciones intracomunitarias.
        /// </summary>
        /// <returns>Clave Declarado seleccionado.</returns>
        public static string GetClaveDeclarado()
        {
            FormClaveDeclarado frmClaveDeclarado = new FormClaveDeclarado();
            frmClaveDeclarado.ShowDialog();
            return frmClaveDeclarado.SelectedClave;
        }
    }
}
