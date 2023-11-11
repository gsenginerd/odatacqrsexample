namespace ODataCQRSExample.Features.Employees.Commands;

public class EmployeeAddressCommand
{
    public string? HouseNumber { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }
}