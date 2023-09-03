using Microsoft.AspNetCore.StaticFiles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
   // options.InputFormatters.Add()
   //koji input ili output formater da stavimo da je prvi biva novi default
    options.ReturnHttpNotAcceptable = true; //ako neko npr trazi xml a mi imamo sam JSON podesen
}).AddXmlDataContractSerializerFormatters(); //ako hocemo da mozemo da radimo s xml-om ovo to resava(a ovo gore i dalje pokriva preostale formate)
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<FileExtensionContentTypeProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); //ovako mi ide preko edge-a a ne google chrome-a i dalje?
    app.UseSwaggerUI(); 
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//app.MapControllers(); //ovako mi ide preko google chrome-a

//app.Run(async (context) => { await context.Response.WriteAsync("Hello World!"); }); //ovako mi ide preko edge-a a ne google chrome-a?
//ne treba nam ovo nego cemo preko kontrolora sve da radimo sad 


app.Run();
