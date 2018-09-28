using MasterDetails.Model;
using MasterDetails.ViewModel;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class MasterDetailsTests
    {
        [Test]
        public void SearchCommandDisabledWithoutSearchTerm()
        {
            var mockService = new Mock<IDataService>();
            mockService.Setup(m => m.Search(It.IsAny<String>()))
                .Returns(()=>null);
            
            var vm = new MainViewModel(mockService.Object);
            vm.SearchTerm = null;
            Assert.False(vm.Search.CanExecute(this));
        }
        [Test]
        public void SearchCommandEnabledWithSearchTerm()
        {
            var mockService = new Mock<IDataService>();

            var vm = new MainViewModel(mockService.Object);
            vm.SearchTerm = "bogus";
            Assert.True(vm.Search.CanExecute(this));
        }
    }
}
