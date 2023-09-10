using Microsoft.EntityFrameworkCore;
using VendingMachine;
using VendingMachine.Configurations;
using VendingMachine.Repositories;
using VendingMachine.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<StorageConfigurations>(builder.Configuration.GetRequiredSection(StorageConfigurations.SectionName));
builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICoinRepo, CoinRepoImpl>();
builder.Services.AddScoped<IDrinkRepo, DrinkRepoImpl>();
builder.Services.AddScoped<CoinService>();
builder.Services.AddScoped<DrinkService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddDbContext<RepositoryContext>(
    o => o.UseNpgsql(builder.Configuration.GetConnectionString("VendingMachineDB")));

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();