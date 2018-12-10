# OE NIK Prog3 Project 2018

My solution of the C# project was to mock the Logic class since that
was the target object that needed testing. (Instruction mentions Logic's methods)
Instead of mocking the Repository with an interface (Which seems a silly solution)
I used "concrete" mocking, by adding the "virtual" tag to those specific methods
which were called by the mock/nunit3 adapters. This allows mock to fake the selected
method / getter / setter without screwing up the database.

All of the methods of the projects are pretty simple, and It contains a lot of verifications
to avoid unnecessary exceptions from the given inputs. Just in case I added a couple of
try-catches to provide valid information upon an unwanted exception.

The program's java part simply calls a Java Websocket, which then processes the request
with the given parameters, and forwards It to a servlet.
The servlet gives a simple JSON output.
The C# code then reads It using the Newtonsoft library, and adds It to the DB.
There are no value checks, just a simply try catch in Java which will warn the C# program
that we have received incorrect values If we gave wrong inputs.