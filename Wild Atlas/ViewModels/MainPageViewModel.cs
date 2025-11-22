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
            int? key = await _gbifService.GetTaxonKey("mésange charbonnière");
            Console.WriteLine($"TaxonKey: {key}");
        }
    }
}
