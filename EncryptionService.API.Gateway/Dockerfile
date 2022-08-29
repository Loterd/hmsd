FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EncryptionService.API.Gateway/EncryptionService.API.Gateway.csproj", "EncryptionService.API.Gateway/"]
RUN dotnet restore "EncryptionService.API.Gateway/EncryptionService.API.Gateway.csproj"
COPY . .
WORKDIR "/src/EncryptionService.API.Gateway"
RUN dotnet build "EncryptionService.API.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EncryptionService.API.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EncryptionService.API.Gateway.dll"]
