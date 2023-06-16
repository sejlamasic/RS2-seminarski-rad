#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

RUN echo "EVO ME NA PO?ETKU"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["RS2-FrizerskiSalon/RS2-FrizerskiSalon.csproj", "RS2-FrizerskiSalon/"]
RUN dotnet restore "RS2-FrizerskiSalon/RS2-FrizerskiSalon.csproj"
COPY . .
WORKDIR "/src/RS2-FrizerskiSalon"
RUN dotnet build "RS2-FrizerskiSalon.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RS2-FrizerskiSalon.csproj" -c Release -o /app/publish 

FROM base AS final
WORKDIR /app
COPY frizerskistuido.sql /app/frizerskistudio.sql

RUN echo "EVO ME NA KRAJU"

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RS2-FrizerskiSalon.dll"]

#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#EXPOSE 52830
#
#RUN echo "EVO ME NA PO?ETKU"
#
#FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
#WORKDIR /src
#COPY ["RS2-seminarski-tattoostudio/RS2-seminarski-tattoostudio.csproj", "RS2-seminarski-tattoostudio/"]
#RUN dotnet restore "RS2-seminarski-tattoostudio/RS2-seminarski-tattoostudio.csproj"
#COPY . .
#WORKDIR "/src/RS2-seminarski-tattoostudio"
#RUN dotnet build "RS2-seminarski-tattoostudio.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "RS2-seminarski-tattoostudio.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY tattoostudio.sql /app/tattoostudio.sql
#
#RUN echo "EVO ME NA KRAJU"
#
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "RS2-seminarski-tattoostudio.dll"]