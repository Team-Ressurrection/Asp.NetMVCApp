# Asp.NetMVCApp

## Salary Calculator

[![Build status](https://ci.appveyor.com/api/projects/status/ywyakxvabm7rxb7h?svg=true)](https://ci.appveyor.com/project/alexnestorov/asp-netmvcapp)
[![Coverage Status](https://coveralls.io/repos/github/Team-Ressurrection/Asp.NetMVCApp/badge.svg?branch=master)](https://coveralls.io/github/Team-Ressurrection/Asp.NetMVCApp?branch=master)

###:mortar_board:Team Members
| Name              | Academy Username  |
|-------------------|-------------------|
|                   | :white_check_mark:|
|Александър Несторов|__Alexander.N__	  |

## Project Description  

This is a simple online salary calculator that allows people to calculate their net wage, social security income, income tax and personal insurance taxes according to latest legislation changes in Labour Code. The calculator allows you to register as a company and create labor and non-labor contracts for employees and also view reports for them.

<img src="https://github.com/Team-Ressurrection/Asp.NetMVCApp/blob/master/Screenshots/HomePage.png"/>

You can view the youtube video here:

- [Youtube](https://www.youtube.com/watch?v=Sa-AEwULRps)

## Usage

#### Basic usage
 1. Register as a company or single user
 2. Add Employees
    Required parameters:
   - First Name
   - Surname
   - Family Name
   - Personal Id
 <img src="https://github.com/Team-Ressurrection/Asp.NetMVCApp/blob/master/Screenshots/AddEmployeePage.png"/> 
 
 3. Create documents
   - Employee paychecks
   - Remuneration Bills
   - calculate personal insurance of selfemployment people.
  
 <img src="https://github.com/Team-Ressurrection/Asp.NetMVCApp/blob/master/Screenshots/EmployeePage.png"/>
  
  4. Automatic calculation for each employee:
    - personal insurance
    - social security income
    - income tax
    - net wage
  5. Could view reports for all documents of their employees:
 <img src="https://github.com/Team-Ressurrection/Asp.NetMVCApp/blob/master/Screenshots/ReportsPage.png"/>
   
   - All Labor contracts
   - All Non-Labor contracts
   - All personal insurance information for selfemployment people
   - Total insurance expenses
   - Total income taxes
   - Total payments for employees

#### Registration
You can register at our website in Register menu.
Required fields for registration.
  - E-Mail: aaa@aaa.com
  - Company Name: Demo Company
  - Company Address: bul. ......

## Application public part

Everyone can see information:
  - home page: current legislation changes
  - about page: owner information
  - contact page: owner coordinates

## Application private part

#### Admin
Users with role "admin" can edit or/and delete information in settings menu.
<img src="https://github.com/Team-Ressurrection/Asp.NetMVCApp/blob/master/Screenshots/SettingsPageWithPaging.png"/>
- Paychecks
- Remuneration bills
- Users
- Employees
- Selfemployment insurance
<img src="https://github.com/Team-Ressurrection/Asp.NetMVCApp/blob/master/Screenshots/SettingsPage.png"/>  
  
#### User
Users with role "user" can create, view their own documents.
  - Labor contracts
  - Non-Labor contracts
  - Selfemployment personal insurance information

## Backend server

MSSQL server.

## Database

MSSQL.

## Test Coverage

This application is test covered almost 85% with more than 300 unit tests.

## FAQ

## Project TODOs:
  - Implement calculation with part time job, paid leave and absence
  - Detail information about personal insurance (depends on birth year before 01.01.1960 and after 31.12.1959)
  - Users to edit or/and delete their own documents
