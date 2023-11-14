# REadSense Backend API

An Asp.Net 8 Web API for ReadSense application.

## Development Setup

### Prerequisites

- Install `Visual studio 2022 Preview` from [here](https://visualstudio.microsoft.com/vs/preview)
- Install Docker Desktop from [here](https://www.docker.com/products/docker-desktop)

### Steps

1. We need a MSSQL server to run the backend API. Run the below command from `ReadSenseApi` directory to start MSSQL server in a docker container. This will start MSSQL server on port 1433.

	```sh
	docker compose -f Docker-Compose/docker-compose-sql-2022.yml up -d
	```

2. Open the solution file `ReadSenseApi.sln` in Visual Studio 2022 Preview. 
3. Update `Database Connection String`, `Secret` and `ClientUrl` in [appsettings.json](./appsettings.json) 
4. Run the application from Visual Studio 2022 Preview.
5. When you are done with the development, stop the MSSQL server by running the below command from ReadSenseApi directory.
	```sh
	docker compose -f Docker-Compose/docker-compose-sql-2022.yml down
	```