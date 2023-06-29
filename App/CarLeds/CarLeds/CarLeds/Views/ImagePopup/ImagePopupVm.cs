using CarLeds.CarLeds.General.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarLeds.CarLeds.Views.ImagePopup;

internal class ImagePopupVm : ViewModelBase
{
    private string _source;

    public string Source
    {
        get => _source;
        set
        {
            _source = value;
            OnPropertyChanged();
        }
    }

    private string _text;

    public string Text
    {
        get => _text;
        set
        {
            _text = value;
            OnPropertyChanged();
        }
    }
}
