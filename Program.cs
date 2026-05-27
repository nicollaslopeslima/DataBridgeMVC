using DataBridge.Data;
using DataBridge.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<ViaCepService>();
builder.Services.AddScoped<ViaCepService>();
builder.Services.AddScoped<ClienteService>();

builder.Services.AddDbContext<SqlServerContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlServer")
    )
);

var mysqlConn = builder.Configuration.GetConnectionString("MySql");
builder.Services.AddDbContext<MySqlContext>(options =>
    options.UseMySql(mysqlConn,
    ServerVersion.AutoDetect(mysqlConn)
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cliente}/{action=Index}/{id?}");

app.Run();
