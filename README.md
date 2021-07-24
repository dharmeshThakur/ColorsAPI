# ColorsAPI
Steps to run ColorsAPI
- Open project in Visual Studio
- Change connection string in appsettings.json
- Open Package Manager Console and run below commands
	- Add-Migration ColorsMigration
	- Update-Database
- Run Project
- In brower type {base_url}/swagger/index.html to see API endpoints in swagger documentation
- There is a PostmanCollection file is also attached so import that file in postman and run endpoints
	- Get all colors
	- Get color
	- Add color
	- Update Color
	- Delete color