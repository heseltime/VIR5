FROM nginx:1.25.3

COPY  ./NotesWebApp/ /usr/share/nginx/html
COPY ./default.conf /etc/nginx/conf.d/default.conf


# docker build -f webapp.Dockerfile -t exercise3-webapp:latest .
# docker run --rm -it -p 80:80 exercise3-webapp:latest # with port forwarding!
# docker run --rm -it -p 80:80 --mount "type=bind,source=C:\Public\VIR5\ue3\NotesWebApp,target=/usr/share/nginx/html" exercise3-webapp:latest 
        # with bind mount! $PWD availabe in powershell