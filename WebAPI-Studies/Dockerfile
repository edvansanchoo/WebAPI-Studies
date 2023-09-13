#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WebAPI-Studies/WebAPI-Studies.csproj", "WebAPI-Studies/"]
RUN dotnet restore "WebAPI-Studies/WebAPI-Studies.csproj"
COPY . .
WORKDIR "/src/WebAPI-Studies"
RUN dotnet build "WebAPI-Studies.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPI-Studies.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPI-Studies.dll"]