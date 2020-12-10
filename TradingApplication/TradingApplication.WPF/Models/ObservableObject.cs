using System.ComponentModel;

namespace TradingApplication.WPF.Models
{
   public class ObservableObject : INotifyPropertyChanged
   {
      public event PropertyChangedEventHandler PropertyChanged;

      protected void OnPropertyChanged(string propertyName)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
}
