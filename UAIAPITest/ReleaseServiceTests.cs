using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAIAPI.Services;

namespace UAIAPITest
{
    internal class ReleaseServiceTests
    {
        private ReleaseService releaseService;

        [SetUp]
        public void Setup()
        {
            releaseService = new ReleaseService();
        }
    }
}