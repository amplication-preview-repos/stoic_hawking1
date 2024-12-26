using CryptoBotClone.APIs;

namespace CryptoBotClone;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICryptocurrenciesService, CryptocurrenciesService>();
        services.AddScoped<IReferralsService, ReferralsService>();
        services.AddScoped<ITransactionsService, TransactionsService>();
        services.AddScoped<IUsersService, UsersService>();
    }
}
