using System.Threading.Tasks;
using TradingApplication.Domain.Models;
using TradingApplication.Domain.Services;

namespace TradingApplication.WPF.ViewModels
{
   public class MajorIndexViewModel : BaseViewModel
   {
      private readonly IMajorIndexService majorServiceIndex;
      
      public MajorIndex DowJones { get; set; }

      public MajorIndex SP500 { get; set; }

      public MajorIndex Nasdaq { get; set; }

      public MajorIndexViewModel(IMajorIndexService majorServiceIndex)
      {
         this.majorServiceIndex = majorServiceIndex;
      }

      /// <summary>
      /// Factory method.
      /// </summary>
      /// <returns></returns>
      public static MajorIndexViewModel LoadMajorIndexViewModel(IMajorIndexService majorServiceIndex)
      {
         var viewModel = new MajorIndexViewModel(majorServiceIndex);
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