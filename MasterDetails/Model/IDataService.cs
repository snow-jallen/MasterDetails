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
        IEnumerable<Video> Search(string searchTerm);
    }
}
