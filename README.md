# EF-DDD-problem

#### Migration Command: `dotnet ef migrations add InitialMigration --project EF.Infrastructure --startup-project EF.Api`

### SUCCESS:
- If you leave just one configuration and the belonging DbSet (i.e. `Offices` and `OfficeConfigurations`) the migration creation will succeed
- If you run two unrelated entities configurations (`Offices` and `Municipalities`) the migration creation will succeed

### FAIL:
- If you run two related entities (`Offices` and `Departments` or `Departments` and `Municipalities` or all three) the migration creation will fail
 with `Object reference not set to an instance of an object`
 
I'm not sure am I missing something here? Thank you for your time
