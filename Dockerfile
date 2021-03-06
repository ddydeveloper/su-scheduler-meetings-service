FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY UsSchedulerMeetings/*.sln .
COPY UsSchedulerMeetings/UsSchedulerMeetings/*.csproj ./UsSchedulerMeetings/

# copy everything else and build app
COPY UsSchedulerMeetings/UsSchedulerMeetings/. ./UsSchedulerMeetings/
WORKDIR /app/UsSchedulerMeetings
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/UsSchedulerMeetings/out ./

CMD ASPNETCORE_URLS=http://*:$PORT dotnet UsSchedulerMeetings.dll