using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Wild_Atlas.Models;
using Wild_Atlas.Services;

namespace Wild_Atlas.ViewModels
{
    public partial class SpeciesCheckResultViewModel : ObservableObject, IQueryAttributable
    {
        private readonly GBIFAPIService _gbifService = new GBIFAPIService();

        [ObservableProperty]
        private SpeciesCheckFormData formData;

        [ObservableProperty]
        private double trendValue;

        [ObservableProperty]
        private string trend;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("FormData", out var value))
            {
                FormData = value as SpeciesCheckFormData;
            }
        }

        public async Task OnPageAppearing()
        {
            //int? count = await _gbifService.GetObservationCountByGadmAsync("mésange charbonnière", FormData.Departement.GadmId, 1990, 2024);
            //Console.WriteLine($"Nombre d'observations : {count}");
        }

        
    }
}
