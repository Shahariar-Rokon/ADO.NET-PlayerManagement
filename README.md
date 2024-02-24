# ADO.NET PlayerManagement Software

## Description

This project is created using Windows Forms Application. Here I used a hypothetical scenarion where a manage can add their team information as Master information and player details as details information.

In this project, I've created a hypothetical scenario about a software where you can:

- Save Team information.
- Save multiple player information.
- Add multiple player information to the Team.
- Check individual Player report summary using **Crystal Report**
- Check individual Team report summary using **Crystal Report**
- Check Summary report summary using **Crystal Report**
- Handle master-details relationships.

This project is intended to showcase the features and capabilities of Windows Forms Application using ADO.NET data connection scheme. 

## Installation

### Prerequisite

- You must have Microsoft Visual Studio.
- You must have Microsoft SQL server and Microsoft SQL Server Management Studio.
- You must install the Crystal report in Visual Studio. 

To install and run this project, follow these steps:

1. **Clone the repository**: Clone the repository to your local machine using the GitHub CLI command:

   ```shell
   gh repo clone Shahariar-Rokon/ADO.NET-PlayerManagement
   
Alternatively, you can download the ZIP file from the GitHub repository page: https://github.com/Shahariar-Rokon/ADO.NET-PlayerManagement.git
  
2. Open the project in Visual Studio 2022: Open Visual Studio 2022 and select “Open a project or solution”. Navigate to the folder where you cloned or downloaded the repository and select the .sln file.

3. Now right click on the project file and go to **Add New Item--->Select Data from the left side of the VS-->Select Service Based Database.mdf

4. Connect the database to our application: You need to go to project then properties then navigate to Settings.settings. Double click on Settings.settings. A new UI will open where you can add the name of the connection and the type of the connection. Add any name you desire then add ConnectionStrings as types. Then press the three dots …. A browser window will pop up. From there, you have to select DataSource as Microsoft SQL Server DatabaseFile then click OK. After that, navigate to Database File Name, browse and select the database that you attached earlier. Note that the name of the database will end with .mdf. Finally, press Apply and OK.

5. Use the provided Database.Sql file: Use the provided Database.Sql file to mimic the database that I was using. In case you want to try it out of the box, you should also seed the database using the commands found at the bottom of the Database.Sql file. Also note that the salaries and the categories of the players have to be pre-populated by using the query. This ensures that the dropdown can get the data for selection.

6. Restore the NuGet packages: Right-click on the solution in the Solution Explorer and select “Restore NuGet Packages”. This will install the required dependencies for the project.

7. Run the project: Press F5 or click the “Run” button to launch the project. 
   
## Usage

To use this project, follow these steps:

1. After completing the necessary steps and seeds, run the application. You will be greeted with a **Windows Forms** interface.
2. The form is divided into four sections. Each colored section is responsible for a submission, and the other two are responsible for displaying the results.
3. The Team Information section contains an input area where you can add team information. However, you should not click the add button until the players have been added.
4. The Player Information section holds the categories of players, **A to E**, and their salary information. You can add multiple players with their salary information to a team.
5. The box at the top right corner displays the total number of players that you have added, and the box located at the bottom of the form shows the team information when it is submitted.
6. On the other hand, you can use the **Remove** button to remove any entry from the form.
7. Finally, click the add button in the **Team Information** section to add the players to the team.
8. You can see buttons labeled **Master Report** and **Details Report**. By pressing them, you can obtain subsequent information about the master and details information in the form of a Crystal report.
9. You are good to go.
    
## Contributing

We welcome contributions from anyone who is interested in improving this project. Here are some ways you can contribute:

- Report bugs or suggest features by opening an issue.
- Fix bugs or implement features by submitting a pull request.
- Review pull requests and provide feedback.
- Write or update documentation, tests, or examples.
- Share your experience or feedback with the project.

## License

This project is licensed under the MIT License. See the LICENSE file for details.
