using System;
using System.Collections.Generic;

namespace ConsoleApp2;

public partial class EmailTemplate
{
    public int Id { get; set; }

    public string? EmailTemplateName { get; set; }

    public string? EmailSubject { get; set; }

    public string? EmailBody { get; set; }
}
