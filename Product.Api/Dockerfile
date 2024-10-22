FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ARG ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Product.Api/Product.Api.csproj", "Product.Api/"]
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet restore "Product.Api/Product.Api.csproj"

RUN dotnet tool install -g dotnet-json
COPY . .
WORKDIR "/src/Product.Api"

RUN dotnet build "Product.Api.csproj" -c Release -o /app/build

FROM build AS publish
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet publish "Product.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV PATH="$PATH:/root/.dotnet/tools"

ENTRYPOINT ["dotnet", "Product.Api.dll"]