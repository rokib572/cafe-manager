# Cafe Manager
Cafe Manager is a simple application to manage Cafe and it's Employees.

## Backend

Backend developed using 

- [.Net Framework 8.0](https://github.com/dotnet/core/blob/main/release-notes/8.0/8.0.3/8.0.203.md)
- Clean architecture, CQRS
- [Mediator Pattern](https://www.nuget.org/packages/mediatr/)
- [Autofac](https://autofac.org/)

### Database

Microsoft SQL Server used to store data for the application.

DB Script and Seed data script provided in the following folder -

`Backend/DB Script`

Update connection string in the `appsettings.json` within the `API` project

## API Endpoints

The Application provides the following endpoints -

```
POST     api/cafe: Create new cafe
PUT      api/cafe: Update an existing cafe
GET      api/cafe: Retrieve a list of cafe
DELETE   api/cafe: Delete an existing cafe

POST     api/employee: Create new employee
PUT      api/employee: Update and existing employee
GET      api/employee: Retrieve a list of employee
DELETE   api/employee: Delete an existing employee
```
To run project execute the following command

`dotnet run`

To change hosting environment, make changes in -

`API\Properties\launchSettings.json`

## Frontend

Frontend Developed using 


- [Node.js v20.12.2](https://nodejs.org/en/download/prebuilt-installer)
- [React.js](https://react.dev/)
- [TypeScript](https://www.typescriptlang.org/docs/handbook/react.html)
- [Vite](https://vite.dev/)
- [Redux](https://redux.js.org/)
- [Ant Design](https://ant.design/)
- [Ag Grid](https://www.ag-grid.com/)


### Install dependencies

```
cd src/Frontend/cafe-manager
npm i
```

### Start the development server

`npm run dev`

### Build for production

`npm run build`

### API URL

Change API URL (Backend running server and port)

```
src\cafe.ts Line# 3
src\employee.ts Line# 3
```
