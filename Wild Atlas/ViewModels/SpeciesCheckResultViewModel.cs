using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Wild_Atlas.Models;

namespace Wild_Atlas.ViewModels
{
    public partial class SpeciesCheckResultViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private SpeciesCheckFormData formData;

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            if (query.TryGetValue("FormData", out var value))
            {
                FormData = value as SpeciesCheckFormData;
            }
        }
    }
}
