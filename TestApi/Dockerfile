FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["TestApi.csproj", "TestApi/"]
RUN dotnet restore "TestApi/TestApi.csproj"
COPY . "./TestApi/"
WORKDIR "/src/TestApi"
RUN dotnet build "TestApi.csproj" -c Release -r linux-arm -o /app

FROM build AS publish
RUN dotnet publish "TestApi.csproj" -c Release -r linux-arm -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["./TestApi"]
