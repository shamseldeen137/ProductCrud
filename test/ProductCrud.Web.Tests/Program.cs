using Microsoft.AspNetCore.Builder;
using ProductCrud;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<ProductCrudWebTestModule>();

public partial class Program
{
}
