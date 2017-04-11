using KsheeraSagara.Helpers;
using KsheeraSagara.Model;
using KsheeraSagara.Shared;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KsheeraSagara.ViewModels
{
    public class RateChartPageViewModel : BindableBase,INavigationAware
    {
        private IPageDialogService _pds;

        private FastCollection<RatechartModel> _fcRateChar;

        private double _fat;
        private double _rate;
        private double _ratePerFat;
        
        public FastCollection<RatechartModel> FcRateChar { get => _fcRateChar; set => SetProperty(ref _fcRateChar, value); }
        public double Fat { get => _fat; set =>SetProperty(ref _fat , value); }
        public double Rate { get => _rate; set =>SetProperty(ref _rate , value); }
        public double RatePerFat { get => _ratePerFat; set =>SetProperty(ref _ratePerFat , value); }

        public DelegateCommand GenerateRateChartCommand => new DelegateCommand(GenerateRateChartCmdAsync);


        public RateChartPageViewModel(IPageDialogService pageDialogService)
        {
            _pds = pageDialogService;

            FcRateChar = new FastCollection<RatechartModel>();
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (SharedValues._LstRateChart==null)
            {
                SharedValues._LstRateChart = GenerateChart(3.5, 22, 17);
            }

            
            //FcRateChar.NotificationOff();
            FcRateChar.AddRange(SharedValues._LstRateChart);
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            
        }


        private async void GenerateRateChartCmdAsync()
        {
            if(Fat<=0)
            {
                await _pds.DisplayAlertAsync("Info", "Invalid Fat", "Ok");
                return;
            }
            if (Rate <= 0)
            {
                await _pds.DisplayAlertAsync("Info", "Invalid Rate", "Ok");
                return;
            }
            if (RatePerFat <= 0)
            {
                await _pds.DisplayAlertAsync("Info", "Invalid Rate per Fat", "Ok");
                return;
            }

            var list = GenerateChart(Fat, Rate, RatePerFat);

            FcRateChar.Clear();
            FcRateChar.AddRange(list);

            SharedValues._LstRateChart.Clear();
            SharedValues._LstRateChart.AddRange(list);
        }


        private List<RatechartModel> GenerateChart(double fat, double rate,double ratePerPaisa)
        {
            var list = new List<RatechartModel>();
            double paisa = ratePerPaisa / 100;
            
            do
            {
                list.Add(new RatechartModel { Fat =fat , Rate = rate });
                
                fat += 0.1;
                rate += paisa;

                //Math.Round(fat, 1);
                //Math.Round(rate, 2);

            } while (fat <= 15);

            return list;
        }
    }
}
