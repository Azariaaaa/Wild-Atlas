using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wild_Atlas.Services;

namespace Wild_Atlas.ViewModels
{
    public class MainPageViewModel
    {
        private readonly GBIFAPIService _gbifService = new GBIFAPIService();

        public async void OnPageAppearing()
        {
            int? count = await _gbifService.GetObservationCountAsync("grand-duc d'europe", "POLYGON((5.8 48.8,7.8 48.8,7.8 49.6,5.8 49.6,5.8 48.8))", 2023, 2024);
            Console.WriteLine($"Nombre d'observations : {count}");
        }
    }
}
