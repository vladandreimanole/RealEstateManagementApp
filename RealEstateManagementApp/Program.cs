
using EmailSender;
using RealEstateManagementApp.Jobs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(opt => {
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "https://localhost:5001",
            ValidAudience = "https://localhost:5001",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"))
        };
    });
// Add services to the container.
builder.Services.AddControllers(opt =>
{
    // remove formatter that turns nulls into 204 - No Content responses
    opt.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RealEstateApi", Version = "v1" });
});
builder.Services.AddCors();
builder.Services.AddTransient<IEmailSender, EmailSenderClass>();
builder.Services.AddSingleton<IWorker, Worker>();
builder.Services.AddDbContext<RealEstate_AppContext>();
builder.Services.AddTransient<IDataService, DataService>();
builder.Services.AddTransient<IResetPasswordManager, ResetPasswordManager>();
builder.Services.Configure<AuthentificationOptionsMonitor>(builder.Configuration.GetSection(nameof(AuthentificationOptionsMonitor)));
builder.Services.Configure<EmailOptionsMonitor>(builder.Configuration.GetSection(nameof(EmailOptionsMonitor)));
builder.Services.AddSignalR();
builder.Services.AddHostedService<RentReminderJob>();

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
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RealEstateApp v1"));

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
  {
      endpoints.MapControllers();
      endpoints.MapHub<ChatHub>("/chatsocket");
  });
  app.Run();
