#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["SSC.WebApi/SSC.WebApi.csproj", "SSC.WebApi/"]
COPY ["SSC.Repositorio/SSC.Repositorio.csproj", "SSC.Repositorio/"]
COPY ["SSC.DbConfiguration/SSC.DbConfiguration.csproj", "SSC.DbConfiguration/"]
COPY ["SSC.Modelos/SSC.Modelos.csproj", "SSC.Modelos/"]
COPY ["SSC.Servicios/SSC.Servicios.csproj", "SSC.Servicios/"]
RUN dotnet restore "SSC.WebApi/SSC.WebApi.csproj"
COPY . .
WORKDIR "/src/SSC.WebApi"
RUN dotnet build "SSC.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SSC.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SSC.WebApi.dll"]