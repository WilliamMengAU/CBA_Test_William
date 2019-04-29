# CBA_Test_William
Test projects for CBA. 
The project's readme file is located in the project folder.

I think of 3 ways to implement the requirements.

1, Using a functions name to delegate functions map (dictionary). It's simple.

2, Using Reflection. Define a list of static functions in a class, then use reflection to find which one should be called.
   The solution 1 is based on this idea. Then I want to use a interface to restrict the functions must to be implemented.
   In this stage, I found "You can't define static members on an interface in C#. An interface is a contract for instances."
   So the solution 1 become to the current implemention.
   
3, Define a base rule class derived from a interface, and define a derived class for each rule including rule process and rule validation functions.
   Using reflection to decide which class should be make instance.

#### Some Ideas can be added: ####
- Can use multi Task to run these rules parallelly.
- Can use setting file to batching process a list of input files and rules define files.
- Make the rule processing classes and functions to a DLL, then other projects can easily use it.
- Can use .net core, cross platform, better performance.


#### Requirement: ####

- Run counting rules;
- easily add, stop ...;
- ...


#### Implementation: ####

The solution must conform to the below requirements:

- C#/ Visiual Studio 2017+;
- 



#### Data Source ####





#### Submission ####




#### Hints ####
* 

