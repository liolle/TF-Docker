#!/bin/bash

docker build -t monsite:v1 .
docker run --name web -d -p 3000:80 monsite:v1
