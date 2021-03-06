﻿using HiQoDataGenerator.DAL.Models.DataSetModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Extensions
{
    public static class CountriesSeeds
    {
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DefinedDatasetValue>()
                .HasData(
                    new DefinedDatasetValue { Id = 1103, Value = "Afghanistan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1104, Value = "Albania", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1105, Value = "Algeria", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1106, Value = "American Samoa", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1107, Value = "Andorra", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1108, Value = "Angola", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1109, Value = "Anguilla", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1110, Value = "Antarctica", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1111, Value = "Antigua and Barbuda", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1112, Value = "Argentina", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1113, Value = "Armenia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1114, Value = "Aruba", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1115, Value = "Australia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1116, Value = "Austria", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1117, Value = "Azerbaijan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1118, Value = "Bahamas", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1119, Value = "Bahrain", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1120, Value = "Bangladesh", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1121, Value = "Barbados", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1122, Value = "Belarus", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1123, Value = "Belgium", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1124, Value = "Belize", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1125, Value = "Benin", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1126, Value = "Bermuda", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1127, Value = "Bhutan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1128, Value = "Bolivia (Plurinational State of)", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1129, Value = "Bonaire", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1130, Value = "Bosnia and Herzegovina", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1131, Value = "Botswana", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1132, Value = "Bouvet Island", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1133, Value = "Brazil", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1134, Value = "British Indian Ocean Territory", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1135, Value = "Brunei Darussalam", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1136, Value = "Bulgaria", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1137, Value = "Burkina Faso", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1138, Value = "Burundi", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1139, Value = "Cabo Verde", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1140, Value = "Cambodia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1141, Value = "Cameroon", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1142, Value = "Canada", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1143, Value = "Cayman Islands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1144, Value = "Central African Republic", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1145, Value = "Chad", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1146, Value = "Chile", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1147, Value = "China", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1148, Value = "Christmas Island", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1149, Value = "Cocos (Keeling) Islands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1150, Value = "Colombia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1151, Value = "Comoros", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1152, Value = "Congo", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1153, Value = "Congo", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1154, Value = "Cook Islands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1155, Value = "Costa Rica", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1156, Value = "Côte d'Ivoire", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1157, Value = "Croatia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1158, Value = "Cuba", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1159, Value = "Cyprus", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1160, Value = "Czechia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1161, Value = "Denmark", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1162, Value = "Djibouti", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1163, Value = "Dominica", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1164, Value = "Dominican Republic", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1165, Value = "Ecuador", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1166, Value = "Egypt", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1167, Value = "El Salvador", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1168, Value = "Equatorial Guinea", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1169, Value = "Eritrea", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1170, Value = "Estonia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1171, Value = "Eswatini", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1172, Value = "Ethiopia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1173, Value = "Falkland Islands (Malvinas)", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1174, Value = "Faroe Islands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1175, Value = "Fiji", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1176, Value = "Finland", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1177, Value = "France", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1178, Value = "French Guiana", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1179, Value = "French Polynesia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1180, Value = "French Southern Territories", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1181, Value = "Gabon", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1182, Value = "Gambia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1183, Value = "Georgia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1184, Value = "Germany", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1185, Value = "Ghana", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1186, Value = "Gibraltar", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1187, Value = "Greece", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1188, Value = "Greenland", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1189, Value = "Grenada", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1190, Value = "Guadeloupe", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1191, Value = "Guam", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1192, Value = "Guatemala", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1193, Value = "Guernsey", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1194, Value = "Guinea", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1195, Value = "Guinea-Bissau", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1196, Value = "Guyana", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1197, Value = "Haiti", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1198, Value = "Heard Island and McDonald Islands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1199, Value = "Holy See", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1200, Value = "Honduras", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1201, Value = "Hong Kong", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1202, Value = "Hungary", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1203, Value = "Iceland", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1204, Value = "India", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1205, Value = "Indonesia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1206, Value = "Iran (Islamic Republic of)", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1207, Value = "Iraq", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1208, Value = "Ireland", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1209, Value = "Isle of Man", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1210, Value = "Israel", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1211, Value = "Italy", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1212, Value = "Jamaica", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1213, Value = "Japan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1214, Value = "Jersey", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1215, Value = "Jordan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1216, Value = "Kazakhstan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1217, Value = "Kenya", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1218, Value = "Kiribati", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1219, Value = "Korea (Democratic People's Republic of)", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1220, Value = "Korea", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1221, Value = "Kuwait", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1222, Value = "Kyrgyzstan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1223, Value = "Lao People's Democratic Republic", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1224, Value = "Latvia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1225, Value = "Lebanon", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1226, Value = "Lesotho", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1227, Value = "Liberia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1228, Value = "Libya", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1229, Value = "Liechtenstein", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1230, Value = "Lithuania", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1231, Value = "Luxembourg", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1232, Value = "Macao", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1233, Value = "Madagascar", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1234, Value = "Malawi", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1235, Value = "Malaysia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1236, Value = "Maldives", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1237, Value = "Mali", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1238, Value = "Malta", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1239, Value = "Marshall Islands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1240, Value = "Martinique", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1241, Value = "Mauritania", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1242, Value = "Mauritius", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1243, Value = "Mayotte", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1244, Value = "Mexico", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1245, Value = "Micronesia (Federated States of)", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1246, Value = "Moldova", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1247, Value = "Monaco", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1248, Value = "Mongolia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1249, Value = "Montenegro", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1250, Value = "Montserrat", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1251, Value = "Morocco", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1252, Value = "Mozambique", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1253, Value = "Myanmar", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1254, Value = "Namibia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1255, Value = "Nauru", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1256, Value = "Nepal", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1257, Value = "Netherlands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1258, Value = "New Caledonia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1259, Value = "New Zealand", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1260, Value = "Nicaragua", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1261, Value = "Niger", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1262, Value = "Nigeria", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1263, Value = "Niue", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1264, Value = "Norfolk Island", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1265, Value = "North Macedonia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1266, Value = "Northern Mariana Islands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1267, Value = "Norway", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1268, Value = "Oman", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1269, Value = "Pakistan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1270, Value = "Palau", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1271, Value = "Palestine", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1272, Value = "Panama", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1273, Value = "Papua New Guinea", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1274, Value = "Paraguay", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1275, Value = "Peru", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1276, Value = "Philippines", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1277, Value = "Pitcairn", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1278, Value = "Poland", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1279, Value = "Portugal", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1280, Value = "Puerto Rico", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1281, Value = "Qatar", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1282, Value = "Romania", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1283, Value = "Russian Federation", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1284, Value = "Rwanda", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1285, Value = "Saint Barthélemy", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1286, Value = "Saint Helena", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1287, Value = "Saint Kitts and Nevis", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1288, Value = "Saint Lucia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1289, Value = "Saint Martin (French part)", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1290, Value = "Saint Pierre and Miquelon", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1291, Value = "Saint Vincent and the Grenadines", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1292, Value = "Samoa", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1293, Value = "San Marino", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1294, Value = "Sao Tome and Principe", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1295, Value = "Saudi Arabia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1296, Value = "Senegal", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1297, Value = "Serbia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1298, Value = "Seychelles", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1299, Value = "Sierra Leone", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1300, Value = "Singapore", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1301, Value = "Sint Maarten (Dutch part)", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1302, Value = "Slovakia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1303, Value = "Slovenia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1304, Value = "Solomon Islands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1305, Value = "Somalia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1306, Value = "South Africa", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1307, Value = "South Georgia and the South Sandwich Islands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1308, Value = "South Sudan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1309, Value = "Spain", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1310, Value = "Sri Lanka", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1311, Value = "Sudan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1312, Value = "Suriname", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1313, Value = "Svalbard and Jan Mayen", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1314, Value = "Sweden", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1315, Value = "Switzerland", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1316, Value = "Syrian Arab Republic", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1317, Value = "Taiwan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1318, Value = "Tajikistan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1319, Value = "Tanzania", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1320, Value = "Thailand", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1321, Value = "Timor-Leste", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1322, Value = "Togo", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1323, Value = "Tokelau", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1324, Value = "Tonga", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1325, Value = "Trinidad and Tobago", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1326, Value = "Tunisia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1327, Value = "Turkey", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1328, Value = "Turkmenistan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1329, Value = "Turks and Caicos Islands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1330, Value = "Tuvalu", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1331, Value = "Uganda", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1332, Value = "Ukraine", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1333, Value = "United Arab Emirates", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1334, Value = "United Kingdom of Great Britain and Northern Ireland", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1335, Value = "United States of America", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1336, Value = "United States Minor Outlying Islands", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1337, Value = "Uruguay", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1338, Value = "Uzbekistan", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1339, Value = "Vanuatu", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1340, Value = "Venezuela (Bolivarian Republic of)", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1341, Value = "Viet Nam", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1342, Value = "Virgin Islands (British)", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1343, Value = "Virgin Islands (U.S.)", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1344, Value = "Wallis and Futuna", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1345, Value = "Western Sahara", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1346, Value = "Yemen", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1347, Value = "Zambia", DatasetId = 4 },
                    new DefinedDatasetValue { Id = 1348, Value = "Zimbabwe", DatasetId = 4 }
                );
        }
    }
}
