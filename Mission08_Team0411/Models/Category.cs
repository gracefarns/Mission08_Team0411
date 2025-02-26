using System;
using System.Collections.Generic;

namespace Mission08_Team0411.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string Description { get; set; } = null!;

    public virtual ICollection<ToDo> Tasks { get; set; } = new List<ToDo>();
}
