using System;
using System.Collections.Generic;
using Com.CloudRail.SI.Types;
using MasterDetails.Model;

namespace MasterDetails.Design
{
    public class DesignDataService : IDataService
    {
        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to create design time data

            var item = new DataItem("Welcome to MVVM Light [design]");
            callback(item, null);
        }

        public void Login(VideoService videoService)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<MyVideoMetaData> Search(string searchTerm)
        {
            throw new NotImplementedException();
        }
    }
}