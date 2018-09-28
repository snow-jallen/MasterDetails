using Com.CloudRail.SI.Interfaces;
using Com.CloudRail.SI.Types;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using MasterDetails.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
            ExportPath = "videos.json";
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
                var results = _dataService.Search(SearchTerm);
                VideoList = new BindingList<Video>(results.ToList());
            },
            () => (SearchTerm ?? String.Empty) != String.Empty));
        
        private Video selectedVideo = null;
        public Video SelectedVideo
        {
            get { return selectedVideo; }
            set
            {
                Set(nameof(SelectedVideo), ref selectedVideo, value, true);
            }
        }

        private BindingList<Video> videoList;
        public BindingList<Video> VideoList { get { return videoList; }
            set
            {
                Set(nameof(VideoList), ref videoList, value, true);
            }
        }

        private string exportPath;
        public string ExportPath
        {
            get { return exportPath; }
            set { Set(ref exportPath, value); }
        }
        
        private RelayCommand save;
        public RelayCommand Save => save ?? (save = new RelayCommand(
            () =>
            {
                var contents = JsonConvert.SerializeObject(VideoList, Formatting.Indented);
                File.WriteAllText(ExportPath, contents);
            }));
    }    

}