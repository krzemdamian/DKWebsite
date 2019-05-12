FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["RpiREST.csproj", "RpiREST/"]
RUN dotnet restore "RpiREST/RpiREST.csproj"
COPY . "./RpiREST/"
WORKDIR "/src/RpiREST"
RUN dotnet build "RpiREST.csproj" -c Release -r linux-arm -o /app

FROM build AS publish
RUN dotnet publish "RpiREST.csproj" -c Release -r linux-arm -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["./RpiREST"]
