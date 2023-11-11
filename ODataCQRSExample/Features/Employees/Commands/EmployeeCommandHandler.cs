using MediatR;
using ODataCQRSExample.Data;
using ODataCQRSExample.Data.Entities;

namespace ODataCQRSExample.Features.Employees.Commands;

public class EmployeeCommandHandler : IRequestHandler<EmployeeCommand, Employee>
{
    private readonly ODataCqrsExampleContext _oDataCqrsExampleContext;

    public EmployeeCommandHandler(ODataCqrsExampleContext oDataCqrsExampleContext) => _oDataCqrsExampleContext = oDataCqrsExampleContext;

    // Implements and encapsulates the real business logic
    public async Task<Employee> Handle(EmployeeCommand request, CancellationToken cancellationToken)
    {
        var address = new Address { City = request.Address!.City, State = request.Address.State, Country = request.Address.Country };
        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Salary = request.Salary,
            JobRole = request.JobRole
            // Address = address
        };

        // _oDataCqrsExampleContext.Addresses.Add(address);
        _oDataCqrsExampleContext.Employees.Add(employee);

        await _oDataCqrsExampleContext.SaveChangesAsync(cancellationToken);

        return employee;
    }
}