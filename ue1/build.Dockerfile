FROM mcr.microsoft.com/dotnet/sdk:7.0
WORKDIR /root
COPY ./NotesCmd .
RUN dotnet tool restore
RUN dotnet build
RUN mkdir /data
RUN dotnet ef database update
RUN dotnet publish -o NotesApp

# docker build -f build.Dockerfile -t exercise1-build:latest .
# docker run -it --name notesapp exercise1-build:latest