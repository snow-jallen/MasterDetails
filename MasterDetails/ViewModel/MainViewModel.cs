using Com.CloudRail.SI.Interfaces;
using Com.CloudRail.SI.Types;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MasterDetails.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MasterDetails.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// The <see cref="WelcomeTitle" /> property's name.
        /// </summary>
        public const string WelcomeTitlePropertyName = "WelcomeTitle";

        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get
            {
                return _welcomeTitle;
            }
            set
            {
                Set(ref _welcomeTitle, value);
            }
        }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }

        private string searchTerm = null;
        public string SearchTerm
        {
            get { return searchTerm; }
            set { Set(nameof(SearchTerm), ref searchTerm, value, true); }
        }

        private RelayCommand search;
        public RelayCommand Search => search ?? (search = new RelayCommand(
            () =>
            {
                _dataService.Login(VideoService.YouTube);
                var results = _dataService.Search(SearchTerm);
                VideoList = new BindingList<MyVideoMetaData>(results.ToList());
            },
            () => (SearchTerm ?? String.Empty) != String.Empty));
        
        private MyVideoMetaData selectedVideo = null;
        public MyVideoMetaData SelectedVideo
        {
            get { return selectedVideo; }
            set
            {
                Set(nameof(SelectedVideo), ref selectedVideo, value, true);
            }
        }

        private BindingList<MyVideoMetaData> videoList;
        public BindingList<MyVideoMetaData> VideoList { get { return videoList; }
            set
            {
                Set(nameof(VideoList), ref videoList, value, true);
            }
        }
    }

    public class DemoViewModel : INotifyPropertyChanged
    {

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion

    }
}