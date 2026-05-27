using Assignment4_App5.Services;
using Assignment4_App6.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// App 05 - Authentication State Manager Registration
builder.Services.AddSingleton<Assignment4_App5.Services.AuthenticationStateService>();

// App 06 - Notification DI Configurations Registry
builder.Services.AddSingleton<Assignment4_App6.Services.NotificationConfig>();
builder.Services.AddScoped<Assignment4_App6.Services.NotificationService>();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
