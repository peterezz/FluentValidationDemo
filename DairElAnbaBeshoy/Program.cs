using DairElAnbaBeshoy.AppLogic.Services;
using DairElAnbaBeshoy.Core.Models;
using DairElAnbaBeshoy.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder( args );

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString( "DefaultConnection" );
builder.Services.AddDbContext<ApplicationDbContext>( options =>
    options.UseSqlServer( connectionString ) );



builder.Services.AddIdentity<ApplicationUser , IdentityRole>( options => options.SignIn.RequireConfirmedAccount = true )
    .AddEntityFrameworkStores<ApplicationDbContext>( )
    .AddDefaultTokenProviders( )
    .AddDefaultUI( );
builder.Services.AddRazorPages( );
builder.Services.RegisterAutoMapper( );
await builder.Services.AddAdminUserAsync( );


var app = builder.Build( );

// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment( ) )
{
    app.UseMigrationsEndPoint( );
}
else
{
    app.UseExceptionHandler( "/Error" );
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts( );
}

app.UseHttpsRedirection( );
app.UseStaticFiles( );

app.UseRouting( );

app.UseAuthentication( );
app.UseAuthorization( );

app.MapRazorPages( );

app.UseHttpsRedirection( );
app.UseStaticFiles( );

app.UseRouting( );

app.UseAuthorization( );

app.MapControllerRoute(
    name: "default" ,
    pattern: "{controller=Home}/{action=Index}/{id?}" );


app.Run( );
