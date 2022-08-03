#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["UndyingWorld.Web.Api/UndyingWorld.Web.Api.csproj", "UndyingWorld.Web.Api/"]
RUN dotnet restore "UndyingWorld.Web.Api/UndyingWorld.Web.Api.csproj"
COPY . .
WORKDIR "/src/UndyingWorld.Web.Api"
RUN dotnet build "UndyingWorld.Web.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UndyingWorld.Web.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UndyingWorld.Web.Api.dll"]