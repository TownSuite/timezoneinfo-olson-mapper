using MbUnit.Framework;

namespace McNearney.TimeZones
{
    [TestFixture]
    class OlsonMapperTests
    {
        private OlsonMapper _mapper;

        [FixtureSetUp]
        public void FixtureSetUp()
        {
            const string path = @"..\..\Data\WindowsZones.xml";
            _mapper = new OlsonMapper(path);
        }

        [Test]
        [Row("Pacific Standard Time", "America/Los_Angeles")]
        [Row("SE Asia Standard Time", "Asia/Bangkok")]
        public void Find_Returns_Correct_Result(string timeZoneId, string olsonId)
        {
            var result = _mapper.Find(timeZoneId);
            Assert.AreEqual(olsonId, result);
        }

        [Test]
        [ExpectedArgumentException]
        public void Find_Throws_Exception_On_Invalid_TimeZoneId()
        {
            _mapper.Find("Unknown TimeZoneId");
        }
    }
}
