FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build

RUN dotnet publish

COPY bin/Release/net5.0/publish/ App/
WORKDIR /App
ENTRYPOINT ["dotnet", "GetChain.dll"]