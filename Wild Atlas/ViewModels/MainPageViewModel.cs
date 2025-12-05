using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wild_Atlas.Services;
using Wild_Atlas.Views;

namespace Wild_Atlas.ViewModels
{
    public partial class MainPageViewModel : ObservableObject
    {
        private readonly GBIFAPIService _gbifService = new GBIFAPIService();

        public async void OnPageAppearing()
        {
            //int? count = await _gbifService.GetObservationCountAsync("renouée du japon", "POLYGON((5.8 48.8,7.8 48.8,7.8 49.6,5.8 49.6,5.8 48.8))", 1990, 2024);
            //Console.WriteLine($"Nombre d'observations : {count}");
        }

        [RelayCommand]
        private async Task OpenSpeciesCheckForm()
        {
            await Shell.Current.GoToAsync(nameof(SpeciesCheckForm));
        }
    }
}
