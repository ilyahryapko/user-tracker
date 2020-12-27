# user-tracker
`git clone https://github.com/ilyahryapko/user-tracker.git`  
`cd user-tracker`  
`docker run --name user-db -p 27017:27017 mongo`  
`dotnet restore src/api/UserTracker/UserTracker.csproj`  
`dotnet run --project src/api/UserTracker/UserTracker.csproj`  
`cd src/web`  
`npm install`  
`npm start`
