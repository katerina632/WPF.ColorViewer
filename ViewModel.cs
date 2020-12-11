using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ColorViewer
{
    public class ViewModel : INotifyPropertyChanged
    {
        private readonly ICollection<ColorModel> colors = new ObservableCollection<ColorModel>();
        public IEnumerable<ColorModel> Colors => colors;

        

        public event PropertyChangedEventHandler PropertyChanged;

        private ColorModel selectedColor;
        public ColorModel SelectedColor
        {
            get { return selectedColor; }
            set
            {
                if (value != selectedColor)
                {
                    selectedColor = value;
                    OnPropertyChanged();
                }

            }
        }
        public ViewModel()
        {
            SelectedColor = new ColorModel();
            
        }
        //public bool IsTheSameMethod()
        //{
        //    bool isTheSame = true;
        //    if (colors != null)
        //    {
        //        foreach (var item in colors)
        //        {
        //            if (item == SelectedColor)
        //            {
        //                isTheSame = false;
        //                break;
        //            }
        //            else
        //                isTheSame = true;
        //        }
        //    }
        //    return isTheSame;
        //}


        public void AddColor()
        {
            if (SelectedColor != null)
            {
                colors.Add((ColorModel)SelectedColor.Clone());
            }
        }


        public void RemoveSelectedColor()
        {
            if (SelectedColor != null)
            {

                colors.Remove(SelectedColor);
                SelectedColor = new ColorModel();

            }
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
