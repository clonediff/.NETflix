FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["DotNetflix.S3/DotNetflix.S3.csproj", "DotNetflix.S3/"]
RUN dotnet restore "DotNetflix.S3/DotNetflix.S3.csproj"
COPY . .
WORKDIR "/src/DotNetflix.S3"
RUN dotnet build "DotNetflix.S3.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNetflix.S3.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNetflix.S3.dll"]
