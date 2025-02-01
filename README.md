<div align="center">
  
  ### **CustomRoyale ♛**
</div>
<p align="center">
  <img src="https://media1.giphy.com/media/v1.Y2lkPTc5MGI3NjExYTM2bDNpaHY1amxndDc5dGQwOWt2bW5ucjU2cWs0eWJiMWVndmF3ZSZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9Zw/MY1EJgjpXUwMrzQpAk/giphy.gif" />
</p>

                                 A clash royale server .NET 9.0 - 2025 

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0)


## 📍 Why this Fork ?

  - Support of [ZrdRoyale](https://github.com/Zordon1337/ZrdRoyale/) to .NET 9.0 because, sadly, project was not maintained

  - Easier to deploy (dockerfile, docker-compose, .env)

  - Security enhanced (Bcrypt to hash password, no SQL injections)


## ⭐ Features
``` 
- Minimum Trophies and Maximum Trophies after Win
- Default amount of gems and gold
- Gems and gold rewards after win
```

## ❌ Not implemented
``` 
- Sentry Report
- Webhooks
- ContentPatch
```

## 📦 Installation

### Requirements:
  - [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
  - [MySql Database](https://www.mysql.com/)


<br><br>

## 💻 Development 

### Requirements:
  - [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
  - [MySql Database](https://www.mysql.com/)

### Steps

  - Clone the repository

```bash

git clone https://github.com/bbusn/customroyale.git

```
  - Navigate to the project directory

```bash

cd customroyale/CustomRoyale

```

  - Install dependencies

```bash

dotnet restore

```

  - Create a `.env` file in the root directory and add the following environment variables

```env

MYSQL_DATABASE=yournamedatabase
MYSQL_PASSWORD=yourpassword
MYSQL_SERVER=yourserver
MYSQL_USER=youruser

```

  - Run the project

```bash

dotnet run

```

  - Voilà! The project should be running in a console window