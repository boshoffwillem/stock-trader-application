using TradingApplication.Domain.Models;
using TradingApplication.Domain.Services;

namespace TradingApplication.WPF.ViewModels
{
   public class MajorIndexListingViewModel : BaseViewModel
   {
      private readonly IMajorIndexService majorServiceIndex;

      private MajorIndex dowJones;
      public MajorIndex DowJones
      {
         get
         {
            return dowJones;
         }
         set
         {
            dowJones = value;
            OnPropertyChanged(nameof(DowJones));
         }
      }

      private MajorIndex sp500;
      public MajorIndex SP500
      {
         get
         {
            return sp500;
         }
         set
         {
            sp500 = value;
            OnPropertyChanged(nameof(SP500));
         }
      }

      private MajorIndex nasdaq;
      public MajorIndex Nasdaq
      {
         get
         {
            return nasdaq;
         }
         set
         {
            nasdaq = value;
            OnPropertyChanged(nameof(Nasdaq));
         }
      }

      public MajorIndexListingViewModel(IMajorIndexService majorServiceIndex)
      {
         this.majorServiceIndex = majorServiceIndex;
      }

      /// <summary>
      /// Factory method.
      /// </summary>
      /// <returns></returns>
      public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorServiceIndex)
      {
         var viewModel = new MajorIndexListingViewModel(majorServiceIndex);
         viewModel.LoadMajorIndices();
         return viewModel;
      }

      private void LoadMajorIndices()
      {
         majorServiceIndex.GetMajorIndices().ContinueWith(task =>
         {
            if (task.Exception == null)
            {
               var indices = task.Result;

               foreach (var index in indices)
               {
                  switch (index.Type)
                  {
                     case MajorIndexType.Unknown:
                        break;
                     case MajorIndexType.DowJones:
                        DowJones = index;
                        break;
                     case MajorIndexType.Nasdaq:
                        Nasdaq = index;
                        break;
                     case MajorIndexType.SP500:
                        SP500 = index;
                        break;
                     default:
                        break;
                  }
               }
            }
         });
      }
   }
}