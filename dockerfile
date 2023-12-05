# Stage 1: Build the application using the .NET SDK
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS builder
WORKDIR /usr/src/comet/

# Set argument defaults
ENV COMET_BUILD_CONFIG "release"
ARG COMET_BUILD_CONFIG=$COMET_BUILD_CONFIG

# Copy and build servers and dependencies
COPY . ./
RUN dotnet restore
RUN dotnet publish ./src/Comet.Account -c $COMET_BUILD_CONFIG -o out/Comet.Account
RUN dotnet publish ./src/Comet.Game -c $COMET_BUILD_CONFIG -o out/Comet.Game

# Stage 2: Create the runtime image using the ASP.NET Core runtime
FROM mcr.microsoft.com/dotnet/aspnet:7.0

WORKDIR /usr/bin/comet/
COPY --from=builder /usr/src/comet/out .

# Copy the wait-for-it script and give it execute permissions
COPY wait-for-it.sh /wait-for-it.sh
RUN chmod +x /wait-for-it.sh

# Copy GameMap.dat file
COPY src/Comet.Game/ini/GameMap.dat /usr/bin/comet/ini/GameMap.dat
# Copy map directory
COPY src/Comet.Game/ini/map /usr/bin/comet/map
# Set the entrypoint to the wait-for-it script
# The actual command to start the application will be specified in docker-compose.yml
ENTRYPOINT ["/wait-for-it.sh"]
