using System;
using System.Collections.Generic;

namespace Action_Filter;

public partial class Autorization
{
    public int Id { get; set; }

    public int AuthId { get; set; }

    public string? Controller { get; set; }

    public string? Action { get; set; }

    public virtual Authentication Auth { get; set; } = null!;
}
