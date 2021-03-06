[![endorse](http://api.coderwall.com/adron/endorsecount.png)](http://coderwall.com/adron)

AWS SDK + VS Toolkit Demo w/ TDD/BDD Pairing
============================================

This application is setup to provide samples for two core topics of software development;

 1. Simple Cloud Computing Architecture using ASP.NET MVC 3 + Razor.
 2. TDD and BDD Development Practices.

For testing the following libraries have been used, all retrieved utilizing NuGet.

- NSubstitute http://nsubstitute.github.com/
- NBuilder http://nbuilder.org/
- NUnit http://www.nunit.org/

Solution Folder Structure Break Down
------------------------------------

This list does not include a description for every file and folder, but instead just for specific key files and folders. This initial description is for the solution and projects located in the "AWS Toolkit Completed Example" Folder.

* Solution Items
  * .gitignore - the file has all the files and folders to ignore for git.
  * README.md - this file you're reading right now.
* AWS_MVC_Web_Application - This is the primary ASP.NET MVC Web Project.
  * _bin_deployableAssemblies - this includes all of the assemblies added via the Microsoft automated "Project dependencies..." dialog.

* Web_Application_Unit_Tests - This is the testing project for the overall solution.

Stepping Through with the Stage Projects
----------------------------------------

Each of the stages of developing TDD/BDD + Pairing Style are setup in the folders named "TDD BDD Stage XXX". Each of these projects is setup and in a particular "stage" of development moving toward the end goal of the "AWS Toolkit Completed Example" Solution.

* https://github.com/Adron/AWS-Toolkit-Samples/tree/master/TDD%20BDD%20Stage%2001 - This project shows some of the first tests written to get the application started.
* https://github.com/Adron/AWS-Toolkit-Samples/tree/master/TDD%20BDD%20Stage%2002 - This project outlines the first controller by setting up the tests, then moving forward.