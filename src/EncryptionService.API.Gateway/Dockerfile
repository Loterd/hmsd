FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EncryptionService.API.Gateaway/EncryptionService.API.Gateaway.csproj", "EncryptionService.API.Gateaway/"]
RUN dotnet restore "EncryptionService.API.Gateaway/EncryptionService.API.Gateaway.csproj"
COPY . .
WORKDIR "/src/EncryptionService.API.Gateaway"
RUN dotnet build "EncryptionService.API.Gateaway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EncryptionService.API.Gateaway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EncryptionService.API.Gateaway.dll"]
