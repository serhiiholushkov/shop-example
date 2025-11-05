var builder = DistributedApplication.CreateBuilder(args);

// Add PostgreSQL server resource with persistent volume
var postgres = builder.AddPostgres("postgres")
    .WithDataVolume()
    .WithPgAdmin();

// Add the shop database
var shopdb = postgres.AddDatabase("shopdb");

// Add the Web project and reference the database
builder.AddProject<Projects.shop_Web>("web")
    .WithReference(shopdb);

builder.Build().Run();
