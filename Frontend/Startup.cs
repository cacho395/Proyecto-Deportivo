using Persistencia;
public class Startup {
    public IConfiguration configRoot {
        get;
    }
    public Startup(IConfiguration configuration) {
        configRoot = configuration;
    }
    public void ConfigureServices(IServiceCollection services) {
        services.AddRazorPages();
        //Conectar un contexto de datos
        services.AddDbContext<Persistencia.AppContext>();

        //Inyección de dependencias por cada interfax y la clase que la implementa
        services.AddScoped<IRMunicipio,RMunicipio>();
        services.AddScoped<IRPatrocinador,RPatrocinador>();
        services.AddScoped<IRArbitro,RArbitro>();
        services.AddScoped<IREntrenador,REntrenador>();
        services.AddScoped<IREquipo,REquipo>();
        services.AddScoped<IRColegio,RColegio>();
        services.AddScoped<IRTorneo,RTorneo>();
        services.AddScoped<IREscenario,REscenario>();
        services.AddScoped<IRUnidadDeportiva,RUnidadDeportiva>();
    }
    public void Configure(WebApplication app, IWebHostEnvironment env) {
        if (!app.Environment.IsDevelopment()) {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
            
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}