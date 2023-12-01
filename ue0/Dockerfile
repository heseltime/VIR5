# this is a comment
FROM alpine:3.18.4

WORKDIR /root
COPY main.cpp .

RUN apk add g++
RUN g++ main.cpp -o namegen

# RUN apk add g++ && g++ main.cpp -o namegen

CMD ./namegen

# docker build -t namegen:latest .
# docker run --rm namegen:latest