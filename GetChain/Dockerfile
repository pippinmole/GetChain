FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
#RUN dotnet restore

# Copy everything else and build
# COPY ../engine/examples ./
FROM mcr.microsoft.com/dotnet/aspnet:5.0
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "GetChain.dll"]
