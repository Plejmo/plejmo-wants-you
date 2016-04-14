# Backend Developer Instructions

The solution is a simple web site for an imaginary company. The web site displays average rating for movies.
The product owner has discovered a number of issues with the solution that they want fixed and they have some new requirements as well.
The new requirement is to build a Rest API that other applications can call to get access to the amazing movie rating data.

There might be other problems with the soluition as well... who knows...

Your mission, should you choose to accept it, is to resolve the issues, refactor the code as you see fit and implement the Rest API.

## Issues
* It should not be possible to give a movie a rating less than 1 or greater than 5. There's currently no restrictions at all.
* Only registered and logged on users should be able to rate movies.
* You should not have to enter your user id when rating a movie.
* The users have complained that it is annoying that the browser reloads the page when rating movies.

## Rest Api Requirements
* Api users must provide a personal api key in order to access the api. 
* Anonymous access to the Api should not be allowed.
* It should be possible to get average rating for all movies.
* It should be possible to get average rating for a specific movie.
* It should be possible to save rating for a movie through the API.
* The API should return responses in JSON format.
* The JSON should use *camelCase* (example: { "firstName": "John Doe" })

## Guidelines
* The solution should be built using Visual Studio 2013 or 2015 and target framework 4.5. There is a [community edition](https://www.visualstudio.com/en-us/news/vs2013-community-vs.aspx) that is free for personal use.
* The Rest API should be implemented using Asp.Net WebApi.
* Quality code is tested code. Your solution should contain some sort of tests that verify that the code works as expected. It should be possible to run these tests from within Visual Studio.
* It should be possible to start the solution from within Visual Studio - there should be no manual configuration or installation involved.
* The use of NuGet is encouraged.

## What does the initial solution contain?
The solution contains the project "plejmo-wants-you" which is what you will be working on in this assignment.
It uses a SQLite database that's located in the App_Data folder. 

### Initial Data
When you first download the repository the database will contain the following:

#### Movies:
```
| Id | Title                        |
| -- | ---------------------------- |
| 1  | The Big Lebowski             |
| 2  | Ex Machina                   |
| 3  | Star Wars: A New Hope        |
| 4  | Kurt Cobain: Montage of Heck |
| 5  | Minions                      |
```

#### Users:
```
| Id | UserName            | FirstName | LastName |
| -- | ------------------- | --------- | -------- |
| 1  | john.doe@plejmo.com | John      | Doe      |
| 2  | jane.doe@plejmo.com | Jane      | Doe      |
```

#### Ratings:
```
| UserId | MovieId | Rating |
| ------ | ------- | ------ |
|1       |1        |1       |
|1       |2        |2       |
|1       |3        |3       |
|1       |4        |4       |
|1       |5        |5       |
|2       |1        |5       |
|2       |2        |4       |
|2       |3        |3       |
|2       |4        |2       |
|2       |5        |1       |
```

### Database Schema
```
CREATE TABLE `Movies` (
	`Id`	INTEGER NOT NULL,
	`Title`	TEXT NOT NULL,
	PRIMARY KEY(Id)
)

CREATE TABLE `Ratings` (
	`UserId`	INTEGER NOT NULL,
	`MovieId`	INTEGER NOT NULL,
	`Rating`	INTEGER NOT NULL,
	PRIMARY KEY(UserId,MovieId)
)

CREATE TABLE `Users` (
	`Id`	INTEGER NOT NULL,
	`UserName`	TEXT NOT NULL UNIQUE,
	`FirstName`	TEXT NOT NULL,
	`LastName`	TEXT NOT NULL,
	PRIMARY KEY(Id)
)
```