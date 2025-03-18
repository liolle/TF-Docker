#!/bin/bash

# Remove the previous container
echo -e "Removing previous exo container"
docker rm -f exo-mssql >/dev/null

# Start a new container
echo -e "Starting new exo container"
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=simpletest1=" -p 1435:1433 --name exo-mssql -d mcr.microsoft.com/mssql/server

# Wait for SQL Server to be fully initialized
echo -e "Waiting for SQL Server to start..."
sleep 10 # Adjust this delay if needed

# Check if SQL Server is ready
while ! docker exec -it exo-mssql /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P simpletest1= -d master -Q "SELECT 1;" -N -C >/dev/null 2>&1; do
  echo -e "SQL Server is not ready yet. Retrying in 5 seconds..."
  sleep 5
done

# Open a new container shell
echo -e "Opening new container shell"
docker exec -it exo-mssql /opt/mssql-tools18/bin/sqlcmd -S localhost -U sa -P simpletest1= -d master -N -C
