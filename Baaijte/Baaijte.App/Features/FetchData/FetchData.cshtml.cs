using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Baaijte.App.Services;
using Microsoft.AspNetCore.Components;

namespace Baaijte.App.Features.FetchData
{
    public class FetchDataModel : ComponentBase 
    {

        [Inject] private WeatherForecastService ForecastService { get; set; }

        protected WeatherForecast[] forecasts;

        protected override async Task OnInitAsync()
        {
            forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
        }
    }
}
