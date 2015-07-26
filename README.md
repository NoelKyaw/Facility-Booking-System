# Sports Facility Booking System Version 1.1 14/10/16

## What is it?

This is the software solution for sports facility bookings and cancellation. Features included are:

- Creation and maintenance of memeber information
- Search for facility based on various criteria
- Booking of facility
- Cancelling a booking
- Generate various type of reports
- Subscribe the latest sport news

## The Latest Version

- A brand new look and feel
- Information update
- Extensive bug fixes

## Documentation

The system will be able to book facilities for the future six(6) days. The system can only place and cancel booking three(3) hours before the target booking time-slot. The location search has a higher priority than court search, which means when the location is selected the court criteria will be ignored. The RSS Feed New source can be change to sports facility related news lately, but for now it is hard coded.

### Sample Data for Database

#### Entity Relational Diagram

![](https://dl.dropboxusercontent.com/u/1725146/SA39_PROG_PROJ_IMAGE/EntityRelationDiagram.png)

#### Sample Customer Database

Customer Table

![](https://dl.dropboxusercontent.com/u/1725146/SA39_PROG_PROJ_IMAGE/Screen%20Shot%202014-10-16%20at%2011.50.59%20AM.png)

Staff Table

![](https://dl.dropboxusercontent.com/u/1725146/SA39_PROG_PROJ_IMAGE/Screen%20Shot%202014-10-16%20at%201.04.12%20PM.png)

Note: 

- Assume every sports facilities can be booked everyday (365 days a year)



## Installation

1. Copy entire project folder to local directory
2. Restore the latest version database file, namely `BookingSystemDBBackup`
3. Double click the `FacilityBookingSystem` to run the application

Note: 

- The dafault *User ID* and *Password* are both `admin` 
- The formate of *Customer ID* start with capital letter **A**, like `A000000001`



## Contacts


Team 9B Member List

|Member Name|Email Address|Phone number|
|-|-|-|-|
|Chen Gong|a0129162@nus.edu.sg|9128-8095|
|Kyaw Zay Yar Maung|a0132380@nus.edu.sg|8381-7419|
|Li Xinyang|a0123453@u.nus.edu|9092-5266|
|Soe Lynn Htike|a0112406@nus.edu.sg|8626-6033|

***

<a rel="license" href="http://creativecommons.org/licenses/by/4.0/"><img alt="Creative Commons License" style="border-width:0" src="https://i.creativecommons.org/l/by/4.0/88x31.png" /></a><br /><span xmlns:dct="http://purl.org/dc/terms/" property="dct:title">Sport Facility Booking System</span> by <span xmlns:cc="http://creativecommons.org/ns#" property="cc:attributionName">SA39 Team 9B</span> is licensed under a <a rel="license" href="http://creativecommons.org/licenses/by/4.0/">Creative Commons Attribution 4.0 International License</a>.
