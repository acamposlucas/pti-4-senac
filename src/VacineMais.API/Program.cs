using VacineMais.API.Data;
using VacineMais.API.Services;
using VacineMais.API.Services.Interfaces;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

// Essas linhas zeram o banco de dados.
//DbInitializer.Initialize(new AppDbContext());

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("*");
                          policy.AllowAnyHeader();
                          policy.AllowAnyMethod();
                      });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IFamiliaService, FamiliaService>();
builder.Services.AddScoped<IMembroService, MembroService>();
builder.Services.AddScoped<IImunobiologicoService, ImunobiologicoService>();
builder.Services.AddScoped<IDoseService, DoseService>();
builder.Services.AddScoped<IImunizacaoService, ImunizacaoService>();
builder.Services.AddScoped<ICarteiraVacinacaoService, CarteiraVacinacaoService>();

builder.Services.AddControllers();

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
