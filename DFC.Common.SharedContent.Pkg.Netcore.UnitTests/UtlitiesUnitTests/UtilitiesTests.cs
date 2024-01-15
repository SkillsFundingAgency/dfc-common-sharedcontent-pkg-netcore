using DFC.Common.SharedContent.Pkg.Netcore.IUtilities;

namespace DFC.Common.SharedContent.Pkg.Netcore.UnitTests
{
    public class UtilitiesTests
    {
        [Theory]
        [InlineData("<<contentapiprefix>>/pagebanner/13480ce6-0055-467e-af29-6095326fcbad", "pagebanner/13480ce6-0055-467e-af29-6095326fcbad")]
        [InlineData("<<contentapiprefix>>/sharedcontent/bfee0a93-cd0d-40eb-a72d-7bb0c0cced3e", "sharedcontent/bfee0a93-cd0d-40eb-a72d-7bb0c0cced3e")]
        [InlineData("<<contentapiprefix>>/taxonomy/9a9e10ca-7102-49bc-a792-74d131bf58fb", "taxonomy/9a9e10ca-7102-49bc-a792-74d131bf58fb")]
        [InlineData("<<contentapiprefix>>/banner/0383b77a-a928-4df7-8bf2-009998029e13", "banner/0383b77a-a928-4df7-8bf2-009998029e13")]
        public void EnsureNodeIdIsCorrectlyConverted(string nodeId, string expectedResult)
        {
            var utilities = new Utilities();
            var result = utilities.ConvertNodeId(nodeId);

            Assert.Equal(expectedResult, result);
        }
    }
}
