# Initialize a new build stage and set the Base Image 
FROM mcr.microsoft.com/dotnet/sdk:6.0-focal
# Set the working directory
WORKDIR /app
# Expose the port 5000
EXPOSE 5500
# Sets the environment variable
ENV ASPNETCORE_URLS=http://+:5500
# Creates a non-root user with an explicit UID and adds a permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN chown -R root /app
USER root
RUN dotnet dev-certs https --trust
# Initialize the new build stage and set the Build Image

ENTRYPOINT ["dotnet"]