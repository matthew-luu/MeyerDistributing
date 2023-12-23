# MeyerDistributing
This is the take-home assignment for the Junior Software Engineer position.

To Build and Run:
	open terminal and use 'dotnet build -o out'
		this builds the .NET application
	use 'dotnet run out'
		this runs the program

All changes should be highlighted by comments.
Files that have changes:

CustomerBase.cs
Order.cs
IOrder.cs
Program.cs
InterviewTest.csproj

Version:
	Changes were made to the InterviewTest.csproj file to use net8.0

Requirement 1:
	CustomerBase.cs
		All three functions are implemented.
Requirement 2:
	Order.cs, IOrder.cs, Program.cs
		Used DateTime to get the time of order. Updated the ConsoleWriteLineResults() block to show implementations.
Bug 1:
	Just added a single line that was missing in the ProcessTruckAccessoriesExample() block
Bug 2:
	Seperated instances of OrderRepository and ReturnRepository to fix this issue. The bug was caused by the second example building upon the same totals from the first example.