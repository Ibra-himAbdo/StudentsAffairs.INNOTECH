namespace StudentsAffairs.INNOTECH.APIs.Helpers;

public static class ApplicationService
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddAutoMapper(typeof(MappingProfiles));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }
}
