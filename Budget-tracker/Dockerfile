FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Budget-tracker/Budget-tracker.csproj", "Budget-tracker/"]
RUN dotnet restore "Budget-tracker/Budget-tracker.csproj"
COPY . .
WORKDIR "/src/Budget-tracker"
RUN dotnet build "Budget-tracker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Budget-tracker.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Budget-tracker.dll"]
