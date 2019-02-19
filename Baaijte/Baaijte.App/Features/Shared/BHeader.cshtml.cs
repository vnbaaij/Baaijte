using System;
using Microsoft.AspNetCore.Components;

namespace Baaijte.App.Shared
{
    public class BHeaderModel : ComponentBase
    {
        [Parameter] protected string Heading { get; set; }
        [Parameter] protected string SubHeading { get; set; }
        [Parameter] protected string Author { get; set; }
        [Parameter] protected DateTime PostedDate { get; set; }
    }
}