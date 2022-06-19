# dotNet_Mentoring

ORM Module
Description

Database scheme: 
Order: int Id(PK), Status, DateTime CreatedDate, DateTime UpdatedDate, int ProductId(FK)
Product: int Id(PK), string Name, string Description, float Weight, float Height, float Width, float Length 

Statuses: Not Started, Loading, InProgress, Arrived, Unloading, Cancelled, Done. 

 
Functional requirements: 

Create a library and a linked test library which cover the following requirements: 

Ability to perform CRUD operations on product. 
Ability to perform CRUD operations on order. 
Ability to fetch all products. 
Ability to fetch orders (consider filtration by month, status, year, or specific product, use stored procedure). 
Ability to delete orders in bulk (on the same conditions as in item 4). 
NB! Scoreboard:

1-3 stars – The task has been implemented by using one of the ORMs. 
4-5 stars – The task was implemented using both ORMs (separate applications, no need to combine both ORM in a single solution).

When you finish, please attach zip file or link to git and change the assignment status from "Planned" to "Need(s) review".


====================================================================================================================================

HTTP Module

Description
Create two console applications:
Listener: Create an http connection listener. Use the System.Net.HttpListener class. The listener must constantly listen to the specified address (for example - http://localhost:8888/) until it receives a command to exit.
Client: Create a client to work with the http protocol. Use the System.Net.Http.HttpClient class.
Task 1: URL
Listener: implement a method to parse the request, get the Resource path from the request URL. Resource path will contain the name of the method to be executed. Implement the "GetMyName" method that will be called if “MyName” was passed to the Resource path, the method should return a response in which your name will be passed.
Client: implement a request to the URL - http://localhost:8888/MyName/, get a response, your name will be passed in the response, output it to the console.
Task 2: HTTP status messages
Client: implement requests to 5 URLs:
http://localhost:8888/Information/
http://localhost:8888/Success/
http://localhost:8888/Redirection/
http://localhost:8888/ClientError/
http://localhost:8888/ServerError/
get a response, output the status code to the console.
Listener: implement 5 methods that will form a response for the urls above with different statuses:
1xx – Information
2xx – Success
3xx – Redirection
4xx – Client error
5xx – Server error
Task 3: Header
Client: Implement URL access http://localhost:8888/MyNameByHeader/ get the response, get the value of the header "X-MyName" and output it to the console.
Listener: Implement the "GetMyNameByHeader" method, in the response add a new header "X-MyName" in which pass your name.
Task 4: Cookies
Client: Implement URL access http://localhost:8888/MyNameByCookies/ get a response, get the value "MyName" from cookies and output it to the console.
Listener: Implement the "MyNameByCookies" method, in the response add cookies "MyName" in which pass your name.
NB! Scoreboard:
1-3 stars – Task 1-2 were completed.
4 stars – Tasks 1-3 were completed.
5 stars – Tasks 1-4 were completed.

====================================================================================================================================

MVC Module

Description
You should create a website that enables operations with the Northwind Database (script with DB structure and test data can be found here - https://github.com/microsoft/sql-server-samples/blob/master/samples/databases/northwind-pubs/instnwnd.sql) .
Task 1: Base site 
Create a web site with the following pages: 
The Home page that contains a welcome message and links to other pages 
The Categories page that shows a list of categories without images 
The Products page that shows a table with the products 
The table contains all product fields 
Instead of the references to Category and Supplier, their names should be shown 
Note: All configuration parameters (connection strings, etc.) can remain in the code (hardcoded) 
Task 2: Startup and configuration 
Add a configuration feature that supports two parameters: 
Database connection string 
Maximum (M) number of products shown on the Product page (show only first M products, others – ignored; if M == 0, then show all products) 
Task 3: Edit forms and Server-side validation 
Add edit forms (New and Update) for the Products: 
Related entities (such as Category) should be presented as a dropdown list 
Add server-side validation for edited products (not less than 3 different rules) 
NB! Scoreboard:
1-3 stars – Task 1 was completed. 
4 stars – Tasks 1-2 were completed. 
5 stars – Tasks 1-3 were completed.
