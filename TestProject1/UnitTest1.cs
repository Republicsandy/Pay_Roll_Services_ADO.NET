using NUnit.Framework;
using Pay_Roll_Services_ADO;
using System;

namespace TestProject1
{
    public class Tests
    {
        EmployeeRepository repo;
        [SetUp]
        public void Setup()
        {
            repo = new EmployeeRepository();
        }

        public void TestMethodForUpdateUsingQuery()
        {
            EmployeeModel model = new EmployeeModel();
            model.Name = "Sandeep singh";
            model.EmployeeId = 3;
            model.BasicPay = 300000;
            string actual = repo.UpdateEmployee(model);
            string expected = "success";
            Assert.AreEqual(expected, actual);
        }
        //Test case for updation using StoredProcedure
        [Test]
        public void TestMethodForUpdateUsingProcedure()
        {
            EmployeeModel model = new EmployeeModel();
            model.Name = "Sandeep singh";
            model.EmployeeId = 3;
            model.BasicPay = 300000;
            string actual = repo.UpdateEmployeeUsingStoredProcedure(model);
            string expected = "Updated";
            Assert.AreEqual(expected, actual);
        }
        //TC for valid result for retrieved data
        [Test]
        public void TestMethodForSelectDataBasedOnName()
        {
            EmployeeModel model = new EmployeeModel();
            model.Name = "Sandeep";
            EmployeeModel actual = repo.RetrieveDataBasedOnName(model);
            Assert.AreEqual(model.Name, actual.Name);
        }
        //Tc for invalid name
        [Test]
        public void TestMethodForSelectDataForNullRecords()
        {
            try
            {
                EmployeeModel model = new EmployeeModel();
                model.Name = "Priy";
                repo.RetrieveDataBasedOnName(model);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", ex.Message);
            }
        }
    }
}