FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["RaspberryREST.csproj", "RaspberryREST/"]
RUN dotnet restore "RaspberryREST/RaspberryREST.csproj"
COPY . "./RaspberryREST/"
WORKDIR "/src/RaspberryREST"
RUN dotnet build "RaspberryREST.csproj" -c Release -r linux-arm -o /app

FROM build AS publish
RUN dotnet publish "RaspberryREST.csproj" -c Release -r linux-arm -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["./RaspberryREST"]
