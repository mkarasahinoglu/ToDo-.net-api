using Microsoft.EntityFrameworkCore;
using ToDo_API_SR.Data.SubToDo;
using ToDo_API_SR.Data.ToDo;
using ToDo_API_SR.Data.User;
using ToDo_API_SR.Data.Utilities;
using ToDo_API_SR.Service.SubToDo;
using ToDo_API_SR.Service.ToDo;
using ToDo_API_SR.Service.User;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Database Connection
var connectionString = "Data Source=(localdb)\\LocalDB;Initial Catalog=ToDoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
builder.Services.AddSingleton<IDatabaseConnection>(s=> new DatabaseConnection(connectionString));


// User Data
builder.Services.AddSingleton<IGetUserByIdDataRequest, GetUserByIdDataRequest>();
builder.Services.AddSingleton<IInsertUserDataRequest, InsertUserDataRequest>();
builder.Services.AddSingleton<IDeleteUserByIdDataRequest, DeleteUserByIdDataRequest>();
builder.Services.AddSingleton<IUpdateUserByIdDataRequest,UpdateUserByIdDataRequest>();

// User Service
builder.Services.AddSingleton<IGetUserByIdServiceRequest, GetUserByIdServiceRequest>();
builder.Services.AddSingleton<IInsertUserServiceRequest, InsertUserServiceRequest>();
builder.Services.AddSingleton<IDeleteUserByIdServiceRequest, DeleteUserByIdServiceRequest>();
builder.Services.AddSingleton<IUpdateUserByIdServiceRequest,UpdateUserByIdServiceRequest>();

// ToDo Data
builder.Services.AddSingleton<IGetToDoItemByIdDataRequest, GetToDoItemByIdDataRequest>();
builder.Services.AddSingleton<IInsertToDoItemDataRequest, InsertToDoItemDataRequest>();
builder.Services.AddSingleton<IDeleteToDoItemByIdDataRequest,DeleteToDoItemByIdDataRequest>();
builder.Services.AddSingleton<IUpdateToDoItemByIdDataRequest,UpdateToDoItemByIdDataRequest>();
builder.Services.AddSingleton<IUpdateToDoProgressDataRequest, UpdateToDoProgressDataRequest>();
builder.Services.AddSingleton<ISwitchToDoIsDoneDataRequest, SwitchToDoIsDoneDataRequest>();
builder.Services.AddSingleton<ISwitchToDoIsDoneByIdDataRequest, SwitchToDoIsDoneByIdDataRequest>();

// ToDo Service
builder.Services.AddSingleton<IGetToDoItemByIdServiceRequest, GetToDoItemByIdServiceRequest>();
builder.Services.AddSingleton<IInsertToDoItemServiceRequest, InsertToDoItemServiceRequest>();
builder.Services.AddSingleton<IDeleteToDoItemByIdServiceRequest,DeleteToDoItemByIdServiceRequest>();
builder.Services.AddSingleton<IUpdateToDoItemByIdServiceRequest, UpdateToDoItemByIdServiceRequest>();

// SubToDo Data
builder.Services.AddSingleton<IGetSubToDoItemByIdDataRequest,GetSubToDoItemByIdDataRequest>();
builder.Services.AddSingleton<IInsertSubToDoItemDataRequest,InsertSubToDoItemDataRequest>();
builder.Services.AddSingleton<IDeleteSubToDoItemByIdDataRequest,DeleteSubToDoItemByIdDataRequest>();
builder.Services.AddSingleton<IUpdateSubToDoItemByIdDataRequest,UpdateSubToDoItemByIdDataRequest>();
builder.Services.AddSingleton<ISwitchSubToDoIsDoneByIdDataRequest, SwitchSubToDoIsDoneByIdDataRequest>();
builder.Services.AddSingleton<ISwitchAllSubToDoIsDoneDataRequest, SwitchAllSubToDoIsDoneDataRequest>();

// SubToDo Service
builder.Services.AddSingleton<IGetSubToDoItemByIdServiceRequest,GetSubToDoItemByIdServiceRequest>();
builder.Services.AddSingleton<IInsertSubToDoItemServiceRequest, InsertSubToDoItemServiceRequest>();
builder.Services.AddSingleton<IDeleteSubToDoItemByIdServiceRequest,DeleteSubToDoItemByIdServiceRequest>();
builder.Services.AddSingleton<IUpdateSubToDoItemByIdServiceRequest,UpdateSubToDoItemByIdServiceRequest>();
builder.Services.AddSingleton<ISwitchSubToDoIsDoneByIdServiceRequest,SwitchSubToDoIsDoneByIdServiceRequest>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
