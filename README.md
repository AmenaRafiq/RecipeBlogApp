# Recipe Blog App

## Project Status

Project development and hosting services have been STOPPED. 

## Brief

The project brief outlines the overall objective: 

> To create a CRUD application with the utilisation of supporting tools, methodologies and technologies that encapsulate all core modules covered during training.

(A CRUD application implements 4 basic functionalities: create, read, update and delete). Core modules that this project will encapsulate: Software Development Lifecycle, Agile development, Git, Databases, ASP.NET Core, Azure Core Services and Azure DevOps.

### Requirements

The requirements of the project are as follows:

* A Trello board (or equivalent Kanban board tech) 
* A relational database used to store data persistently, which consists of at least two tables.
* Clear Documentation of the Design Phase, Architecture and Risk Assessment.
* A functional CRUD application created in C#, following best practices and design principles, that meets the requirements set on the Kanban Board
* A Test Suite with automated tests
* A functioning front-end website using ASP.NET
  * As a stretch goal - an Angular based front-end with integrated API's.
* Code fully integrated into a Version Control System using the Feature-Branch model which will subsequently be built through a CI server and deployed to a cloud-based virtual machine.

## My Approach

In order to achieve this, I have decided to produce a simple recipe blog application that will allow a user to:
#### Create
* Create a Recipe that stores:
  * Title
  * Image
  * Ingredients
  * Method
  * Number of servings
  
* Create a Recipe Card that stores enough Recipe information to form the listing on the home page:
  * Title
  * Image
#### Read
* View a range of Recipe Cards
* View a specific Recipe from a Recipe Card
#### Update
* Update a Recipe's details
#### Delete
* Delete a Recipe

### User Stories

The following user stories served as the starting product backlog items, from which child tasks were devised.

> As a User I want to be able to see a list of recipes on the blog so that I can select a recipe.

> As a User I want to click on a recipe to view its title, image, ingredients, method and serving number so that I can use it to cook with.

> As a User I want to be able to create a post on the blog so that I can add a recipe.

> As a User I want to be able to enter a recipe title when I create a post so that I can identify each recipe.

> As a User I want to be able to upload an image when I create a post so that I can show what the food looks like

> As a User I want to be able to enter ingredients when I create a post so that I can list what is needed to cook the food.

> As a User I want to be able to enter a method when I create a post so that I can explain how to cook the food.

> As a User I want to be able to enter a serving number when I create a post so that it shows how many people this recipe will cater for.

> As a User I want to be able to edit an existing recipe so that I can fix any errors or update it with new information.

> As a User I want to be able to delete an existing recipe post so that I can remove content I don’t want showing on the blog anymore.

## Architecture
### Database Structure

Below is an Entity Relationship Diagram showing the structure of the database. It shows the tables and the relationship between them. There is a one to one relationship between a Recipe and a Recipe Card, thus when a user creates a recipe its resulting Recipe Card has to be created too.  

![Image for Database Structure](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/ER-diagram.PNG)

### CI Pipeline

Below is the continuous integration pipeline diagram that displays the project's associated services and frameworks. It shows how the Git repository is used to be able to pull code to my local machine as well as be used by the CI server to run tests on a build agent, automatically build and deploy the app to Azure App Service. The pipeline is run by AzureDevOps and is configured to have a build stage and a release stage such that if the build stage fails, the app is not released/deployed.

![CI Pipeline image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/CI-diagram.PNG)

## Project Tracking

