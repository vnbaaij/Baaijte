using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;

namespace Baaijte.App.Features.Counter
{
    public class CounterModel : ComponentBase
    {

        [Inject] private ILocalStorageService localStorage { get; set; }

        protected int currentCount = 0;
        protected string NameFromLocalStorage { get; set; }
        protected int ItemsInLocalStorage { get; set; }
        protected string Name { get; set; }

        protected override async Task OnInitAsync()
        {
            await GetNameFromLocalStorage();
            await GetLocalStorageLength();
        }

        public void IncrementCount()
        {
            currentCount++;
        }

        public async Task SaveName()
        {
            await localStorage.SetItem("name", Name);
            await GetNameFromLocalStorage();
            await GetLocalStorageLength();

            Name = "";
        }

        public async Task GetNameFromLocalStorage()
        {
            NameFromLocalStorage = await localStorage.GetItem<string>("name");

            if (string.IsNullOrEmpty(NameFromLocalStorage))
                NameFromLocalStorage = "Nothing Saved";
        }

        public async Task RemoveName()
        {
            await localStorage.RemoveItem("name");
            await GetNameFromLocalStorage();
            await GetLocalStorageLength();
        }

        public async Task ClearLocalStorage()
        {
            Console.WriteLine("Calling Clear...");
            await localStorage.Clear();
            Console.WriteLine("Getting name from local storage...");
            await GetNameFromLocalStorage();
            Console.WriteLine("Calling Get Length...");
            await GetLocalStorageLength();
        }

        public async Task GetLocalStorageLength()
        {
            Console.WriteLine(await localStorage.Length());
            ItemsInLocalStorage = await localStorage.Length();
        }
    }
}
