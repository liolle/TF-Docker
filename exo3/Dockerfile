FROM nginx AS setup
RUN apt-get update
RUN apt-get install git -y 

FROM nginx AS clone
COPY --from=setup . . 
RUN mkdir github 
WORKDIR /github
RUN git clone https://github.com/liolle/TF-Docker.git .
RUN rm -rf ../usr/share/nginx/html/*
RUN mv exo3/src/* ../usr/share/nginx/html 
RUN cd ..
RUN rm -rf github
