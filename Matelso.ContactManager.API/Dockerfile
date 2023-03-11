#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Matelso.ContactManager.API/Matelso.ContactManager.API.csproj", "Matelso.ContactManager.API/"]
RUN dotnet restore "Matelso.ContactManager.API/Matelso.ContactManager.API.csproj"
COPY . .
WORKDIR "/src/Matelso.ContactManager.API"
RUN dotnet build "Matelso.ContactManager.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Matelso.ContactManager.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Matelso.ContactManager.API.dll"]