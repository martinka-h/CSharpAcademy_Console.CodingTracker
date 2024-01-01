# CSharpAcademy_Console.CodingTracker

## Requirements

- [ ] The application should register coding sessions
- [x] Create a sqlite database along with a table on application start, if one isn't present.
- [x] The application should show the user a menu of options.
- [ ] Insert, delete, update and view the logged habit functionality.
- [ ] Error handling so that the application never crashes.
- [ ] The application should only be terminated when the user inserts "0".
- [ ] Only interact with the database using raw SQL.
- [x] The project needs to contain a README file.
- [ ] The application should store and retrieve data from a real database
- [ ] Use the "ConsoleTableExt" library to show the data on the console.
- [ ] Have separate classes in different files 
- [ ] Specify the format for the input of time and date, and accept only this.
- [ ] Have a configuration file that contains the database path and connection strings.
- [ ] Have a "CodingSession" class in a separate file, that will contain the properties of your coding session: Id, StartTime, EndTime, Duration.
- [ ] The duration of the session should be calculated based on the Start and End times, in a separate "CalculateDuraion" method.
- [ ] The user should be able to input the start and end times manually.
- [ ] Read your table into a List of Coding Sessions when reading from the database.

## Challenges

- [ ] Add the possibility of tracking the coding time via a stopwatch so the user can track the session as it happens.
- [ ] Let the users filter their coding records per period (weeks, days, years) and/or order ascending or descending.
- [ ] Create reports where the users can see their total and average coding session per period.
- [ ] Create the ability to set coding goals and show how far the users are from reaching their goal, along with how many hours a day they would have to code to reach their goal. You can do it via SQL queries or with C#.

