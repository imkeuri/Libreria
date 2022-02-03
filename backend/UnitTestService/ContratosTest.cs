using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestService
{
    public enum TestTypes
    {
        None,
        UnitTesting,
        IntegrationTesting,
        FlyByTheSeatOfYourPantsTesting
    }

    [TestFixture]
    public class ContratosTest
    {

        [Test]
        public void CanConvertEnumIntoMultipleWords()
        {
            
        }
    }
}
