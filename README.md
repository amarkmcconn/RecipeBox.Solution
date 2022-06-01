#  📑 Recipe Box 📦

## By **Mark McConnell** 👨

### This is an MVC application that will allow a user to keep track of recipes and their respective recipe tags

## Technologies Used 🖥️

* _C#_
* _.Net 5.0_
* _HTML_
* _CSS_
* _Git_
* _VsCode_
* _EntityFrameWork_
* _REPL_
* _MySQL WorkBench_

## Description ✅

![Alt text](/RecipeBox/wwwroot/img/Picture1.jpg)


This an MVC application that allows users to keep track of recipes. Here are some user stories that is application achieves:

* As a user, I want to add a recipe with ingredients and instructions, so I remember how to prepare my favorite dishes.
* As a user, I want to tag my recipes with different categories, so recipes are easier to find. A recipe can have many tags and a tag can have many recipes.
* As a user, I want to be able to update and delete tags, so I can have flexibility with how I categorize recipes.
* As a user, I want to edit my recipes, so I can make improvements or corrections to my recipes.
more easily find recipes for the ingredients I have.

Add authentication:

* As a user, I want to create an account.
* As a user, I want to be able to log in and log off.
* As a user, I want to be able to see my account details.

## Setup/Installation Requirements 🖊️

* _Clone this repo: <https://github.com/amarkmcconn/RecipeBox.Solution>_
* _Enter the new directory using the command ```cd RecipeBox.Solution```
* _In the root directory, confirm there is a .gitignore file_
* _add:

```
*/obj,
*/bin
*.vscode
*/appsettings.json
```

 to the .gitignore file. It will keep your repository clean of unnecessary files and protect your database from unauthorized access_

* _Create an appsetting.json file at the root directory_*
* Open the appsetting.json file and enter:

```
{ 
  "ConnectionStrings": { 
    "DefaultConnection": "Server=localhost;Port=3306;database=[Database-Name];uid=root;pwd=[Your-Password];" 
  } 
}
```

* _run ```git add .gitignore```
* _commit your changes_
* _To ensure the project will run correctly,_
* _Download MySQL WorkBench_
* _run ```dotnet tool install --global dotnet-ef --version 5.0.1``` at a global level_
* _Run the Following the project directory of ```RecipeBox```_
* _run ```dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0```_
* _run ```dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2```_
* _run ```dotnet add package Microsoft.EntityFrameworkCore.Proxies -v 5.0.0```_
* _run ```dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore -v 5.0.0```_
* _Once all of the necessary setup is in place and we can successfully run dotnet build_
* _run ```dotnet restore``` and ```dotnet build``` from the RecipeBox directory_
* _run ```dotnet ef migrations add Initial``` from the RecipeBox Directory_
* _Once we have verified that the migration looks correct and made any necessary changes, we'll run the following command: ```dotnet ef database update```_
* _To interact with the local host website navigate to the University directory and run ```dotnet run```_
* _click on  <http://localhost:5000>_

## Known Bugs 🐛

* _No Known Issues_

## License

[MIT](LICENSE)

_If you run into any issues or have questions, ideas, or concerns;  please email me: at mark.programming1@gmail.com or make a contribution to the code._

Copyright (c) 2022 Mark McConnell