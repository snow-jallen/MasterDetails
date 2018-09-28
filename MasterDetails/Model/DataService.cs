using Com.CloudRail.SI;
using Com.CloudRail.SI.Interfaces;
using Com.CloudRail.SI.ServiceCode.Commands.CodeRedirect;
using Com.CloudRail.SI.Services;
using Com.CloudRail.SI.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace MasterDetails.Model
{
    public class DataService : IDataService
    {
        public DataService()
        {
        }

        public IEnumerable<Video> Search(string searchTerm)
        {
            //var results = service.SearchVideos(searchTerm, 0, 25);
            var results = new[]
            {
                new Video("1", "Bogus Video 1", "This video is awesome.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0),
                new Video("2", "Bogus Video 2", "This video is super.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0),
                new Video("3", "Bogus Video 3", "This video is amazing.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0),
                new Video("4", "Bogus Video 4", "This video is stellar.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0),
                new Video("5", "Bogus Video 5", "This video is totally sweet.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0),
                new Video("6", "Bogus Video 6", "This video is fantastic.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0)
            };
            return results;
        }
    }
}