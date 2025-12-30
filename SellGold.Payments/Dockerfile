FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["SellGold.Payments/SellGold.Payments.csproj", "SellGold.Payments/"]
RUN dotnet restore "SellGold.Payments/SellGold.Payments.csproj"
COPY . .
WORKDIR "/src/SellGold.Payments"
RUN dotnet build "SellGold.Payments.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "SellGold.Payments.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SellGold.Payments.dll"]