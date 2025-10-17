var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.shop_Web>("web");

builder.Build().Run();
