﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ODataCQRSExample.Data.Entities;

public partial class Employee
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public decimal? Salary { get; set; }

    public string JobRole { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}