Sample web api which connects with mongodb

Prerequisities:
.Net core 
C# extension for VSCode
NuGet Gallery extension for Vscode

Steps followed for setting up ASP.NET Web API project:
We have to manually build ASP.NET projects in VSCode (not the case with Visual Studio which is an IDE)

Follow :     https://www.syncfusion.com/blogs/post/how-to-develop-an-asp-net-core-application-using-visual-studio-code.aspx#:~:text=Create%20an%20ASP.NET%20Core%20application,-After%20installing%20the&text=Open%20that%20empty%20directory%20in,or%20Terminal%20%2D%3E%20New%20Terminal.&text=Then%2C%20it%20will%20show%20you,Select%20the%20web%20application%20option.


To install MongoDb driver for C# use:
    
    dotnet add BooksApi package MongoDB.Driver --version 2.12.2

To start with the sample application follow:
Following the link : https://docs.microsoft.com/en-us/samples/dotnet/aspnetcore.docs/aspnetcore-webapi-mongodb/
