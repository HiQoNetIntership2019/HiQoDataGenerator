using Microsoft.EntityFrameworkCore.Migrations;

namespace HiQoDataGenerator.DAL.Migrations
{
    public partial class Add_DogBreedsSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Datasets",
                columns: new[] { "Id", "IsDefined", "Name", "TypeId" },
                values: new object[] { 3, true, "Dog Breeds", 6 });

            migrationBuilder.InsertData(
                table: "DefinedDatasets",
                columns: new[] { "Id", "Name", "TypeId" },
                values: new object[] { 3, "Dog Breeds", 6 });

            migrationBuilder.InsertData(
                table: "DefinedDatasetsValues",
                columns: new[] { "Id", "DatasetId", "Value" },
                values: new object[,]
                {
                    { 757, 3, "ENGLISH POINTER" },
                    { 991, 3, "CESKY TERRIER" },
                    { 990, 3, "BOHEMIAN WIRE-HAIRED POINTING GRIFFON" },
                    { 989, 3, "SLOVAKIAN HOUND" },
                    { 988, 3, "ALASKAN MALAMUTE" },
                    { 987, 3, "NORWEGIAN ELKHOUND GREY" },
                    { 986, 3, "HUNGARIAN HOUND - TRANSYLVANIAN SCENT HOUND" },
                    { 985, 3, "HUNGARIAN GREYHOUND" },
                    { 984, 3, "HUNGARIAN WIRE-HAIRED POINTER" },
                    { 983, 3, "MUDI" },
                    { 982, 3, "NORWEGIAN BUHUND" },
                    { 981, 3, "AUSTRALIAN SILKY TERRIER" },
                    { 980, 3, "GREAT DANE" },
                    { 979, 3, "XOLOITZCUINTLE" },
                    { 978, 3, "LITTLE LION DOG" },
                    { 977, 3, "DEUTSCH STICHELHAAR" },
                    { 976, 3, "TIBETAN SPANIEL" },
                    { 975, 3, "TIBETAN MASTIFF" },
                    { 992, 3, "ATLAS MOUNTAIN DOG (AIDI)" },
                    { 993, 3, "PHARAOH HOUND" },
                    { 994, 3, "MAJORCA MASTIFF" },
                    { 995, 3, "HAVANESE" },
                    { 1013, 3, "SIBERIAN HUSKY" },
                    { 1012, 3, "SALUKI" },
                    { 1011, 3, "NORWEGIAN ELKHOUND BLACK" },
                    { 1010, 3, "HALDEN HOUND" },
                    { 1009, 3, "HYGEN HOUND" },
                    { 1008, 3, "NORWEGIAN LUNDEHUND" },
                    { 1007, 3, "MASTIFF" },
                    { 1006, 3, "CHESAPEAKE BAY RETRIEVER" },
                    { 974, 3, "SERBIAN TRICOLOUR HOUND" },
                    { 1005, 3, "JAPANESE SPITZ" },
                    { 1003, 3, "TOSA" },
                    { 1002, 3, "JAPANESE TERRIER" },
                    { 1001, 3, "SHIBA" },
                    { 1000, 3, "AKITA" },
                    { 999, 3, "ALPINE DACHSBRACKE" },
                    { 998, 3, "PUG" },
                    { 997, 3, "TATRA SHEPHERD DOG" },
                    { 996, 3, "POLISH LOWLAND SHEEPDOG" },
                    { 1004, 3, "HOKKAIDO" },
                    { 1014, 3, "BEARDED COLLIE" },
                    { 973, 3, "AFGHAN HOUND" },
                    { 971, 3, "LANDSEER (EUROPEAN CONTINENTAL TYPE)" },
                    { 948, 3, "ITALIAN POINTING DOG" },
                    { 947, 3, "MAREMMA AND THE ABRUZZES SHEEPDOG" },
                    { 946, 3, "ITALIAN SIGHTHOUND" },
                    { 945, 3, "CIRNECO DELL'ETNA" },
                    { 944, 3, "ITALIAN ROUGH-HAIRED SEGUGIO" },
                    { 943, 3, "NEAPOLITAN MASTIFF" },
                    { 942, 3, "BOLOGNESE" },
                    { 941, 3, "ITALIAN VOLPINO" },
                    { 940, 3, "BERGAMASCO SHEPHERD DOG" },
                    { 939, 3, "BORZOI - RUSSIAN HUNTING SIGHTHOUND" },
                    { 938, 3, "KROMFOHRLÄNDER" },
                    { 937, 3, "BOUVIER DES FLANDRES" },
                    { 936, 3, "HOVAWART" },
                    { 935, 3, "FINNISH LAPPONIAN DOG" },
                    { 934, 3, "SLOUGHI" },
                    { 933, 3, "PORTUGUESE POINTING DOG" },
                    { 932, 3, "AFFENPINSCHER" },
                    { 949, 3, "NORWEGIAN HOUND" },
                    { 950, 3, "SPANISH HOUND" },
                    { 951, 3, "CHOW CHOW" },
                    { 952, 3, "JAPANESE CHIN" },
                    { 970, 3, "FILA BRASILEIRO" },
                    { 969, 3, "DRENTSCHE PARTRIDGE DOG" },
                    { 968, 3, "DUTCH SHEPHERD DOG" },
                    { 967, 3, "STABIJHOUN" },
                    { 966, 3, "FRISIAN WATER DOG" },
                    { 965, 3, "FRENCH WHITE & BLACK HOUND" },
                    { 964, 3, "FRENCH TRICOLOUR HOUND" },
                    { 963, 3, "CHIHUAHUA" },
                    { 972, 3, "LHASA APSO" },
                    { 962, 3, "BAVARIAN MOUNTAIN SCENT HOUND" },
                    { 960, 3, "BICHON FRISE" },
                    { 959, 3, "HELLENIC HOUND" },
                    { 958, 3, "HANOVERIAN SCENT HOUND" },
                    { 957, 3, "SAMOYED" },
                    { 956, 3, "CANADIAN ESKIMO DOG" },
                    { 955, 3, "TIBETAN TERRIER" },
                    { 954, 3, "SHIH TZU" },
                    { 953, 3, "PEKINGESE" },
                    { 961, 3, "PUDELPOINTER" },
                    { 1015, 3, "NORFOLK TERRIER" },
                    { 1016, 3, "CANAAN DOG" },
                    { 1017, 3, "GREENLAND DOG" },
                    { 1078, 3, "ITALIAN SHORT-HAIRED SEGUGIO" },
                    { 1077, 3, "SPANISH WATER DOG" },
                    { 1076, 3, "CENTRAL ASIA SHEPHERD DOG" },
                    { 1075, 3, "KOREA JINDO DOG" },
                    { 1074, 3, "POLISH GREYHOUND" },
                    { 1073, 3, "CZECHOSLOVAKIAN WOLFDOG" },
                    { 1072, 3, "KANGAL SHEPHERD DOG" },
                    { 1071, 3, "IRISH RED AND WHITE SETTER" },
                    { 1070, 3, "CANARIAN WARREN HOUND" },
                    { 1069, 3, "CAUCASIAN SHEPHERD DOG" },
                    { 1068, 3, "RUSSIAN BLACK TERRIER" },
                    { 1067, 3, "SOUTH RUSSIAN SHEPHERD DOG" },
                    { 1066, 3, "MEDIUM-SIZED ANGLO-FRENCH HOUND" },
                    { 1065, 3, "GREAT ANGLO-FRENCH WHITE & ORANGE HOUND" },
                    { 1064, 3, "GREAT ANGLO-FRENCH WHITE AND BLACK HOUND" },
                    { 1063, 3, "GREAT ANGLO-FRENCH TRICOLOUR HOUND" },
                    { 1062, 3, "MAJORCA SHEPHERD DOG" },
                    { 1079, 3, "THAI RIDGEBACK DOG" },
                    { 1080, 3, "PARSON RUSSELL TERRIER" },
                    { 1081, 3, "SAINT MIGUEL CATTLE DOG" },
                    { 1082, 3, "BRAZILIAN TERRIER" },
                    { 1100, 3, "MINIATURE BULL TERRIER" },
                    { 1099, 3, "THAI BANGKAEW DOG" },
                    { 1098, 3, "ROMANIAN BUCOVINA SHEPHERD" },
                    { 1097, 3, "DANISH-SWEDISH FARMDOG" },
                    { 1096, 3, "BOSNIAN AND HERZEGOVINIAN - CROATIAN SHEPHERD DOG" },
                    { 1095, 3, "POLISH HUNTING DOG" },
                    { 1094, 3, "CIMARRÓN URUGUAYO" },
                    { 1093, 3, "RUSSIAN TOY" },
                    { 1061, 3, "WIREHAIRED SLOVAKIAN POINTER" },
                    { 1092, 3, "AUSTRALIAN STUMPY TAIL CATTLE DOG" },
                    { 1090, 3, "ROMANIAN MIORITIC SHEPHERD DOG" },
                    { 1089, 3, "TAIWAN DOG" },
                    { 1088, 3, "WHITE SWISS SHEPHERD DOG" },
                    { 1087, 3, "DOGO CANARIO" },
                    { 1086, 3, "JACK RUSSELL TERRIER" },
                    { 1085, 3, "AMERICAN AKITA" },
                    { 1084, 3, "ITALIAN CANE CORSO" },
                    { 1083, 3, "AUSTRALIAN SHEPHERD" },
                    { 1091, 3, "ROMANIAN CARPATHIAN SHEPHERD DOG" },
                    { 1060, 3, "SHIKOKU" },
                    { 1059, 3, "KISHU" },
                    { 1058, 3, "KAI" },
                    { 1035, 3, "OTTERHOUND" },
                    { 1034, 3, "AUSTRALIAN KELPIE" },
                    { 1033, 3, "DOGO ARGENTINO" },
                    { 1032, 3, "EURASIAN" },
                    { 1031, 3, "BEAGLE HARRIER" },
                    { 1030, 3, "ICELANDIC SHEEPDOG" },
                    { 1029, 3, "CHINESE CRESTED DOG" },
                    { 1028, 3, "AUSTRALIAN CATTLE DOG" },
                    { 1036, 3, "HARRIER" },
                    { 1027, 3, "AMERICAN STAFFORDSHIRE TERRIER" },
                    { 1025, 3, "LAPPONIAN HERDER" },
                    { 1024, 3, "COTON DE TULEAR" },
                    { 1023, 3, "GRAND GRIFFON VENDEEN" },
                    { 1022, 3, "OLD DANISH POINTING DOG" },
                    { 1021, 3, "MONTENEGRIN MOUNTAIN HOUND" },
                    { 1020, 3, "KARST SHEPHERD DOG" },
                    { 1019, 3, "CROATIAN SHEPHERD DOG" },
                    { 1018, 3, "NORRBOTTENSPITZ" },
                    { 1026, 3, "SPANISH GREYHOUND" },
                    { 931, 3, "MINIATURE PINSCHER" },
                    { 1037, 3, "COLLIE SMOOTH" },
                    { 1039, 3, "ROMAGNA WATER DOG" },
                    { 1057, 3, "FRENCH WHITE AND ORANGE HOUND" },
                    { 1056, 3, "BROHOLMER" },
                    { 1055, 3, "NEDERLANDSE KOOIKERHONDJE" },
                    { 1054, 3, "DUTCH SCHAPENDOES" },
                    { 1053, 3, "NOVA SCOTIA DUCK TOLLING RETRIEVER" },
                    { 1052, 3, "SAARLOOS WOLFHOND" },
                    { 1051, 3, "PERUVIAN HAIRLESS DOG" },
                    { 1050, 3, "SHAR PEI" },
                    { 1038, 3, "BORDER COLLIE" },
                    { 1049, 3, "DUTCH SMOUSHOND" },
                    { 1047, 3, "WEST SIBERIAN LAIKA" },
                    { 1046, 3, "EAST SIBERIAN LAIKA" },
                    { 1045, 3, "RUSSIAN-EUROPEAN LAIKA" },
                    { 1044, 3, "AMERICAN FOXHOUND" },
                    { 1043, 3, "IRISH GLEN OF IMAAL TERRIER" },
                    { 1042, 3, "AMERICAN WATER SPANIEL" },
                    { 1041, 3, "BLACK AND TAN COONHOUND" },
                    { 1040, 3, "GERMAN HOUND" },
                    { 1048, 3, "AZAWAKH" },
                    { 930, 3, "GERMAN PINSCHER" },
                    { 929, 3, "MINIATURE SCHNAUZER" },
                    { 928, 3, "SCHNAUZER" },
                    { 818, 3, "PETIT BASSET GRIFFON VENDEEN" },
                    { 817, 3, "FAWN BRITTANY GRIFFON" },
                    { 816, 3, "MALTESE" },
                    { 815, 3, "AUSTRIAN  PINSCHER" },
                    { 814, 3, "AUSTRIAN BLACK AND TAN HOUND" },
                    { 813, 3, "COARSE-HAIRED STYRIAN HOUND" },
                    { 812, 3, "ST. BERNARD" },
                    { 811, 3, "SMALL SWISS HOUND" },
                    { 810, 3, "SWISS HOUND" },
                    { 809, 3, "GREAT SWISS MOUNTAIN DOG" },
                    { 808, 3, "HUNGARIAN SHORT-HAIRED POINTER (VIZSLA)" },
                    { 807, 3, "PUMI" },
                    { 806, 3, "PULI" },
                    { 805, 3, "KUVASZ" },
                    { 804, 3, "KOMONDOR" },
                    { 803, 3, "POLISH HOUND" },
                    { 802, 3, "FINNISH HOUND" },
                    { 819, 3, "TYROLEAN HOUND" },
                    { 820, 3, "LAKELAND TERRIER" },
                    { 821, 3, "MANCHESTER TERRIER" },
                    { 822, 3, "NORWICH TERRIER" },
                    { 840, 3, "SPANISH MASTIFF" },
                    { 839, 3, "BURGOS POINTING DOG" },
                    { 838, 3, "IBIZAN PODENCO" },
                    { 837, 3, "SHETLAND SHEEPDOG" },
                    { 836, 3, "CATALAN SHEEPDOG" },
                    { 835, 3, "YORKSHIRE TERRIER" },
                    { 834, 3, "WEST HIGHLAND WHITE TERRIER" },
                    { 833, 3, "BLOODHOUND" },
                    { 801, 3, "NEWFOUNDLAND" },
                    { 832, 3, "SCHIPPERKE" },
                    { 830, 3, "GRIFFON BELGE" },
                    { 829, 3, "GRIFFON BRUXELLOIS" },
                    { 828, 3, "WELSH TERRIER" },
                    { 827, 3, "CONTINENTAL TOY SPANIEL" },
                    { 826, 3, "STAFFORDSHIRE BULL TERRIER" },
                    { 825, 3, "SKYE TERRIER" },
                    { 824, 3, "SEALYHAM TERRIER" },
                    { 823, 3, "SCOTTISH TERRIER" },
                    { 831, 3, "PETIT BRABANÇON" },
                    { 800, 3, "FINNISH SPITZ" },
                    { 799, 3, "KARELIAN BEAR DOG" },
                    { 798, 3, "ENTLEBUCH CATTLE DOG" },
                    { 775, 3, "ARIEGEOIS" },
                    { 774, 3, "BRIQUET GRIFFON VENDEEN" },
                    { 773, 3, "GRIFFON NIVERNAIS" },
                    { 772, 3, "OLD ENGLISH SHEEPDOG" },
                    { 771, 3, "BELGIAN SHEPHERD DOG" },
                    { 770, 3, "SWEDISH VALLHUND" },
                    { 769, 3, "ENGLISH TOY TERRIER (BLACK &TAN)" },
                    { 768, 3, "FOX TERRIER (SMOOTH)" },
                    { 776, 3, "GASCON SAINTONGEOIS" },
                    { 767, 3, "BULL TERRIER" },
                    { 765, 3, "BEDLINGTON TERRIER" },
                    { 764, 3, "AUSTRALIAN TERRIER" },
                    { 763, 3, "AIREDALE TERRIER" },
                    { 762, 3, "GORDON SETTER" },
                    { 761, 3, "ENGLISH COCKER SPANIEL" },
                    { 760, 3, "CAIRN TERRIER" },
                    { 759, 3, "KERRY BLUE TERRIER" },
                    { 758, 3, "ENGLISH SETTER" },
                    { 766, 3, "BORDER TERRIER" },
                    { 841, 3, "PYRENEAN MASTIFF" },
                    { 777, 3, "GREAT GASCONY BLUE" },
                    { 779, 3, "BILLY" },
                    { 797, 3, "APPENZELL CATTLE DOG" },
                    { 796, 3, "BERNESE MOUNTAIN DOG" },
                    { 795, 3, "BERGER DE BEAUCE" },
                    { 794, 3, "BASENJI" },
                    { 793, 3, "JÄMTHUND" },
                    { 792, 3, "YUGOSLAVIAN SHEPHERD DOG - SHARPLANINA" },
                    { 791, 3, "IRISH SOFT COATED WHEATEN TERRIER" },
                    { 790, 3, "WELSH CORGI (PEMBROKE)" },
                    { 778, 3, "POITEVIN" },
                    { 789, 3, "WELSH CORGI (CARDIGAN)" },
                    { 787, 3, "BASSET FAUVE DE BRETAGNE" },
                    { 786, 3, "BLUE GASCONY BASSET" },
                    { 785, 3, "NORMAN ARTESIEN BASSET" },
                    { 784, 3, "GRAND BASSET GRIFFON VENDEEN" },
                    { 783, 3, "BLUE GASCONY GRIFFON" },
                    { 782, 3, "SMALL BLUE GASCONY" },
                    { 781, 3, "PORCELAINE" },
                    { 780, 3, "ARTOIS HOUND" },
                    { 788, 3, "PORTUGUESE WATER DOG" },
                    { 1101, 3, "LANCASHIRE HEELER" },
                    { 842, 3, "PORTUGUESE SHEEPDOG" },
                    { 844, 3, "BRITTANY SPANIEL" },
                    { 905, 3, "BULLMASTIFF" },
                    { 904, 3, "COLLIE ROUGH" },
                    { 903, 3, "BOSNIAN BROKEN-HAIRED HOUND - CALLED BARAK" },
                    { 902, 3, "POSAVATZ HOUND" },
                    { 901, 3, "DALMATIAN" },
                    { 900, 3, "ISTRIAN WIRE-HAIRED HOUND" },
                    { 899, 3, "ISTRIAN SHORT-HAIRED HOUND" },
                    { 898, 3, "SERBIAN HOUND" },
                    { 897, 3, "BULLDOG" },
                    { 896, 3, "DACHSHUND" },
                    { 895, 3, "ROTTWEILER" },
                    { 894, 3, "RHODESIAN RIDGEBACK" },
                    { 893, 3, "LEONBERGER" },
                    { 892, 3, "BOXER" },
                    { 891, 3, "DOBERMANN" },
                    { 890, 3, "SLOVAKIAN CHUVACH" },
                    { 889, 3, "LONG-HAIRED PYRENEAN SHEEPDOG" },
                    { 906, 3, "GREYHOUND" },
                    { 907, 3, "ENGLISH FOXHOUND" },
                    { 908, 3, "IRISH WOLFHOUND" },
                    { 909, 3, "BEAGLE" },
                    { 927, 3, "GIANT SCHNAUZER" },
                    { 926, 3, "AUVERGNE POINTER" },
                    { 925, 3, "BOURBONNAIS POINTING DOG" },
                    { 924, 3, "ARIEGE POINTING DOG" },
                    { 923, 3, "PICARDY SHEEPDOG" },
                    { 922, 3, "FRENCH SPANIEL" },
                    { 921, 3, "ESTRELA MOUNTAIN DOG" },
                    { 920, 3, "POODLE" },
                    { 888, 3, "BOSTON TERRIER" },
                    { 919, 3, "BOUVIER DES ARDENNES" },
                    { 917, 3, "FOX TERRIER (WIRE)" },
                    { 916, 3, "DANDIE DINMONT TERRIER" },
                    { 915, 3, "AMERICAN COCKER SPANIEL" },
                    { 914, 3, "GERMAN SHEPHERD DOG" },
                    { 913, 3, "ITALIAN SPINONE" },
                    { 912, 3, "DEERHOUND" },
                    { 911, 3, "BASSET HOUND" },
                    { 910, 3, "WHIPPET" },
                    { 918, 3, "CASTRO LABOREIRO DOG" },
                    { 887, 3, "IRISH TERRIER" },
                    { 886, 3, "PYRENEAN SHEEPDOG - SMOOTH FACED" },
                    { 885, 3, "PYRENEAN MOUNTAIN DOG" },
                    { 862, 3, "PONT-AUDEMER SPANIEL" },
                    { 861, 3, "BRIARD" },
                    { 860, 3, "GOLDEN RETRIEVER" },
                    { 859, 3, "CURLY COATED RETRIEVER" },
                    { 858, 3, "CLUMBER SPANIEL" },
                    { 857, 3, "PICARDY SPANIEL" },
                    { 856, 3, "WIRE-HAIRED POINTING GRIFFON KORTHALS" },
                    { 855, 3, "BLUE PICARDY SPANIEL" },
                    { 863, 3, "SAINT GERMAIN POINTER" },
                    { 854, 3, "FRENCH WATER DOG" },
                    { 852, 3, "GERMAN HUNTING TERRIER" },
                    { 851, 3, "KLEINER MÜNSTERLÄNDER" },
                    { 850, 3, "FRENCH BULLDOG" },
                    { 849, 3, "WESTPHALIAN DACHSBRACKE" },
                    { 848, 3, "WEIMARANER" },
                    { 847, 3, "GERMAN WIRE- HAIRED POINTING DOG" },
                    { 846, 3, "GERMAN SPITZ" },
                    { 845, 3, "RAFEIRO OF ALENTEJO" },
                    { 853, 3, "GERMAN SPANIEL" },
                    { 843, 3, "PORTUGUESE WARREN HOUND-PORTUGUESE PODENGO" },
                    { 864, 3, "DOGUE DE BORDEAUX" },
                    { 866, 3, "LARGE MUNSTERLANDER" },
                    { 884, 3, "CAVALIER KING CHARLES SPANIEL" },
                    { 883, 3, "SWEDISH LAPPHUND" },
                    { 882, 3, "FRENCH POINTING DOG - PYRENEAN TYPE" },
                    { 881, 3, "FRENCH POINTING DOG - GASCOGNE TYPE" },
                    { 880, 3, "HAMILTONSTÖVARE" },
                    { 879, 3, "SCHILLERSTÖVARE" },
                    { 878, 3, "DREVER" },
                    { 877, 3, "SMÅLANDSSTÖVARE" },
                    { 865, 3, "DEUTSCH LANGHAAR" },
                    { 876, 3, "KING CHARLES SPANIEL" },
                    { 874, 3, "WELSH SPRINGER SPANIEL" },
                    { 873, 3, "ENGLISH SPRINGER SPANIEL" },
                    { 872, 3, "IRISH WATER SPANIEL" },
                    { 871, 3, "FIELD SPANIEL" },
                    { 870, 3, "LABRADOR RETRIEVER" },
                    { 869, 3, "FLAT COATED RETRIEVER" },
                    { 868, 3, "IRISH RED SETTER" },
                    { 867, 3, "GERMAN SHORT- HAIRED POINTING DOG" },
                    { 875, 3, "SUSSEX SPANIEL" },
                    { 1102, 3, "SEGUGIO MAREMMANO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Datasets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 757);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 758);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 759);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 760);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 761);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 762);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 763);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 764);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 765);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 766);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 767);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 768);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 769);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 770);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 771);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 772);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 773);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 774);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 775);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 776);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 777);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 778);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 779);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 780);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 781);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 782);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 783);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 784);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 785);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 786);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 787);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 788);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 789);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 790);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 791);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 792);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 793);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 794);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 795);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 796);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 797);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 798);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 799);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 800);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 801);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 802);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 803);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 804);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 805);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 806);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 807);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 808);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 809);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 810);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 811);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 812);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 813);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 814);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 815);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 816);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 817);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 818);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 819);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 820);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 821);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 822);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 823);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 824);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 825);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 826);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 827);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 828);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 829);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 830);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 831);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 832);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 833);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 834);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 835);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 836);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 837);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 838);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 839);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 840);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 841);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 842);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 843);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 844);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 845);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 846);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 847);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 848);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 849);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 850);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 851);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 852);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 853);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 854);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 855);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 856);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 857);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 858);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 859);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 860);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 861);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 862);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 863);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 864);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 865);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 866);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 867);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 868);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 869);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 870);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 871);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 872);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 873);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 874);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 875);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 876);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 877);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 878);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 879);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 880);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 881);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 882);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 883);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 884);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 885);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 886);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 887);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 888);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 889);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 890);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 891);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 892);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 893);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 894);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 895);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 896);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 897);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 898);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 899);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 900);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 901);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 902);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 903);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 904);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 905);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 906);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 907);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 908);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 909);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 910);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 911);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 912);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 913);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 914);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 915);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 916);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 917);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 918);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 919);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 920);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 921);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 922);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 923);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 924);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 925);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 926);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 927);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 928);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 929);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 930);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 931);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 932);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 933);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 934);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 935);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 936);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 937);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 938);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 939);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 940);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 941);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 942);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 943);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 944);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 945);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 946);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 947);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 948);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 949);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 950);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 951);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 952);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 953);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 954);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 955);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 956);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 957);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 958);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 959);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 960);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 961);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 962);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 963);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 964);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 965);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 966);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 967);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 968);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 969);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 970);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 971);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 972);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 973);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 974);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 975);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 976);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 977);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 978);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 979);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 980);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 981);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 982);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 983);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 984);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 985);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 986);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 987);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 988);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 989);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 990);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 991);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 992);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 993);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 994);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 995);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 996);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 997);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 998);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 999);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1000);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1006);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1007);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1008);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1009);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1011);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1012);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1013);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1014);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1015);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1016);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1017);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1018);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1019);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1024);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1025);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1026);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1027);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1028);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1029);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1030);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1031);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1032);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1033);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1034);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1035);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1036);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1037);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1038);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1039);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1040);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1041);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1042);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1043);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1044);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1045);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1046);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1047);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1048);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1049);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1050);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1051);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1052);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1053);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1054);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1055);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1056);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1057);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1058);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1059);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1060);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1061);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1062);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1063);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1064);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1065);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1066);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1067);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1068);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1069);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1070);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1071);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1072);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1073);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1074);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1075);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1076);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1077);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1078);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1079);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1080);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1081);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1082);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1083);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1084);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1085);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1086);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1087);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1088);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1089);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1090);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1091);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1092);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1093);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1094);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1095);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1096);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1097);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1098);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1099);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1100);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1101);

            migrationBuilder.DeleteData(
                table: "DefinedDatasetsValues",
                keyColumn: "Id",
                keyValue: 1102);

            migrationBuilder.DeleteData(
                table: "DefinedDatasets",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
