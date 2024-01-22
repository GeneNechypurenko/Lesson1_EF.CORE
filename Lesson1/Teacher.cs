using System;
using System.Collections.Generic;

namespace Lesson1;

public partial class Teacher
{
    public int Id { get; set; }

    public DateOnly EmploymentDate { get; set; }

    public string Name { get; set; } = null!;

    public decimal Premium { get; set; }

    public decimal Salary { get; set; }

    public string Surname { get; set; } = null!;
}