AzureDevOps was used to create a Kanban Board to track the progress of the project. The KanBan Board can be found [here](https://dev.azure.com/amenarafiq/QA%20SFIA%20Project%20-%20Recipe%20Blog%20App/_boards/board/t/QA%20SFIA%20Project%20-%20Recipe%20Blog%20App%20Team/Stories).
(Ben although the project is set to public I might need to add you as a member so you can fully access the board)

The BackLog consists of the Epics and User Stories. 
![Backlog image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/Kanban-board.PNG)

Sprints then break down these stories with the additions of child tasks. Two sprints were devised, unfinished work from Iteration 1 was moved to Iteration 2.

[Iteration 1](https://dev.azure.com/amenarafiq/QA%20SFIA%20Project%20-%20Recipe%20Blog%20App/_sprints/taskboard/QA%20SFIA%20Project%20-%20Recipe%20Blog%20App%20Team/QA%20SFIA%20Project%20-%20Recipe%20Blog%20App/Iteration%201)

![Iteration 1 image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/sprint1.PNG)

[Iteration 2](https://dev.azure.com/amenarafiq/QA%20SFIA%20Project%20-%20Recipe%20Blog%20App/_sprints/taskboard/QA%20SFIA%20Project%20-%20Recipe%20Blog%20App%20Team/QA%20SFIA%20Project%20-%20Recipe%20Blog%20App/Iteration%202)

![Iteration 2 image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/sprint2.PNG)

The Boards were designed with columns that move a task along the board from left to right in stages of: 
* New
* Active 
* Two stages of Completion: 
  * Resolved (for bug fixes)  
  * Closed (for the completion of tasks)

## Risk Assessment

The risk assessment matrix can be found [here](https://docs.google.com/spreadsheets/d/1fOGOw1QFJLBZzKTQS_wfZKSyT3ypEtKI7Sbr0aPOQQ4/edit#gid=0).

## Testing

Unit tests allow small pieces of code to be tested in isolation to test for logic. In this project, unit tests were conducted to test the CRUD functions in the Controller.

[XUnit](https://xunit.net/) has been used to run the unit tests. This tool makes use of an Assertion Library so that tests can be written to compare the result of a function to a known output. 

Integration tests could be considered somewhat out of scope as it was not taught how to conduct them.

### Console Output

Below is a screenshot of the console output from running the tests which displays the number of tests that passed or failed:

![Test console output image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/test-console-output.PNG)

### Coverage Report

Below is a screenshot of the test coverage report that has been generated to display a breakdown of the successfully tested code in the app. The report is located in the RecipeBlogTest project inside the TestResults folder. 
The Controller code coverage is above the required 65%.

![Test Coverage Report image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/coverage.PNG)


## Front-End Design

The front-end has been built in simple HTML using simple styling with Bootstrap. It is stable and functional. 

Upon navigating to the URL, this is the home page that is presented to the user:

![home page image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/homepage.PNG)

They can see all of the blog posts in the form of recipe cards. There is a create new post button, which once clicked presents the following form:

![create page image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/createpage.PNG)

The user can enter the details to create a recipe, after which they are redirected to the Home page. If the user does not upload a file for the image, a placeholder image is added instead:

![placeholder recipe image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/noimage.PNG)

In the details view the same placeholder image appears:

![placeholder recipe image2](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/noimage2.PNG)

Clicking on a recipe card presents the recipe's details:

![details page image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/detailspage.PNG)

Here they can see the full recipe. In addition they have the options to edit the existing recipe or delete it. Editing the recipe presents the following page:

![update page image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/updatepage.PNG)

This page brings up the recipe in the same form as the create page but includes the existing data. The user can now overwrite any field. If they do not overwrite the image file, rest assured the existing image is still in place. Hitting the update button updates the recipe and brings the user back to the home page. 

The About page is simple:

![about page image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/aboutpage.PNG)

## Known Issues
* If the user attempts to create a post without entering the Title, Ingredients or Method, the expected validation message (as seen with the Servings field) is not shown. Consequently, it was coded that the creation of the post does not go ahead and that the user is redirected to the home page. 
* The pipeline succeeds all stages but the application is not shown on the URL 
  * All steps to configure the pipeline were followed and this resulted in a pipeline that succeeds
  * The reason for why the application does not appear on the URL is still unclear
  * Consequently, the application has been deployed manually for this demo
  
![pipeline image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/pipeline-results.PNG)

## Future Improvements

* For starters (no pun intended!) I'd like the known issues to be resolved - the validation prompts should appear and the pipeline to be fixed
* An improvement to the front-end to move from simple colouring to perhaps a more food-related theme
  * This could be implemented by creating a custom background image and a custom logo at the very least
  * Giving multiple themes as options to the user to select from and then applying that to the app would be a further stretch goal for a future improvement
* Allowing the user to include images for the method's steps to help show the process more clearly
  * Perhaps another database table would be appropriate to store multiple images for each recipe
* Including more fields in the form to create a recipe such as meal type, prep time, allergy information, nutrional information etc
* Making the text area in the create form for the ingredients and the method fields larger to make it easier to view what you are writing
  * Just need to add sizing to the html to make it larger
  * An ideal scenario would be to to make it dynamic so the user can resize it to their liking

## Author

Amena Rafiq

## License

[Apache License 2.0](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/LICENSE)