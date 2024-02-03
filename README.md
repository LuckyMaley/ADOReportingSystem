# ADOReportingSystem (ADORS)

The ADORS automates the traditional method of generating Xlookup tables for ADO reports. It also provides detailed reports on the various contributions of ADOs in their respective modules. The ADORS also provides business intelligence reports for relevant stakeholders to assess the effectiveness of the SI programme.

The system is developed using an Asp.net web forms web app in the C# programming language. The Asp.net website also uses the Entity Framework code-first approach to connect and perform CRUD (Create, Read, Update, Delete) operations to the SQL database.

Link to the website:
[Click here](https://adoreportingsystem.azurewebsites.net/)

# Guidelines

![Static Badge](https://img.shields.io/badge/Visual%20Studio-2015%20or%20later-green) ![Static Badge](https://img.shields.io/badge/.Net%20Framework-4.5.2-blue)

### Project Structure

- The project consists of a main ASP.NET project that uses the Entity Framework Code First Approach to interact with the SQL Database.
> **Note:** An Azure SQL Cloud Database can also be implemented on this project.

- The project consists of private pages and users must have an account to use the system.
- Users have two roles, namely, member and owner.
- The Default user is an owner and the rest that register from the register page are members.
- The owner can change the role of users.

# Config

- Clone the project
- To open the project solution just double click on [XLookupReportSystem.sln](/XLookupReportSystem.sln) 

- (re)build application
> (re)building the application will install the required ASP.NET packages from NuGet
![Screenshot (4033)](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/802ab587-283f-4a62-8bdc-f5c8ff5a6cdd)



### Database Setup
- > **NOTE:** If you want to change the connection string to a live or production-ready database just go to the [web.config](/XLookupReportSystem/Web.config) 
  file and change the existing one to your database. Example of connection string below:
> ```<add name="XLookupReportingDB" connectionString="Data Source= DatabaseServerName; Integrated Security=true;Initial Catalog= YourDatabaseName; uid=YourUserName; Password=yourpassword; " providerName="System.Data.SqlClient" />```

- After changing the connection string you need to go to the Models folder and look for the [IdentityModels.cs](/XLookupReportSystem/Models/IdentityModels.cs) file
- Make sure that the string in this method is the same as the name of your connection string, e.g. "XLookupReportingDB".
```
public ApplicationDbContext()
            : base("XLookupReportingDB", throwIfV1Schema: false)
        {
        }
  ```
- open up the Nuget package manager console. Go to ```Tools > Nuget Package Manager > Package Manager Console``` 
![Screenshot (4028)](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/1be619ee-1b8b-4465-9d95-3c5856ea9a27)
- Console manager should open up now you want to start some commands so that our database tables can get migrated to your database automatically (in other words, the commands will make the application create the database tables automatically).
![Screenshot (4031)](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/f2b90fef-29b5-4bc8-99bd-85fa96483ef5)
- Before typing any commands, go to the Solutions Explorer and look for the Migrations folder. Make sure to delete any files that are numbered in this folder before you can start doing migrations.
![Screenshot (4032)](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/3b0d3568-5d66-42f7-b512-ed5d770564f6)

- Now type the following command on the NuGet package manager console
  > ```Enable-Migrations -ContextTypeName XLookupReportSystem.Models.XLookupReportingDB -Force```
- After migrations have been enabled, type this below:
  > ```Add-Migration InitialCreate```
- Then type this:
  > ```Update-Database```
- Now the database tables should be added to your database 
> You must update the database with application data every time you update the tables so the db and app are in sync.

- After the commands have been implemented successfully, you need to run the application and it will create a default user who is an owner when you register a member. You can see the details and change the credentials of your default user by going to the [StaffController.cs](/XLookupReportSystem/Controllers/StaffController.cs) file in the Controllers folder and you will see the defaultStaff method.
- All registered users from the main website are members, and owners can change their roles accordingly. 

# Some noticeable improvements for future work 

- The forgot password feature can be improved using the GMAIL API to send an email to users who forgot their password.
- The system can be improved to include analytics in the form of a dashboard for the individual users and owners. As well as overall analytics.
- The help system can be more detailed to cater to all types of users new or novice.

# Screenshots

- Welcome to the ADO Reporting System Screenshot Guide section. This section provides a comprehensive guideline on using the ADO Reporting System.
 ### Contents

1. [Accessing System](/README.md#accessing-system)
   - [Logging in](/README.md#logging-in)
   - [Logging out](/README.md#logging-out)

2. [Profile](/README.md#profile)
   - [Edit Profile](/README.md#edit-profile)

3. [Users](/README.md#users)
   - [Add User](/README.md#add-user)
   - [Edit User](/README.md#edit-user)
   - [Deleting Users](/README.md#delete-users)

4. [Projects](/README.md#projects)
   - [Create Project](/README.md#create-project)
   - [View Project](/README.md#view-project)
   - [Combine Project](/README.md#combine-project)



### Accessing System
1.	You need to log into the system. By default, there is only one owner created that can add users and make them owners, too.
2.	Please click on the link below to access the website:
[Click here](https://adoreportingsystem.azurewebsites.net/)

#### Logging in
1.	Enter your owner login details.
![Picture24](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/6d60c8f6-181b-4bdf-bfde-4da04bfd467c)
2.	Once you’re logged in, you will be redirected to the dashboard, where you can see your details and recent projects, and other functions.
![Picture25](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/7cebcc21-e050-4794-bc50-1d1554a916ab)

#### Logging out
1.	To log out of the system click your profile image on the top right of the page and a drop down menu will appear with different options just click on sign out to log out of the system.
![Picture26](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/5d832fa8-6167-46be-a1fc-10557d81c161)

### Profile
1.	Click on the profile link on the sidebar menu under the settings heading and you will be redirected to the profile page.
![Picture27](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/8678cd83-e297-46a5-ad51-212fd66a92c3)

#### Edit Profile
1.	Click on the Edit profile tab to edit your profile.
![Picture28](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/63824ad0-e842-4eb3-b150-82344e81dcf5)
2.	Click on the upload image button and choose an image.
![Picture29](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/39fc994b-8e32-4396-9fb4-423885d1aa62)
3.	Once, image is chosen it will be updated to your profile.
![Picture30](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/0fd6dea1-01bf-4a54-8d5f-0df528a1c396)
4.	You can remove the image or change the image, if you want to.
5.	You can also update your profile details (Firstname, Surname, and Campus, Discipline) just make sure to click the save changes button.
![Picture31](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/4c7f97c7-fa87-432b-ad7c-5087b19452d2)
![Picture32](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/427a2a7e-14be-4979-a0fd-14148bf652a3)
6.	You can also change your password, you first need to put in your current password, then your new password and make sure to confirm your new password and click save changes to update your password.
![Picture33](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/a0906daa-f407-4ba5-a1d2-616bd0bd9abe)
![Picture34](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/d347d492-87e1-49e1-8af7-e2dd19209d1a)

### Users
1.	Click on the Users link on the sidebar menu and you will be redirected to the users page. Where, you can add, edit and view the users in the system.
![Picture35](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/583bcea6-2d7d-42f7-8aa8-fdef7e041484)

#### Add User
1.	Click on the Add User button.
![Picture36](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/fbafdd61-e92f-4ac4-8db6-3964af686f04)
2.	Enter details of a new user with their role and click on the save changes button when all the details have been entered.
![Picture37](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/98d75d41-ce3f-4068-b951-8232afd2dcfd)
3.	Once, you’ve clicked the save changes button and all details have been entered correctly, you will be redirected to the users page and you will see the new user within the list of users.
![Picture38](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/84803cd6-742d-40fe-b2b7-e43f9ff6a9f7)

#### Edit User
1.	Click on the select link on the user you want to edit. In this example, Jomo Cosmos is selected for editing.
![Picture39](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/4daf7c5a-d263-422c-b4b6-b3a9a09c014d)
2.	You can change the users' details and make sure to save changes.
![Picture40](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/1b48fe32-fb46-4a7f-9e6a-eef41949073a)
3.	You can change the user password. Just enter the new password and confirm it, then click the save changes button.
![Picture41](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/f764584e-e8f6-42ba-8c48-2d11929a8875)
4.	You can navigate to the Users page once you are done editing the user.
![Picture42](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/e150ec96-3922-485c-aed4-b5e7ccb2a2d8)

#### Delete Users
1.	You can also delete a user, if necessary make sure to confirm that you want to delete them.
![Picture43](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/8836a52c-b784-426f-8a68-a63cde5e3832)
2.	If you click delete user, the user will be permanently deleted from the system and you will be redirected to the user's page.
![Picture44](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/9f685044-8833-4196-b420-6bb6d4acb158)

### Projects
1.	Click on the Projects link on the sidebar menu and you will be redirected to the projects page. Where, you can add, combine and view the projects in the system.
![Picture45](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/85901ea2-407e-400b-b307-41ff683fb635)

#### Create Project
1.	Click new project button and you will be redirected to the create page.
![Picture46](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/b9401de4-3bd8-4790-bc2e-2d2a16eb7c8d)
2.	Enter the module code, semester, campus, and year then click on the next button. A project name will be automatically created and be displayed on the next page.
![Picture47](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/436da639-20c1-429d-93df-6316a32eb165)
3.	Select the register from your stored files.
![Picture48](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/ab60fc22-9a78-41ba-b0f8-8ec219ecda1c)
![Picture49](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/4e2e5b54-2ac4-4134-93e5-3ed59dab9a34)
4.	Upload the main exam data from SMS.
![Picture50](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/9402d059-028c-4e2c-a945-bf06effa860e)
![Picture51](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/ea6be7a0-445d-41e5-a3e3-849396321a5f)
5.	Upload the supp exam data (if it is available)
![Picture52](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/93f1f569-2651-486f-a3c7-263efe78bb07)
![Picture53](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/e3704e2a-9b07-44ec-9f95-8bbb3163cede)
6.	Upload the Beginning of the semester (previous semester) negative term decisions excel file.
![Picture54](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/452ec49f-906d-4695-9775-9d54a70a4599)
![Picture55](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/d06674d5-9da1-4972-b4d8-1aec91ecab6e)
7.	Upload the end of the semester (current semester) negative term decisions.
![Picture56](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/ac6eeeaa-ff05-4110-abb7-66e23bea5d4b)
![Picture57](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/53634687-f83e-4c2f-b98d-967bd0b21f89)
8.	Click the Create button and wait will the system processes all the data. Once processing is done, you will be able to view your project and download your project.

#### View Project
1.	Click on any project card to view a project. You can export (download), delete the project, or create another new one.
![Picture58](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/c0a68e5b-b456-4633-ad23-89bfed67057c)

#### Combine Project
1.	Select the projects you want to combine using the checkbox on each project to select it.
![Picture59](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/600016fd-7ce9-4454-bb2a-f6cbcaa132d9)
2.	Once selected, click the combine projects button and confirm that you want to combine the projects.
![Picture60](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/cd716349-8505-449a-adfc-ca53dc604176)
3.	Once confirmed, you will be redirected to the download page. Where you will wait 5 seconds and the file should be downloaded automatically.
![Picture61](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/671b1723-b814-41c6-a565-73bdb0a87877)
4.	Choose the folder to save the combined project and you can open it after the download is finished.
![Picture62](https://github.com/LuckyMaley/ADOReportingSystem/assets/58641501/d8d89dac-a20e-4ef9-9e6d-b6f90cda93a4)

# Demo

<video src='https://www.youtube.com/watch?v=XX6pfbPN3os' width=100%/>

