﻿using System;
using System.Collections.Generic;

namespace ODataCQRSExample.Data.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public decimal? Salary { get; set; }

    public string? JobRole { get; set; }

    public virtual EmployeeAddress? Address { get; set; }
}
