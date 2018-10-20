using Caliburn.Micro;
using DoubleButton.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleButton.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        private readonly IEventAggregator _eventAggregator;


        public MainViewModel()
        {

            _eventAggregator = IoC.Get<IEventAggregator>();

        }

        protected override void OnInitialize()
        {
            base.OnInitialize();



        }
        protected override void OnActivate()/* OK */
        {
            base.OnActivate();

            _eventAggregator.Subscribe(this);


            Data = CreateData();
        }
        protected override void OnDeactivate(bool close)
        {
            base.OnDeactivate(close);
            _eventAggregator.Unsubscribe(this);
        }
        protected override void OnViewLoaded(object view)
        {
            base.OnViewLoaded(view);




        }



        private ObservableCollection<UserModel> _data = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> Data
        {
            get { return _data; }
            set
            {
                this.Set(ref _data, value);
            }
        }
        private ObservableCollection<UserModel> CreateData()
        {
            var d = new ObservableCollection<UserModel>();
            for (int i = 0; i < 20; i++)
            {
                d.Add(new UserModel(i, $"name({i})"));
            }
            return d;
        }


    }
}
