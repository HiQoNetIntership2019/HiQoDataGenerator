# HiQoDataGenerator

Scheduler configuration guide:
  1) build HiQoDataGenerator.Scheduler project;
  2) open Command prompt as Administrator;
  3) open "HiQoDataGenerator.Scheduler" folder in Command promt;
  4) input "dotnet publish --configuration Release" to generate .EXE file;
  *Note : if your target platform is not x64, you can modify property <RuntimeIdentifier> in .csproj file;
  5) open "..\HiQoDataGenerator.Scheduler\bin\Release\netcoreapp2.2\{your runtime Id}\publish\";
  6) input "{.exe file name} install";
  7) and then you can start service in any known way (i.e input "sc start {ServiceName}" in command promt").
  