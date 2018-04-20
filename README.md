# DatabaseProject
Project for a database class

Due to the private nature of the data in this project, the data files have not been included.

[Here's the tutorial](https://docs.microsoft.com/en-us/ef/core/get-started/netcore/new-db-sqlite) for setting up the database. 

## Setup instructions
5 things need to be copied into the project folder for this to work. They are ignored using the .gitignore.
- removedUsers.json
- userdata.json
- usernames.json
- peoplefinder-images/
- ejoker-images/

You might need to install some nuget packages. Here's something to try for Mac if it doesn't work out of the box:
1. open a terminal
2. cd to project directory
3. type in the following commands:
- `dotnet add package Microsoft.EntityFrameworkCore.Sqlite`
- `dotnet add package Microsoft.EntityFrameworkCore.Design`
- `dotnet add package Newtonsoft.Json` (Alternatively, try installing this with the Nuget package manager in Visual Studio - that's what you do on windows)
- `dotnet restore`

If this doesn't work then let me know.