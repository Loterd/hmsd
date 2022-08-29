FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EncryptionService.API/EncryptionService.API.csproj", "EncryptionService.API/"]
RUN dotnet restore "EncryptionService.API/EncryptionService.API.csproj"
COPY . .
WORKDIR "/src/EncryptionService.API"
RUN dotnet build "EncryptionService.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EncryptionService.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EncryptionService.API.dll"]
