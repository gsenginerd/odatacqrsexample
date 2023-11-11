using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODataCQRSExample.Data.Entities;
using ODataCQRSExample.Features.Employees.Commands;

namespace ODataCQRSExample.Controllers.Employees
{
    [Route("v1/employees")]
    [ApiController]
    public class EmployeeCommandController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeeCommandController(IMediator mediator) => this._mediator = mediator;

        [HttpPost()]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeCommand request) => (await _mediator.Send(request) as Employee)!;
        
    }
}
