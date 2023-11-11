using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataCQRSExample.Data;
using ODataCQRSExample.Data.Entities;

namespace ODataCQRSExample.Controllers.Employees;

[Route("v1/employees")]
public class EmployeeQueryController : ODataController
{
    private readonly ODataCqrsExampleContext _oDataCqrsExampleContext;

    public EmployeeQueryController(ODataCqrsExampleContext oDataCqrsExampleContext)
    {
        _oDataCqrsExampleContext = oDataCqrsExampleContext;
    }

    [HttpGet(Name = "Get")]
    [EnableQuery]
    public IActionResult Get() => Ok(_oDataCqrsExampleContext.Employees.AsQueryable());

    [HttpGet("{id}", Name = "GetById")]
    [EnableQuery]
    public async Task<ActionResult<Employee>> GetById(int id) => Ok(await _oDataCqrsExampleContext.Employees.FindAsync(id));
}