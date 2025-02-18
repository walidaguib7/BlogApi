using BlogApi.Data;
using BlogApi.Hubs;
using BlogApi.Interfaces;
using BlogApi.Models;
using BlogApi.Repositories;
using BlogApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});
;
builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IFiles, FilesRepo>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ICategory, CategoryRepo>();
builder.Services.AddScoped<IPost, PostRepo>();
builder.Services.AddScoped<IComment, CommentRepo>();
builder.Services.AddScoped<ILike, LikesRepo>();
builder.Services.AddScoped<ICommentLikes, CommentLikesRepo>();
builder.Services.AddScoped<IFollow , FollowingRepo>();
builder.Services.AddScoped<IReply, RepliesRepo>();
builder.Services.AddScoped<IBlockedUser, BlockedUserRepo>();

builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequiredLength = 12;
    options.User.RequireUniqueEmail = true;

    
}).AddEntityFrameworkStores<ApplicationDBContext>()
.AddDefaultTokenProviders();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme =
    options.DefaultChallengeScheme =
    options.DefaultForbidScheme =
    options.DefaultScheme =
    options.DefaultSignInScheme =
    options.DefaultSignOutScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {

        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(
            System.Text.Encoding.UTF8.GetBytes(builder.Configuration["JWT:SignInKey"]))


    };
});

builder.Services.AddSignalR();

builder.Services.AddDirectoryBrowser();



var app = builder.Build();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}





var fileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "Images"));
var requestPath = "/Images";

// Enable displaying browser links.
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});

app.UseDirectoryBrowser(new DirectoryBrowserOptions
{
    FileProvider = fileProvider,
    RequestPath = requestPath
});

//app.UseResponseCaching();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();


app.MapHub<PostNotifications>("/Hub");

app.Run();
