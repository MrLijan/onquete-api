FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /app

# Set dev-certs
RUN dotnet dev-certs https
RUN dotnet watch

# Restore as distinct layers

# CMD ['dotnet', 'restore' '&&', 'dotnet', 'watch']

# # Build and publish a release
# RUN dotnet publish -c Release -o out

# Build runtime image
# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# WORKDIR /app
# COPY --from=build-env /app/out .
# ENTRYPOINT ["dotnet", "OnqueteApi.dll"]
