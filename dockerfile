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
ENTRYPOINT ["dotnet", "Comet.Account/Comet.Account.dll"]
