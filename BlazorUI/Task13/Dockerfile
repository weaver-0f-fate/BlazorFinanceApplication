FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["BlazorUI/Core/Core.csproj", "BlazorUI/Core/"]
COPY ["BlazorUI/Services/Services.csproj", "BlazorUI/Services/"]
COPY ["BlazorUI/Task13/Task13.csproj", "BlazorUI/Task13/"]
COPY ["API/Core/Core.csproj", "API/Core/"]
COPY ["API/Data/Data.csproj", "API/Data/"]
COPY ["API/Services/Services.csproj", "API/Services/"]
COPY ["API/Task12/Task12.csproj", "API/Task12/"]
RUN dotnet restore "BlazorUI/Task13/Task13.csproj"
COPY . .
WORKDIR "/src/BlazorUI/Task13"
RUN dotnet build "Task13.csproj" -c Release -o /app/build

FROM build AS publish
RUN apt-get update -yq \
    && apt-get install curl gnupg -yq \
    && curl -sL https://deb.nodesource.com/setup_14.x | bash \
    && apt-get install nodejs -yq
RUN dotnet publish "Task13.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Task13.dll"]
