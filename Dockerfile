# ============================================================
#  WarehouseManager.Api — multi-stage build
# ============================================================
#  Stage 1 (build): uses the .NET SDK image to restore + publish.
#  Stage 2 (final): uses the smaller ASP.NET runtime image and
#                   copies ONLY the compiled output from stage 1.
#
#  Build context is the git root (see docker-compose `context: .`),
#  so all COPY paths start with `WarehouseManager/`.
#
#  Build manually with:
#    docker build -t wms-api .
# ============================================================

# ---- Stage 1: build ----------------------------------------
# The SDK image contains the C# compiler + dotnet CLI. Big (~800MB),
# but it never ends up in the final image.
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy ONLY the .csproj files first, then restore. Because these files
# rarely change, Docker caches this layer and skips re-downloading all
# NuGet packages on every code change. (Layer caching — see below.)
COPY WarehouseManager/WarehouseManager.Api/WarehouseManager.Api.csproj                       WarehouseManager/WarehouseManager.Api/
COPY WarehouseManager/WarehouseManager.Application/WarehouseManager.Application.csproj        WarehouseManager/WarehouseManager.Application/
COPY WarehouseManager/WarehouseManager.Domain/WarehouseManager.Domain.csproj                 WarehouseManager/WarehouseManager.Domain/
COPY WarehouseManager/WarehouseManager.Infrastructure/WarehouseManager.Infrastructure.csproj WarehouseManager/WarehouseManager.Infrastructure/

# Restore the API project — this pulls its referenced projects too.
RUN dotnet restore WarehouseManager/WarehouseManager.Api/WarehouseManager.Api.csproj

# Now copy the actual source code (this layer changes every commit).
COPY WarehouseManager/ WarehouseManager/

# Publish a Release build to /app/publish.
#   -c Release        → optimized build
#   /p:UseAppHost=false → don't emit a native launcher exe; we run via `dotnet Xxx.dll`
RUN dotnet publish WarehouseManager/WarehouseManager.Api/WarehouseManager.Api.csproj \
    -c Release -o /app/publish /p:UseAppHost=false

# ---- Stage 2: runtime --------------------------------------
# The aspnet image can RUN .NET web apps but has no compiler. Small (~220MB).
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app

# Copy just the published output from the build stage. The SDK, source
# code, and NuGet caches are all left behind — they don't ship.
COPY --from=build /app/publish .

# Run as the non-root user baked into the base image (safer default).
USER $APP_UID

# Listen on all interfaces inside the container on port 8080.
# `+` = all interfaces (0.0.0.0). Without this, the app may bind to
# localhost only and be unreachable through the published port.
ENV ASPNETCORE_URLS=http://+:8080

# Documents which port the app listens on. Does NOT publish it to the
# host — that's the compose `ports:` mapping's job.
EXPOSE 8080

# The command that starts the app when the container runs.
ENTRYPOINT ["dotnet", "WarehouseManager.Api.dll"]
