# Run project
You can run both apps from IDE or run next command in terminal
```sh
docker-compose -f docker-compose.yml up -d
```
If you want to run via docker please uncomment 'builder.Configuration.AddJsonFile("ocelot-docker.json", optional: false, reloadOnChange: true);' and 'comment builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);' in the Program.cs file in the project EncryptionService.API.Gateway

If you will use docker-compose please use use tests with 'http' extension in folder 'tests\RestClient' and with 'https' extension if you will run via IDE