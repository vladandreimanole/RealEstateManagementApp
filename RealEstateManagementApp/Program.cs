
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RealEstateApi", Version = "v1" });
});
builder.Services.AddCors();
builder.Services.AddDbContext<RealEstate_AppContext>();
builder.Services.AddTransient<IDataService, DataService>();
var app = builder.Build();

//migrate any database changes on startup
using(var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<RealEstate_AppContext>();
    dataContext.Database.Migrate();
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCors(c => c.SetIsOriginAllowed(origin => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials());

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TargetManagementAPI v1"));

app.UseRouting();

app.UseAuthorization();

app.Run();
