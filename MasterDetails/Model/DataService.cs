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
    public enum VideoService
    {
        Twitch,
        Vimeo,
        YouTube
    }

    public class DataService : IDataService
    {
        IVideo service;
        private readonly Twitch twitch;
        private readonly Vimeo vimeo;
        private readonly YouTube youtube;

        public DataService()
        {
            CloudRail.AppKey = "GetFromSomewhereSecret";

            twitch = new Twitch(
                new LocalReceiver(8082),
                "[Twitch Client Identifier]",
                "[Twitch Client Secret]",
                "http://localhost:8082/auth",
                "someState"
            );

            vimeo = new Vimeo(
                new LocalReceiver(8082),
                "[Vimeo Client Identifier]",
                "[Vimeo Client Secret]",
                "http://localhost:8082/auth",
                "someState"
            );

            youtube = new YouTube(
                new LocalReceiver(8082),
                "GetFromSomewhereSecret.apps.googleusercontent.com",
                "GetFromSomewhereSecret",
                "http://localhost:8082/auth",
                "someState"
            );
        }

        public void Login(VideoService videoService)
        {
            service = null;
            switch (videoService)
            {
                case VideoService.Twitch:
                    service = twitch;
                    break;
                case VideoService.Vimeo:
                    service = vimeo;
                    break;
                case VideoService.YouTube:
                    service = youtube;
                    break;
                default:
                    break;
            }
            //service?.Login();
        }

        public void GetData(Action<DataItem, Exception> callback)
        {
            // Use this to connect to the actual data service

            var item = new DataItem("Welcome to MVVM Light");
            callback(item, null);
        }

        public IEnumerable<MyVideoMetaData> Search(string searchTerm)
        {
            //var results = service.SearchVideos(searchTerm, 0, 25);
            var results = new[]
            {
                new MyVideoMetaData("1", "Bogus Video 1", "This video is awesome.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0),
                new MyVideoMetaData("2", "Bogus Video 2", "This video is super.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0),
                new MyVideoMetaData("3", "Bogus Video 3", "This video is amazing.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0),
                new MyVideoMetaData("4", "Bogus Video 4", "This video is stellar.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0),
                new MyVideoMetaData("5", "Bogus Video 5", "This video is totally sweet.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0),
                new MyVideoMetaData("6", "Bogus Video 6", "This video is fantastic.", 0, null, 5, "https://www.youtube.com/watch?v=-Mg6HA8qyzc", null, 0, 0, 0)
            };
            return results;
        }
    }
}