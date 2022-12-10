using Module4HT4.Models;

namespace Module4HT4.Services.Abstractions;

public interface IShipperService
{
    Task<int> CreateShipper(string name, string phone);
}
