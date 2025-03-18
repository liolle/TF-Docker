echo -e "Removing previous exo container"
docker rm -f exo-mssql >/dev/null

sleep 1

docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=simpletest1=" -p 1435:1433 --name exo-mssql -d mcr.microsoft.com/mssql/server

echo -e "Opening new container shell"

docker exec -it exo-mssql ./opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P simpletest1= -d master -N -C
#docker exec -it exo-mssql bash
