using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using Wild_Atlas.Models;

namespace Wild_Atlas.ViewModels
{
    public partial class SpeciesCheckFormViewModel : ObservableObject
    {
        public ObservableCollection<CheckItem> Items { get; } =
        new()
        {
            new CheckItem { Label = "Animal" },
            new CheckItem { Label = "Oiseau" },
            new CheckItem { Label = "Insecte" },
        };
    }
}
