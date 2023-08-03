using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SplineAreaSample
{
    public class GoogleSearchViewModel : INotifyPropertyChanged
    {
        private List<GoogleSearchModel> greatResignation;
        private List<GoogleSearchModel> oilPrice;
        private List<GoogleSearchModel> housingBubble;
        private List<GoogleSearchModel> valueInvesting;
        private List<GoogleSearchModel> bitCoin;
        private List<GoogleSearchModel> recession;
        private List<GoogleSearchModel> inflation;
        private List<GoogleSearchModel> uSDollar;
        private List<GoogleSearchModel> layoffs;
        private List<GoogleSearchModel> interestRate;

        public List<GoogleSearchModel> GreatResignation
        {
            get
            { return greatResignation; }
            set
            {
                greatResignation = value;
                NotifyPropertyChanged(nameof(GreatResignation));
            }
        }      
       
        public List<GoogleSearchModel> OilPrice
        {
            get { return oilPrice; }
            set
            {
                oilPrice = value; NotifyPropertyChanged(nameof(OilPrice));
            }
        }
       
        public List<GoogleSearchModel> HousingBubble
        {
            get { return housingBubble; }
            set
            {
                housingBubble = value; NotifyPropertyChanged(nameof(HousingBubble));
            }
        }
        
        public List<GoogleSearchModel> ValueInvesting
        {
            get { return valueInvesting; }
            set
            {
                valueInvesting = value; NotifyPropertyChanged(nameof(ValueInvesting));
            }
        }
       
        public List<GoogleSearchModel> BitCoin
        {
            get { return bitCoin; }
            set
            {
                bitCoin = value; NotifyPropertyChanged(nameof(BitCoin));
            }
        }
        
        public List<GoogleSearchModel> Recession
        {
            get { return recession; }
            set
            {
                recession = value; NotifyPropertyChanged(nameof(Recession));
            }
        }
        
        public List<GoogleSearchModel> Inflation
        {
            get { return inflation; }
            set
            {
                inflation = value; NotifyPropertyChanged(nameof(Inflation));
            }
        }
        
        public List<GoogleSearchModel> USDollar
        {
            get { return uSDollar; }
            set
            {
                uSDollar = value; NotifyPropertyChanged(nameof(USDollar));
            }
        }       
      
        public List<GoogleSearchModel> Layoffs
        {
            get { return layoffs; }
            set
            {
                layoffs = value; NotifyPropertyChanged(nameof(Layoffs));
            }
        }
       
        public List<GoogleSearchModel> InterestRate
        {
            get { return interestRate; }
            set
            {
                interestRate = value; NotifyPropertyChanged(nameof(InterestRate));
            }
        }
        public GoogleSearchViewModel()
        {
            GreatResignation = new List<GoogleSearchModel>(ReadCSV("SplineAreaSample.Resource.multiTimeline.csv"));  
            OilPrice = new List<GoogleSearchModel>(ReadCSV("SplineAreaSample.Resource.OilPrice.csv"));
            HousingBubble = new List<GoogleSearchModel>(ReadCSV("SplineAreaSample.Resource.HousingBubble.csv"));
            ValueInvesting = new List<GoogleSearchModel>(ReadCSV("SplineAreaSample.Resource.ValueInvsesting.csv"));
            BitCoin = new List<GoogleSearchModel>(ReadCSV("SplineAreaSample.Resource.BitCoin.csv"));
            Recession = new List<GoogleSearchModel>(ReadCSV("SplineAreaSample.Resource.Recession.csv"));
            Inflation = new List<GoogleSearchModel>(ReadCSV("SplineAreaSample.Resource.Inflation.csv"));
            USDollar = new List<GoogleSearchModel>(ReadCSV("SplineAreaSample.Resource.USDollar.csv"));
            Layoffs = new List<GoogleSearchModel>(ReadCSV("SplineAreaSample.Resource.Layoffs.csv"));
            InterestRate = new List<GoogleSearchModel>(ReadCSV("SplineAreaSample.Resource.InterestRate.csv"));
        }

        private IEnumerable<GoogleSearchModel> ReadCSV(string resourceStream)
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream inputStream = executingAssembly.GetManifestResourceStream(resourceStream);

            string? line;
            List<string> lines = new List<string>();
            using StreamReader reader = new StreamReader(inputStream);
            while ((line = reader.ReadLine()) != null)
            {
                lines.Add(line);
            }

            return lines.Select(line =>
            {
                string[] data = line.Split(',');
                DateTime date = DateTime.ParseExact(data[0], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                return new GoogleSearchModel((date), Convert.ToDouble(data[1]));
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
  
