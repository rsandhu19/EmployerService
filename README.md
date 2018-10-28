# EmployerService
EmployerPortalWebApp  and EmployerService

EmployerServiceDemo - API - Provided list of employers and their corresponding employees to the client. Only available to authenticated users. AuthenticationMiddleware verifies this.
EmployerServiceDemo.Service - API calls this layer which calls the data source. Any bussiness logic to be applied to the results returned from data source, can be implemented here before returning them to the client
EmployerServiceDemo.Data - Data layer - Hardcoded at this time. Could be replaced with actual data source.
EmployerServiceDemo.Domain - Contains shared classes - models,extensions etc
EmployerServiceDemo.Test.Unit - Contains unit test for trhe project
