using System.Linq;
using CableTechModeCommon;
using NUnit.Framework;

namespace CablesTechModeTests
{
    [TestFixture]
    public class DBRepositoryTests
    {
        private DBRepository _repository;
        private string _connectionString = "character set=utf8;user id=SYSDBA;password=masterkey;dialect=3;data source=localhost;port number=3050;initial catalog=/Users/Shared/databases/database_repository/CablesDatabases/CABLES.FDB";

        [SetUp]
        public void Setup()
        {
            _repository = new DBRepository(_connectionString);
        }

        [Test]
        public void TestFirstCableShortNameId()
        {
            var result = _repository.GetCablesShortNames().First();
            Assert.AreEqual(1, result.Id);
        }

        [Test]
        public void TestFirstCableShortNameShortName()
        {
            var result = _repository.GetCablesShortNames().First();
            Assert.AreEqual("КУНРС", result.ShortName);
        }

        [Test]
        public void TestFirstBilletConductorNotNull()
        {
            var result = _repository.GetBilletsByCableShortNameId(1).First().Conductor;
            Assert.IsNotNull(result);
        }

        [Test]
        public void TestFirstBilletConductorArea()
        {
            var result = _repository.GetBilletsByCableShortNameId(1).First().Conductor.AreaInSqrMm;
            Assert.AreEqual(0.75m, result);
        }
    }
}