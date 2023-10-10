using BookStore.Core.Contexts.EmployeeContext.Entities;
using BookStore.Core.Contexts.EmployeeContext.ValueObjects;
using BookStore.Core.Contexts.SharedContext.ValueObjects;

namespace BookStore.Core.Tests.Utils.EmployeeContext;

public class EmployeeUtils
{
    public static Employee CreateEmployee(string firstName, string lastName, string email, DateTime birthDate, string? password = null)
    {
        Name employeeName = new(firstName, lastName);
        Email employeeEmail = new(email);
        Password employeePassword = new(password);

        var employee = new Employee(employeeName, birthDate, employeeEmail, employeePassword);

        return employee;
    }
}
