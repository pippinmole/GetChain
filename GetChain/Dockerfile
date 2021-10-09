FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build

COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "GetChain.dll"]