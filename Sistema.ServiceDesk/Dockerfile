#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Sistema.ServiceDesk/Sistema.ServiceDesk.csproj", "Sistema.ServiceDesk/"]
RUN dotnet restore "Sistema.ServiceDesk/Sistema.ServiceDesk.csproj"
COPY . .
WORKDIR "/src/Sistema.ServiceDesk"
RUN dotnet build "Sistema.ServiceDesk.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Sistema.ServiceDesk.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Sistema.ServiceDesk.dll"]