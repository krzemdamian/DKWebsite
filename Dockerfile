FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5001

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["DKWebsite/DKWebsite.csproj", "DKWebsite/"]
RUN dotnet restore "DKWebsite/DKWebsite.csproj"
COPY . .
WORKDIR "/src/DKWebsite"
RUN dotnet build "DKWebsite.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "DKWebsite.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "DKWebsite.dll"]