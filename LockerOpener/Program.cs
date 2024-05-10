using LockerOpener.Configuration;
using LockerOpener.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var lockerOptions = builder.Configuration.GetSection("Locker").Get<LockerOptions>()
    ?? throw new InvalidOperationException("No locker configuration available");

builder.Services.AddHttpClient<LockerClient>(client =>
{
    client.BaseAddress = new Uri(lockerOptions.BaseUrl);
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddSingleton(lockerOptions);

var generalOptions = builder.Configuration.GetSection("Settings").Get<GeneralOptions>()
    ?? throw new InvalidOperationException("No settings available");
builder.Services.AddSingleton(generalOptions);

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
