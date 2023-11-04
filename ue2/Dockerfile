FROM mcr.microsoft.com/dotnet/sdk:7.0 AS notesbuild
WORKDIR /root
COPY ./NotesAPI .
RUN dotnet tool restore
RUN dotnet build
RUN mkdir /data
RUN dotnet ef database update
RUN dotnet publish -o NotesApp

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=notesbuild /data/notes.db /data/
COPY --from=notesbuild /root/NotesApp .
ENV ASPNETCORE_URLS http://*:5000
ENTRYPOINT ["dotnet", "NotesAPI.dll"]

# docker build -f multistage.Dockerfile -t exercise2-api:latest .
# docker volume rm myvol
# docker volume create myvol
# docker run --rm -it --name notesrun -v myvol:/data exercise2-api:latest