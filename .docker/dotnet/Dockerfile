FROM mcr.microsoft.com/dotnet.aspnet:6.0 AS base

WORKDIR /app

EXPOSE 80
EXPOSE 443
EXPOSE 5500

FROM mcr.microsoft.com/dotnet.aspnet:6.0 AS build
WORKDIR /src
COPY ["onquete-api/OnqueteApi.csproj", "onquete-api/"]
RUN dotnet restore "OnqueteApi.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "OnqueteApi.csproj" -c Release -o /app/build

FROM build as publish
RUN dotnet publish "OnqueteApi.csproj" -c Release -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnqueteApi.csproj"]


