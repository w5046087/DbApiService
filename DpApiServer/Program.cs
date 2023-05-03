
using DeeplHelperDb;
using DpApiServer.JwtLib;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

var jwtTokenConfig = builder.Configuration.GetSection("jwtTokenConfig").Get<JwtTokenConfig>();


builder.Services.AddControllers();
builder.Services.AddHttpClient("defaultClient");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddMemoryCache();
builder.Services.AddSwaggerGen();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    //options.SaveToken = true;
    ////options.Events.OnAuthenticationFailed = async (s) =>
    ////{
    ////   s.Response.HttpContext.

    ////};
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtTokenConfig.Issuer,
        ClockSkew = TimeSpan.FromMinutes(1),
        ValidateAudience = true,
        ValidAudience = jwtTokenConfig.Audience,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(jwtTokenConfig.Secret))
    };
});
builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});

builder.Services.AddSingleton(jwtTokenConfig);

//����ʱ���������ݿ�ȫ���̶�,û��ʱ��ȥ��ʲô����ܹ�
builder.Services.AddSingleton<DbContext>(new DbContext(builder.Configuration.GetConnectionString("SqlConnection")));

builder.Services.AddSingleton<JwtAuthManager>();


builder.Services.AddScoped<DeeplHelperDb.Service.A_AccountService>();
//builder.Services.AddScoped<DeeplHelperDb.Service.A_MessageService>();

//builder.Services.AddScoped<AccountBusiness>();
//builder.Services.AddSingleton<SendRequest>();
//builder.Services.AddSingleton<WxDetail>();


// NLog: Setup NLog for Dependency injection
builder.Logging.ClearProviders();
//builder.Host.UseNLog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
