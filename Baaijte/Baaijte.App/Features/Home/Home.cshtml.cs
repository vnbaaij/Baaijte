using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Baaijte.Shared;
using Microsoft.AspNetCore.Components;

namespace Baaijte.App.Features.Home
{
    public class HomeModel : ComponentBase
    {
        [Inject] private HttpClient _httpClient { get; set; }

        protected List<BlogPost> BlogPosts { get; set; } = new List<BlogPost>();

        protected override async Task OnInitAsync()
        {
            await LoadBlogPosts();
        }

        private async Task LoadBlogPosts()
        {
            var blogPostsResponse = await _httpClient.GetJsonAsync<List<BlogPost>>(Urls.BlogPosts);
            BlogPosts = blogPostsResponse.OrderByDescending(p => p.Posted).ToList();
        }
    }
}