#region References

using Bogus;

#endregion

namespace BogusDataGenerator.Data;

public class DataGenerator
{
    private readonly BogusDataExampleContext _context;

    public DataGenerator(BogusDataExampleContext context)
    {
        _context = context;
    }

    public async Task Clear()
    {
        _context.Customers.RemoveRange(_context.Customers);
        await _context.SaveChangesAsync();
    }

    public async Task Generate()
    {
        var fakeCustomer = new Faker<Customer>()
            .RuleFor(x => x.FirstName, y => y.Name.FirstName())
            .RuleFor(x => x.LastName, y => y.Name.LastName())
            .RuleFor(x => x.City, y => y.Address.City())
            .RuleFor(x => x.State, y => y.Address.State())
            .RuleFor(x => x.ZipCode, y => y.Address.ZipCode())
            .RuleFor(x => x.Phone, y => y.Phone.PhoneNumber())
            .RuleFor(x => x.JobTitle, y => y.Name.JobTitle())
            .RuleFor(x => x.CreatedBy, "BogusDataGenerator.Api");

        var fakeCustomerList = fakeCustomer.Generate(1000);

        await _context.Customers.AddRangeAsync(fakeCustomerList);
        await _context.SaveChangesAsync();
    }
}