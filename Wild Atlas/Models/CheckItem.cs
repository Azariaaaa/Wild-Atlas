using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Wild_Atlas.Models
{
    public partial class CheckItem : ObservableObject
    {
        [ObservableProperty]
        private string label;

        [ObservableProperty]
        private bool isChecked;
    }
}
