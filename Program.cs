using BlazorHelloWorld.Components;

var builder = WebApplication.CreateBuilder(args);

//Using PAT
builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<AuthState>();

var pat = builder.Configuration["Dev:PersonalAccessToken"];
if (!string.IsNullOrEmpty(pat))
{
    builder.Services.AddScoped(sp => new AuthState { AccessToken = pat });
}

builder.Services.AddHttpClient("ApiClient", c =>
{
    c.BaseAddress = new Uri("https://api.eu.cryptlex.com/"); // change to your API
});
builder.Services.AddScoped<ApiClient>();


var app = builder.Build();

// Configure the HTTP request pipeline.
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
