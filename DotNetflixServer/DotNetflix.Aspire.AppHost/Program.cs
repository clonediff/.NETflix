var builder = DistributedApplication.CreateBuilder(args);

var rabbit = builder.AddRabbitMQContainer("rabbitmq");

builder.AddProject<Projects.DotNetflix_S3>("dotnetflix.s3")
    .WithReference(rabbit);

builder.AddProject<Projects.DotNetflixAdminAPI>("dotnetflixadminapi");

builder.AddProject<Projects.DotNetflixAPI>("dotnetflixapi")
    .WithReference(rabbit);

builder.AddProject<Projects.SupportChat>("supportchat")
    .WithReference(rabbit);

builder.Build().Run();
