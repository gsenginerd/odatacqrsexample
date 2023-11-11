namespace ODataCQRSExample.Features.Employees.Commands;

public class AddressCommand
{
    public string? HouseNumber { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }
}