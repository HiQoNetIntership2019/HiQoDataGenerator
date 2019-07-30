using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Add_CountriesSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Datasets",
                columns: new[] { "Id", "IsDefined", "Name", "TypeId" },
                values: new object[] { 4, true, "Countries", 6 });

            migrationBuilder.InsertData(
                table: "DefinedDatasets",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 4, "Countries", 6 });

            migrationBuilder.InsertData(
                table: "DefinedDatasetsValues",
                columns: new[] { "Id", "DatasetId", "Value" },
                values: new object[,]
                {
                    { 1103, 4, "Afghanistan" },
                    { 1259, 4, "New Zealand" },
                    { 1260, 4, "Nicaragua" },
                    { 1261, 4, "Niger" },
                    { 1262, 4, "Nigeria" },
                    { 1263, 4, "Niue" },
                    { 1264, 4, "Norfolk Island" },
                    { 1265, 4, "North Macedonia" },
                    { 1266, 4, "Northern Mariana Islands" },
                    { 1267, 4, "Norway" },
                    { 1268, 4, "Oman" },
                    { 1269, 4, "Pakistan" },
                    { 1270, 4, "Palau" },
                    { 1258, 4, "New Caledonia" },
                    { 1271, 4, "Palestine" },
                    { 1273, 4, "Papua New Guinea" },
                    { 1274, 4, "Paraguay" },
                    { 1275, 4, "Peru" },
                    { 1276, 4, "Philippines" },
                    { 1277, 4, "Pitcairn" },
                    { 1278, 4, "Poland" },
                    { 1279, 4, "Portugal" },
                    { 1280, 4, "Puerto Rico" },
                    { 1281, 4, "Qatar" },
                    { 1282, 4, "Romania" },
                    { 1283, 4, "Russian Federation" },
                    { 1284, 4, "Rwanda" },
                    { 1272, 4, "Panama" },
                    { 1257, 4, "Netherlands" },
                    { 1256, 4, "Nepal" },
                    { 1255, 4, "Nauru" },
                    { 1228, 4, "Libya" },
                    { 1229, 4, "Liechtenstein" },
                    { 1230, 4, "Lithuania" },
                    { 1231, 4, "Luxembourg" },
                    { 1232, 4, "Macao" },
                    { 1233, 4, "Madagascar" },
                    { 1234, 4, "Malawi" },
                    { 1235, 4, "Malaysia" },
                    { 1236, 4, "Maldives" },
                    { 1237, 4, "Mali" },
                    { 1238, 4, "Malta" },
                    { 1239, 4, "Marshall Islands" },
                    { 1240, 4, "Martinique" },
                    { 1241, 4, "Mauritania" },
                    { 1242, 4, "Mauritius" },
                    { 1243, 4, "Mayotte" },
                    { 1244, 4, "Mexico" },
                    { 1245, 4, "Micronesia (Federated States of)" },
                    { 1246, 4, "Moldova" },
                    { 1247, 4, "Monaco" },
                    { 1248, 4, "Mongolia" },
                    { 1249, 4, "Montenegro" },
                    { 1250, 4, "Montserrat" },
                    { 1251, 4, "Morocco" },
                    { 1252, 4, "Mozambique" },
                    { 1253, 4, "Myanmar" },
                    { 1254, 4, "Namibia" },
                    { 1285, 4, "Saint Barthélemy" },
                    { 1286, 4, "Saint Helena" },
                    { 1287, 4, "Saint Kitts and Nevis" },
                    { 1288, 4, "Saint Lucia" },
                    { 1320, 4, "Thailand" },
                    { 1321, 4, "Timor-Leste" },
                    { 1322, 4, "Togo" },
                    { 1323, 4, "Tokelau" },
                    { 1324, 4, "Tonga" },
                    { 1325, 4, "Trinidad and Tobago" },
                    { 1326, 4, "Tunisia" },
                    { 1327, 4, "Turkey" },
                    { 1328, 4, "Turkmenistan" },
                    { 1329, 4, "Turks and Caicos Islands" },
                    { 1330, 4, "Tuvalu" },
                    { 1331, 4, "Uganda" },
                    { 1332, 4, "Ukraine" },
                    { 1333, 4, "United Arab Emirates" },
                    { 1334, 4, "United Kingdom of Great Britain and Northern Ireland" },
                    { 1335, 4, "United States of America" },
                    { 1336, 4, "United States Minor Outlying Islands" },
                    { 1337, 4, "Uruguay" },
                    { 1338, 4, "Uzbekistan" },
                    { 1339, 4, "Vanuatu" },
                    { 1340, 4, "Venezuela (Bolivarian Republic of)" },
                    { 1341, 4, "Viet Nam" },
                    { 1342, 4, "Virgin Islands (British)" },
                    { 1343, 4, "Virgin Islands (U.S.)" },
                    { 1344, 4, "Wallis and Futuna" },
                    { 1345, 4, "Western Sahara" },
                    { 1346, 4, "Yemen" },
                    { 1319, 4, "Tanzania" },
                    { 1227, 4, "Liberia" },
                    { 1318, 4, "Tajikistan" },
                    { 1316, 4, "Syrian Arab Republic" },
                    { 1289, 4, "Saint Martin (French part)" },
                    { 1290, 4, "Saint Pierre and Miquelon" },
                    { 1291, 4, "Saint Vincent and the Grenadines" },
                    { 1292, 4, "Samoa" },
                    { 1293, 4, "San Marino" },
                    { 1294, 4, "Sao Tome and Principe" },
                    { 1295, 4, "Saudi Arabia" },
                    { 1296, 4, "Senegal" },
                    { 1297, 4, "Serbia" },
                    { 1298, 4, "Seychelles" },
                    { 1299, 4, "Sierra Leone" },
                    { 1300, 4, "Singapore" },
                    { 1301, 4, "Sint Maarten (Dutch part)" },
                    { 1302, 4, "Slovakia" },
                    { 1303, 4, "Slovenia" },
                    { 1304, 4, "Solomon Islands" },
                    { 1305, 4, "Somalia" },
                    { 1306, 4, "South Africa" },
                    { 1307, 4, "South Georgia and the South Sandwich Islands" },
                    { 1308, 4, "South Sudan" },
                    { 1309, 4, "Spain" },
                    { 1310, 4, "Sri Lanka" },
                    { 1311, 4, "Sudan" },
                    { 1312, 4, "Suriname" },
                    { 1313, 4, "Svalbard and Jan Mayen" },
                    { 1314, 4, "Sweden" },
                    { 1315, 4, "Switzerland" },
                    { 1317, 4, "Taiwan" },
                    { 1226, 4, "Lesotho" },
                    { 1225, 4, "Lebanon" },
                    { 1224, 4, "Latvia" },
                    { 1135, 4, "Brunei Darussalam" },
                    { 1136, 4, "Bulgaria" },
                    { 1137, 4, "Burkina Faso" },
                    { 1138, 4, "Burundi" },
                    { 1139, 4, "Cabo Verde" },
                    { 1140, 4, "Cambodia" },
                    { 1141, 4, "Cameroon" },
                    { 1142, 4, "Canada" },
                    { 1143, 4, "Cayman Islands" },
                    { 1144, 4, "Central African Republic" },
                    { 1145, 4, "Chad" },
                    { 1146, 4, "Chile" },
                    { 1147, 4, "China" },
                    { 1148, 4, "Christmas Island" },
                    { 1149, 4, "Cocos (Keeling) Islands" },
                    { 1150, 4, "Colombia" },
                    { 1151, 4, "Comoros" },
                    { 1152, 4, "Congo" },
                    { 1153, 4, "Congo" },
                    { 1154, 4, "Cook Islands" },
                    { 1155, 4, "Costa Rica" },
                    { 1156, 4, "Côte d'Ivoire" },
                    { 1157, 4, "Croatia" },
                    { 1158, 4, "Cuba" },
                    { 1159, 4, "Cyprus" },
                    { 1160, 4, "Czechia" },
                    { 1161, 4, "Denmark" },
                    { 1134, 4, "British Indian Ocean Territory" },
                    { 1162, 4, "Djibouti" },
                    { 1133, 4, "Brazil" },
                    { 1131, 4, "Botswana" },
                    { 1104, 4, "Albania" },
                    { 1105, 4, "Algeria" },
                    { 1106, 4, "American Samoa" },
                    { 1107, 4, "Andorra" },
                    { 1108, 4, "Angola" },
                    { 1109, 4, "Anguilla" },
                    { 1110, 4, "Antarctica" },
                    { 1111, 4, "Antigua and Barbuda" },
                    { 1112, 4, "Argentina" },
                    { 1113, 4, "Armenia" },
                    { 1114, 4, "Aruba" },
                    { 1115, 4, "Australia" },
                    { 1116, 4, "Austria" },
                    { 1117, 4, "Azerbaijan" },
                    { 1118, 4, "Bahamas" },
                    { 1119, 4, "Bahrain" },
                    { 1120, 4, "Bangladesh" },
                    { 1121, 4, "Barbados" },
                    { 1122, 4, "Belarus" },
                    { 1123, 4, "Belgium" },
                    { 1124, 4, "Belize" },
                    { 1125, 4, "Benin" },
                    { 1126, 4, "Bermuda" },
                    { 1127, 4, "Bhutan" },
                    { 1128, 4, "Bolivia (Plurinational State of)" },
                    { 1129, 4, "Bonaire" },
                    { 1130, 4, "Bosnia and Herzegovina" },
                    { 1132, 4, "Bouvet Island" },
                    { 1347, 4, "Zambia" },
                    { 1163, 4, "Dominica" },
                    { 1165, 4, "Ecuador" },
                    { 1197, 4, "Haiti" },
                    { 1198, 4, "Heard Island and McDonald Islands" },
                    { 1199, 4, "Holy See" },
                    { 1200, 4, "Honduras" },
                    { 1201, 4, "Hong Kong" },
                    { 1202, 4, "Hungary" },
                    { 1203, 4, "Iceland" },
                    { 1204, 4, "India" },
                    { 1205, 4, "Indonesia" },
                    { 1206, 4, "Iran (Islamic Republic of)" },
                    { 1207, 4, "Iraq" },
                    { 1208, 4, "Ireland" },
                    { 1209, 4, "Isle of Man" },
                    { 1210, 4, "Israel" },
                    { 1211, 4, "Italy" },
                    { 1212, 4, "Jamaica" },
                    { 1213, 4, "Japan" },
                    { 1214, 4, "Jersey" },
                    { 1215, 4, "Jordan" },
                    { 1216, 4, "Kazakhstan" },
                    { 1217, 4, "Kenya" },
                    { 1218, 4, "Kiribati" },
                    { 1219, 4, "Korea (Democratic People's Republic of)" },
                    { 1220, 4, "Korea" },
                    { 1221, 4, "Kuwait" },
                    { 1222, 4, "Kyrgyzstan" },
                    { 1223, 4, "Lao People's Democratic Republic" },
                    { 1196, 4, "Guyana" },
                    { 1164, 4, "Dominican Republic" },
                    { 1195, 4, "Guinea-Bissau" },
                    { 1193, 4, "Guernsey" },
                    { 1166, 4, "Egypt" },
                    { 1167, 4, "El Salvador" },
                    { 1168, 4, "Equatorial Guinea" },
                    { 1169, 4, "Eritrea" },
                    { 1170, 4, "Estonia" },
                    { 1171, 4, "Eswatini" },
                    { 1172, 4, "Ethiopia" },
                    { 1173, 4, "Falkland Islands (Malvinas)" },
                    { 1174, 4, "Faroe Islands" },
                    { 1175, 4, "Fiji" },
                    { 1176, 4, "Finland" },
                    { 1177, 4, "France" },
                    { 1178, 4, "French Guiana" },
                    { 1179, 4, "French Polynesia" },
                    { 1180, 4, "French Southern Territories" },
                    { 1181, 4, "Gabon" },
                    { 1182, 4, "Gambia" },
                    { 1183, 4, "Georgia" },
                    { 1184, 4, "Germany" },
                    { 1185, 4, "Ghana" },
                    { 1186, 4, "Gibraltar" },
                    { 1187, 4, "Greece" },
                    { 1188, 4, "Greenland" },
                    { 1189, 4, "Grenada" },
                    { 1190, 4, "Guadeloupe" },
                    { 1191, 4, "Guam" },
                    { 1192, 4, "Guatemala" },
                    { 1194, 4, "Guinea" },
                    { 1348, 4, "Zimbabwe" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Datasets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1103);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1104);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1105);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1106);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1107);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1108);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1109);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1110);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1111);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1112);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1113);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1114);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1115);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1116);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1117);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1118);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1119);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1120);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1121);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1122);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1123);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1124);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1125);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1126);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1127);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1128);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1129);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1130);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1131);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1132);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1133);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1134);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1135);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1136);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1137);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1138);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1139);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1140);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1141);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1142);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1143);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1144);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1145);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1146);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1147);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1148);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1149);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1150);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1151);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1152);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1153);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1154);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1155);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1156);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1157);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1158);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1159);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1160);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1161);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1162);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1163);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1164);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1165);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1166);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1167);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1168);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1169);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1170);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1171);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1172);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1173);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1174);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1175);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1176);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1177);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1178);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1179);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1180);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1181);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1182);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1183);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1184);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1185);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1186);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1187);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1188);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1189);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1190);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1191);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1192);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1193);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1194);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1195);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1196);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1197);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1198);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1199);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1200);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1201);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1202);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1203);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1204);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1205);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1206);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1207);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1208);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1209);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1210);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1211);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1212);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1213);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1214);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1215);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1216);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1217);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1218);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1219);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1220);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1221);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1222);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1223);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1224);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1225);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1226);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1227);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1228);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1229);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1230);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1231);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1232);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1233);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1234);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1235);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1236);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1237);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1238);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1239);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1240);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1241);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1242);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1243);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1244);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1245);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1246);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1247);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1248);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1249);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1250);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1251);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1252);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1253);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1254);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1255);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1256);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1257);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1258);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1259);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1260);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1261);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1262);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1263);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1264);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1265);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1266);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1267);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1268);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1269);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1270);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1271);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1272);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1273);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1274);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1275);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1276);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1277);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1278);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1279);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1280);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1281);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1282);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1283);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1284);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1285);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1286);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1287);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1288);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1289);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1290);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1291);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1292);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1293);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1294);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1295);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1296);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1297);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1298);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1299);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1300);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1301);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1302);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1303);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1304);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1305);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1306);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1307);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1308);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1309);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1310);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1311);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1312);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1313);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1314);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1315);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1316);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1317);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1318);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1319);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1320);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1321);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1322);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1323);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1324);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1325);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1326);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1327);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1328);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1329);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1330);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1331);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1332);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1333);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1334);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1335);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1336);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1337);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1338);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1339);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1340);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1341);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1342);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1343);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1344);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1345);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1346);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1347);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1348);

            migrationBuilder.DeleteData(
                table: "DefinedDatasets",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
