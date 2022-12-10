// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Module4HT4;
using Module4HT4.Config;
using Module4HT4.Data;
using Module4HT4.Repositories.Abstractions;
using Module4HT4.Repositories;
using Module4HT4.Services.Abstractions;
using Module4HT4.Services;

IConfiguration config = new ConfigurationBuilder().AddJsonFile("config.json").Build();
var connectionString = config.GetConnectionString("DefaultConnection");

var serviceCollection = new ServiceCollection();

serviceCollection.AddOptions<LoggerOption>().Bind(config.GetSection("Logger"));

serviceCollection
    .AddDbContextFactory<ApplicationDbContext>(opts => opts.UseNpgsql(connectionString))
    .AddLogging(cfg => cfg.AddConsole())
    .AddTransient<ICategoryService, CategoryService>()
    .AddTransient<ICustomerService, CustomerService>()
    .AddTransient<IOrderService, OrderService>()
    .AddTransient<IOrderDetailsService, OrderDetailsService>()
    .AddTransient<IPaymentService, PaymentService>()
    .AddTransient<IProductService, ProductService>()
    .AddTransient<IShipperService, ShipperService>()
    .AddTransient<ISupplierService, SupplierService>()
    .AddTransient<ICategoryRepository, CategoryRepository>()
    .AddTransient<ICustomerRepository, CustomerRepository>()
    .AddTransient<IOrderRepository, OrderRepository>()
    .AddTransient<IOrderDetailsRepository, OrderDetailsRepository>()
    .AddTransient<IPaymentRepository, PaymentRepository>()
    .AddTransient<IProductRepository, ProductRepository>()
    .AddTransient<IShipperRepository, ShipperRepository>()
    .AddTransient<ISupplierRepository, SupplierRepository>()
    .AddTransient<App>();

var app = serviceCollection.BuildServiceProvider().GetService<App>();
await app!.Start();