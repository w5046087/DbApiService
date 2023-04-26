//using NLog;
//using NLog.Web;

//var logger = NLo1g.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
//welcome back1111
using DpApiServer.Core.Account;
using DpApiServer.DbHelper;
using DpApiServer.HttpLib;
using DpApiServer.JwtLib;
using DpApiServer.WeiXinLib;
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
    options.SaveToken = true;
    //options.Events.OnAuthenticationFailed = async (s) =>
    //{
    //   s.Response.HttpContext.

    //};
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
    // 忽略循环引用
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    // 为空忽略
    options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});
// Add services to the container.

builder.Services.AddSingleton(jwtTokenConfig);

//这里时间问题数据库全部固定,没有时间去搞什么三层架构
builder.Services.AddSingleton<DbContext>(new DbContext(builder.Configuration.GetConnectionString("SqlConnection")));







builder.Services.AddSingleton<JwtAuthManager>();//这个jwt无非就一个token以及一个refreshToken 每隔3分钟向服务器请求一次刷新即可.就做完了




//builder.Services.AddScoped<DeeplHelperDb.Service.AccountService>();
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
