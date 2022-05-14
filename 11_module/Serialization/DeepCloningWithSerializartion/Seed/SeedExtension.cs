﻿using DeepCloningWithSerializartion.Models;
using System;
using System.Collections.Generic;

namespace DeepCloningWithSerializartion.Seed
{
    public static class SeedExtension
    {
        public static List<Employee> CreateDefaultDataForEmployee()
        {
            var employees = new List<Employee>{new Employee(Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8)),
                                                new Employee(Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8))};

            return employees;
        }

        public static Department CreateDefaultDataForDepartment()
        {
            var department = new Department();
            department.DepartmentName = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 8);
            department.Employees = CreateDefaultDataForEmployee();

            return department;
        }
    }
}
