FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app
USER app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Product.Api/Product.Api.csproj", "Product.Api/"]
RUN dotnet restore "Product.Api/Product.Api.csproj"
COPY . .
WORKDIR "/src/Product.Api"
RUN dotnet build "Product.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
RUN dotnet publish "Product.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish  /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV PATH "$PATH:/root/.dotnet/tools"
ENTRYPOINT ["dotnet", "Product.Api.dll"]