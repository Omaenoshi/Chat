FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Chat/Chat.csproj", "Chat/"]
RUN dotnet restore "Chat/Chat.csproj"
COPY . .
WORKDIR "/src/Chat"
RUN dotnet build "Chat.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Chat.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Chat.dll"]
