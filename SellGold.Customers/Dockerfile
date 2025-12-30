FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SellGold.Customers/SellGold.Customers.csproj", "SellGold.Customers/"]
RUN dotnet restore "SellGold.Customers/SellGold.Customers.csproj"
COPY . .
WORKDIR "/src/SellGold.Customers"
RUN dotnet build "SellGold.Customers.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SellGold.Customers.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SellGold.Customers.dll"]