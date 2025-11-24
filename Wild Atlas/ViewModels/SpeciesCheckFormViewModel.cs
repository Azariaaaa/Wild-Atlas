using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

        [ObservableProperty]
        private string searchBarContent;

        [ObservableProperty]
        private bool hasSelection;

        public SpeciesCheckFormViewModel()
        {
            foreach (CheckItem item in Items)
            {
                item.PropertyChanged += OnItemPropertyChanged;
            }

            HasSelection = Items.Any(i => i.IsChecked);
        }

        private void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(CheckItem.IsChecked))
            {
                HasSelection = Items.Any(i => i.IsChecked);
            }
        }

        partial void OnSearchBarContentChanged(string value)
        {
            // à coder
        }
    }
}
