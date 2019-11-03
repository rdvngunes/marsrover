FROM mcr.microsoft.com/dotnet/core/runtime:3.0-buster-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["MarsRover.Test/MarsRover.Test.csproj", "MarsRover.Test/"]
COPY ["MarsRover/MarsRover.csproj", "MarsRover/"]
RUN dotnet restore "MarsRover.Test/MarsRover.Test.csproj"
COPY . .
WORKDIR "/src/MarsRover.Test"
RUN dotnet build "MarsRover.Test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MarsRover.Test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MarsRover.Test.dll"]