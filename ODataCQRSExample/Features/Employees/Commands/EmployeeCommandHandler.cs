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
        var employee = new Employee
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Salary = request.Salary,
            JobRole = request.JobRole
        };

        _oDataCqrsExampleContext.Add(employee);

        await _oDataCqrsExampleContext.SaveChangesAsync();

        return employee;
    }
}