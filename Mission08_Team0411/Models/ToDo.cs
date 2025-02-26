using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0411.Models;

public partial class ToDo
{
    public int TaskId { get; set; }

    public string Description { get; set; } = null!;

    public DateOnly? DueDate { get; set; }

    public int Quadrant { get; set; }

    public int CategoryId { get; set; }

    public bool Completed { get; set; }

    public virtual Category Category { get; set; } = null!;
}
