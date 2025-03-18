#!/bin/bash

show_containers() {
  echo -e "\n"
  docker ps -a
  echo -e "\n"
}

echo -e "Creating containers using hello-world image \n"
for i in {0..3}; do
  docker run -d hello-world
done

echo -e "Creating containers using nginx image \n"
for i in {0..1}; do
  docker run -d nginx
done

show_containers

sleep 1

# Deleting first hello-world container
echo -e "Deleting first hello-world container"
sleep 1
docker rm $(docker ps -af ancestor=hello-world --format "table {{.ID}}\t{{.CreatedAt}}" | grep -v "CREATED AT" | sort -k2 | head -n 1 | awk '{print $1}') >/dev/null

show_containers

#
echo -e "Deleting second hello-world container"

sleep 1
docker rm $(docker ps -af ancestor=hello-world --format "table {{.ID}}\t{{.CreatedAt}}" | grep -v "CREATED AT" | sort -k2 | head -n 1 | awk '{print $1}') >/dev/null

show_containers

sleep 1
# Deleting remaining hello-world container
echo -e "Deleting remaining hello-world container"

docker rm $(docker ps -aqf ancestor=hello-world) >/dev/null

show_containers

echo -e "Stoping nginx containers "
docker stop $(docker ps -aqf ancestor=nginx) >/dev/null

show_containers

sleep 1

echo -e "Restarting nginx containers \n"
docker start $(docker ps -aqf ancestor=nginx) >/dev/null

show_containers

sleep 1

echo -e "Deleting nginx containers \n"
docker stop $(docker ps -aqf ancestor=nginx) >/dev/null
docker rm $(docker ps -aqf ancestor=nginx) >/dev/null

show_containers
