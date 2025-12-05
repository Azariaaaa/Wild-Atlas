using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Wild_Atlas.Models;
using Wild_Atlas.Views;

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

        public ObservableCollection<SearchResult> searchResults;

        [ObservableProperty]
        private string searchBarContent;

        [ObservableProperty]
        private bool hasSelection;

        [ObservableProperty]
        private ObservableCollection<Departement> departements;

        [ObservableProperty]
        private Departement selectedDepartement;

        [ObservableProperty]
        private int startYear = 2015;

        [ObservableProperty]
        private int endYear = 2025;

        public SpeciesCheckFormViewModel()
        {
            foreach (CheckItem item in Items)
            {
                item.PropertyChanged += OnItemPropertyChanged;
            }

            HasSelection = Items.Any(i => i.IsChecked);
            LoadDepartements();
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

        private async void LoadDepartements()
        {
            Stream stream = await FileSystem.OpenAppPackageFileAsync("departements.json");
            StreamReader reader = new StreamReader(stream);

            string json = await reader.ReadToEndAsync();

            JsonSerializerOptions options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            ObservableCollection<Departement> list = JsonSerializer.Deserialize<ObservableCollection<Departement>>(json, options);

            Departements = list;
        }

        [RelayCommand]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416", Justification = "Shell navigation is cross-platform in .NET MAUI")]
        private async Task Submit()
        {
            SpeciesCheckFormData data = new SpeciesCheckFormData
            {
                Departement = SelectedDepartement,
                StartYear = StartYear,
                EndYear = EndYear
            };

            await Shell.Current.GoToAsync(nameof(SpeciesCheckResult), new Dictionary<string, object>
            {
                { "FormData", data }
            });
        }
    }
}

