using MediatR;
using ODataCQRSExample.Data.Entities;

namespace ODataCQRSExample.Features.Employees.Commands;

public class EmployeeCommand : IRequest<Employee>
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public decimal? Salary { get; set; }

    public string? JobRole { get; set; }

    public EmployeeAddress? EmployeeAddress { get; set; }
}