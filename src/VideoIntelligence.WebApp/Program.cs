using Microsoft.Extensions.Configuration.Json;
using Microsoft.SemanticKernel;
using VideoIntelligence.WebApp.Components;
using VideoIntelligence.WebApp.Model;
using VideoIntelligence.WebApp.Plugins;
using VideoIntelligence.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add support for a local configuration file
builder.Configuration.Sources.Insert(0, new JsonConfigurationSource { Path = "appsettings.json", Optional = true, ReloadOnChange = true });

// Add services to the container.
builder.Services.AddLogging();

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole(); // Enable logging to the console

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


// Retrieve and validate required configuration values.
var azureModelName = builder.Configuration.GetValue<string>("AzureOpenAI:ModelName")
    ?? throw new InvalidOperationException("AzureOpenAI:ModelName is missing from configuration.");
var azureModelEndpoint = builder.Configuration.GetValue<string>("AzureOpenAI:ModelEndpoint")
    ?? throw new InvalidOperationException("AzureOpenAI:ModelEndpoint is missing from configuration.");
var azureInferenceKey = builder.Configuration.GetValue<string>("AzureOpenAI:InferenceKey")
    ?? throw new InvalidOperationException("AzureOpenAI:InferenceKey is missing from configuration.");

// Register Semantic Kernel and add Azure OpenAI Chat Completion service.
var kernelBuilder = builder.Services.AddKernel()
    .AddAzureOpenAIChatCompletion(azureModelName, azureModelEndpoint, azureInferenceKey);
kernelBuilder.Plugins.AddFromType<VideoIndexerPlugin>();
kernelBuilder.Plugins.AddFromType<EmailPlugin>();

builder.Services.AddSingleton<ChatService>();
builder.Services.AddSingleton<BlobService>();
builder.Services.AddSingleton<VideoService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

// Configure APIs for chat related features
//app.MapPost("/chat", (ChatRequest request, ChatHandler chatHandler) => (chatHandler.); // Uncomment for a non-streaming response
app.MapPost("/chat/stream", (ChatRequest request, ChatService chatHandler) => chatHandler.Stream(request));

app.Run();