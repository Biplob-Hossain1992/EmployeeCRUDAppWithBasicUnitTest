i. Step: 1 
   Need to clone project from the shared repository link. 
   Then select project individually and set IIS Express instead of https/http. 
   After that go to Configure startup project and select Multiple startup project.
   Then select start EmployeeCRUDApp and EmployeeCRUDApp.UI project from action dropdown.
i. Step: 2 
   Download the db script file and open sql server and execute the script.
   Or download backup db from shared repository and just restore the db.
   Then run the project.

	*Happy Coding!

ii. I have used Clean Architechture with SOLID Repository pattern. 
    Which is Clean code, Scalable, Maintable, Easy to Understand, Easy to handle, and also faster for dapper.
    And if we want to use React.js/ Next.js etc. for the different UI project.
    Also we can separate anytime Web Api project.

    Also implemented basic unit testing for GetEmployeeById() method.

Which I ignored...
-----------------------
1. Transaction--because i didn't get any situation in this crud to implement.
   Which you have mentioned *such as adding an employee and assigning them to a department*
   this process will work and possible when department is not required for adding a employee.

   (I know what,when,and why to use the Transaction)--i just clarifying nothing else.

Deployment:
----------------------
I know how to deploy publish file (locally and Cloud server). i have experienced with that.

Due to lack of proper time I couldn't write down the details. Sorry for that.