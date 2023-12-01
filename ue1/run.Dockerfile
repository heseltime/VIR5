# docker cp notesapp:/root/NotesApp .
# docker cp notesapp:/data/notes.db .

FROM mcr.microsoft.com/dotnet/runtime:7.0
WORKDIR /app
COPY ./NotesApp .
COPY ./notes.db /data/

# docker build -f run.Dockerfile -t exercise1-run:latest .
# docker volume create myvol
# docker run -it --name notesrun -v myvol:/data exercise1-run:latest