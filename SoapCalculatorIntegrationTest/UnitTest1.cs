using System.ServiceModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoapCalculatorIntegrationTest.ServiceReference1;

namespace SoapCalculatorIntegrationTest
{
    // Start the CalculatorService before you run the test
    [TestClass]
    public class UnitTest1
    {
        private readonly CalculatorServiceClient _client = new CalculatorServiceClient();

        [TestMethod]
        public void TestAllOperations()
        {
            Assert.AreEqual(7, _client.Add(3, 4));
            Assert.AreEqual(3, _client.Subtract(4, 1));
            Assert.AreEqual(12, _client.Multiply(3, 4));
            Assert.AreEqual(2, _client.Divide(5, 2));

            int addResult, subtractResult, multiplyResult, divideResult;
            // DoItAll a void method with 6 parameters in the SOAP interface
            // Here it is an int method with only 5 parameters: the first out parameters is used as the return value!!
            addResult = _client.DoItAll(10, 3, out subtractResult, out multiplyResult, out divideResult);
            Assert.AreEqual(13, addResult);
            Assert.AreEqual(7, subtractResult);
            Assert.AreEqual(30, multiplyResult);
            Assert.AreEqual(3, divideResult);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException))]
        public void TestDivideZero()
        {
            _client.Divide(5, 0);
        }
    }
}