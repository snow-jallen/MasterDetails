using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Com.CloudRail.SI.Interfaces;
using Com.CloudRail.SI.Types;

namespace MasterDetails.Model
{
    public interface IDataService
    {
        void GetData(Action<DataItem, Exception> callback);
        void Login(VideoService videoService);
        IEnumerable<MyVideoMetaData> Search(string searchTerm);
    }
}
