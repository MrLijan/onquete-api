# BUILD
# FROM mcr.microsoft.com/dotnet/runtime:6.0-focal AS BUILD

# WORKDIR /source
# COPY . .

# RUN dotnet restore "./OnqueteApi/OnqueteApi.csproj" --disable-parallel
# RUN dotnet publish "./OnqueteApi/OnqueteApi.csproj" -c release -o /app -no-restore


# # SERVE 
# FROM mcr.microsoft.com/dotnet/runtime:6.0-focal
# WORKDIR /app
# COPY --from=BUILD /app ./

# EXPOSE 5000

# ENTRYPOINT ["dotnet", "watch"]

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /app

# Copy everything
COPY . ./

# Set dev-certs
RUN dotnet dev-certs https

# Restore as distinct layers
RUN dotnet restore

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "OnqueteApi.dll"]
