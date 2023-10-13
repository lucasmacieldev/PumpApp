using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System.Collections.ObjectModel;

namespace Pump.ViewModels
{
    public class ChartModels
    {
        public ObservableCollection<ISeries> Series { get; set; }
        public List<Axis> XAxes { get; set; }
        public List<Axis> YAxes { get; set; }

        public ChartModels()
        {
            Series = new ObservableCollection<ISeries>
{
    new ColumnSeries<int>
    {
        Values = new ObservableCollection<int> { 200, 558, 458, 249 },
    }
};

            XAxes = new List<Axis>
{
    new Axis
    {
        // Use the labels property to define named labels.
        Labels = new string[] { "Anne", "Johnny", "Zac", "Rosa" }
    }
};

            YAxes = new List<Axis>
            {
                new Axis
                {
                    // Now the Y axis we will display labels as currency
                    // LiveCharts provides some common formatters
                    // in this case we are using the currency formatter.
                    Labeler = Labelers.Currency

                    // you could also build your own currency formatter
                    // for example:
                    // Labeler = (value) => value.ToString("C")

                    // But the one that LiveCharts provides creates shorter labels when
                    // the amount is in millions or trillions

                }


            };
        }
    }
}



