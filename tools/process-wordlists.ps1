dotnet build "..\src\Wordb.CommandLine\Wordb.CommandLine.csproj" -c Release

dotnet "..\src\Wordb.CommandLine\bin\Release\netcoreapp3.1\Wordb.CommandLine.dll" "../data" "../data.other"
