# MarsRover
Technology:
•	ASP.NET Razor Pages front-end.
o	Chosen because I am currently working on a personal project using them. I like taking things back to the code-behind like WPF or WebForms. MVC is a lot of fun, but it can get cumbersome.
•	Libraries in .Net Framework 4.8 
•	N-tier Architecture:
o	Tiered architecture is important to allow for separation of concern between tiers. My business logic is in the Application project, and all things related to the user experience are in the Web project. I did not need a persistence/infrastructure layer for this project, but it could be easily implemented.
•	Dependency Injection:
o	Using .Net Core’s built-in DI for my services for inversion of control
•	Model Validation:
o	View Model is validated with Data Annotations.
•	Error Handling:
o	A friendly message is displayed to the user if an error occurs, while Serilog logs the real error.
•	Logging:
o	Using Serilog for logging to Debug console only. Serilog has sinks you can use to alter where the logs go with a single line in the program.cs file.
o	Also uses DI wherever you want to drop it into.
•	Testing:
o	Using Shouldly for unit tests on my application project. It is a great framework and reads more like English.
Code:
•	Using a View Model to pass user input to the CommandCenterService. 
•	The View Model is validated against “Required” and “RegularExpression” data annotations. The user is notified if any field is incorrectly entered.
•	The service converts the data into input for the RoverService.
•	The Rover service performs the business logic to determine where the Rover moves to.
•	The Rover’s coordinates are returned on the Rover object.
•	The View Model is then set with the user-friendly output of the Rover’s location and bearing.
•	The user is displayed the output above the 
