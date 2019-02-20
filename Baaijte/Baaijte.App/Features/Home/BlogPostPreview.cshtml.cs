using Baaijte.Shared;
using Microsoft.AspNetCore.Components;

namespace Baaijte.App.Features.Home
{
    public class BlogPostPreviewModel : ComponentBase
    {
        [Parameter] protected BlogPost blogPost { get; set; }
    }
}