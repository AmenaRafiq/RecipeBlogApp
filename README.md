# Recipe Blog App

## Project Status

Project development and hosting services have been STOPPED. 

## Brief

The project brief outlines the overall objective: 

> To create a CRUD application with the utilisation of supporting tools, methodologies and technologies that encapsulate all core modules covered during training.

(A CRUD application implements 4 basic functionalities: create, read, update and delete). Core module that this project will encapsulate: Software Development Lifecycle, Agile development, Git, Databases, ASP.NET Core, Azure Core Services and Azure DevOps.

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

insert risk assessment

## Testing

[XUnit](https://xunit.net/) has been used to run unit tests. This tool makes use of an Assertion Library so that tests can be written to compare the result of a function to a known output. 

### Console Output

Below is a screenshot of the console output from running the tests which displays the number of tests passed or failed:

![Test console output image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/test-console-output.PNG)

### Coverage Report

Below is a screenshot of the test coverage report that has been generated to display a breakdown of the successfully tested code in the app. The report is located in the RecipeBlogTest project inside the TestResults folder. 
The Controller code coverage is above the required 65%.

![Test Coverage Report image](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/DocsForReadME/coverage.PNG)


## Front-End Design

-

## Known Issues
-

## Future Improvements

-

## Author

Amena Rafiq

## License

[Apache License 2.0](https://github.com/AmenaRafiq/RecipeBlogApp/blob/main/LICENSE)