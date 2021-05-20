# Gold Badge Project - Komodo - Eleven Fifty Academy

## Table of Contents
* [Introduction](#Introduction)
* [Installation](#Installation)
* [Usage](#Usage)
* [Technology](#Technology)
* [License](#License)
* [Contact](#Contact)

## Introduction

This is a solution is a collection of console applications demonstrating use of repository design pattern, among other aspects of C#. There are 4 console applications, each with three assemblies; UI, repository, and unit tests. Below is a brief descripton of each application.

1- Console application is for a restaurant adminstrater to view, add, update, and delete meals from the current menu. This application utilizes a list of MenuItem objects for it's repository. <br><br>
2- Console application is for an insurance company and their claims. This application uses a queue for the repository. Using this tool, you can view all current claims, add a claim to the end of the queue, and remove the claim from the beginning of the list (when claim is 'handled'). <br><br>
3- Console applicatoin is for a company to keep track of it's employee's badge numbers in regards to which doors the badge gives access to. We utilize a dictionary with badge ID's as the key, and a list of strings as the doors the badge grants access to. From the console the user can add a new badge, edit a badge by adding or removing a door, and list all the badges along with the doors each badge gives access to. <br><br>
4- Console application is used to keep track of a company's outing expenses. Within the application, the user can display all outings on record, add a new outing, view total cost of all outings, and view total cost of outings by type (which we organize with an enum). The outing object also has properties with values automatically set based on values of other properties.

## Installation

Use Git Hub to download the code or clone directly from Git Hub.

## Usage
Download the solution, use Visual Studio or preferred IDE and select your choice of console assembly as the start up project. Run the program and follow the directions in console.


<img src="https://github.com/BenjaminEllis7711/KomodoProject/blob/master/BadgeDemo.png">

## Technology
C# and Visual Studio 2019

## License
[MIT](https://choosealicense.com/licenses/mit/)

## Contact
[Benjamin Ellis](Benjamin.Ellis7711@gmail.com)

