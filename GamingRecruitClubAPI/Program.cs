using GamingRecruitClubAPI.DataContext;
using GamingRecruitClubAPI.Repositories;
using GamingRecruitClubAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<GamingClubDataContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));

builder.Services.AddTransient<IDevInfosRepository, DevInfosRepository>();
builder.Services.AddTransient<IDevInfosService, DevInfosService>();
builder.Services.AddTransient<IGameInfosRepository, GameInfosRepository>();
builder.Services.AddTransient<IGameInfosService, GameInfosService>();
builder.Services.AddTransient<ITesterInfosRepository, TesterInfosRepository>();
builder.Services.AddTransient<ITesterInfosService, TesterInfosService>();
builder.Services.AddTransient<ICompanyInfosService, CompanyInfosService>();
builder.Services.AddTransient<ICompanyInfosRepository, CompanyInfosRepository>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());




var app = builder.Build();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c=>c.InjectStylesheet("/assets/css/site.css"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
