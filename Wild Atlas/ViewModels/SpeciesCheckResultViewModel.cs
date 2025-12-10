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
        private string trend;

        [ObservableProperty]
        private Dictionary<int, int> yearObservations;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("FormData", out var value))
            {
                FormData = value as SpeciesCheckFormData;
            }
        }

        public async Task OnPageAppearing()
        {
            if (FormData == null || FormData.Departement == null)
                return;

            SpeciesCheckResultModel result = await _gbifService.GetSpeciesTrendAsync(
                commonName: "mésange charbonnière", // plus tard: espèce choisie
                gadmId: FormData.Departement.GadmId,
                startYear: FormData.StartYear,
                endYear: FormData.EndYear
            );

            Trend = result.Trend;
            YearObservations = result.YearObservations;
        }

        
    }
}
