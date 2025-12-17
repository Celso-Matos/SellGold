FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SellGold.Suppliers/SellGold.Suppliers.csproj", "SellGold.Suppliers/"]
RUN dotnet restore "./SellGold.Suppliers/SellGold.Suppliers.csproj"
COPY . .
WORKDIR "/src/SellGold.Suppliers"
RUN dotnet build "./SellGold.Suppliers.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./SellGold.Suppliers.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SellGold.Suppliers.dll"]