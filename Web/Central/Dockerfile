FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Central.csproj", "Central/"]
RUN dotnet restore "Central/Central.csproj"
COPY . "./Central/"
WORKDIR "/src/Central"
RUN dotnet build "Central.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Central.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Central.dll"]