# About Record Shack

## Record Shack
Record shack is a basic content management system that allows users to view and interact with content. The application makes use of Forms Authentication to sign users in and out and Role Based Authorization to allow for administrator and moderator privileges. Users can view records, artists and genres as well as details about them and interact with the content by posting comments and providing ratings for records.

### Features
*	Users can search and view records, artists and genres as well as their details.   
*	Users can register and sign in to post comments and ratings on their favourite records. 
*	Administrator users can perform CRUD (Create, Read, Update and Delete) operations on all records, artists and genres.
*	Moderator users can view and remove all ratings that don’t adhere to the community guidelines.  
*	Content is loaded in dynamically making it perfect for scalable solutions. 

#### Note
Admin Login:
*	Username: fantano
*	Password: password

Mod Login: 
*	Username: sharpie123
*	Password: password

## The development process
### Challenges
The following challenges were encountered during the development of this application and how they were solved. 
*	Making use of dynamic content (e.g. Displaying records and their ratings & dynamically populating dropdown lists) – Made use of Model View View Model (MVVM) structural design pattern, to manage dynamic content. 
*	Dynamically loading in images – Created a custom HTML Helper to load in images with the source, and alt, dimensions and CSS classes. 
*	Easier navigation to details – Streamlined by using images as hyperlinks and creating overlay text that appear on hover. 
*	Admin and Mod logins – Used Role Provider to implement role based authorization to restrict access to specific areas and control of the application. 
### Technologies and Structures Used
*	.NET (C#, Razor, LINQ, Role Provider, Forms Authentication, Entity Framework)
*	SQL
*	Model View View Model (MVVM)
*	HTML, CSS & JavaScript
*	jQuery 
*	Bootstrap 4
