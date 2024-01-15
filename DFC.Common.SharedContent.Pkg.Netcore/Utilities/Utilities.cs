namespace DFC.Common.SharedContent.Pkg.Netcore.IUtilities
{
    public class Utilities : Interfaces.IUtilities
    {
        public string ConvertNodeId(string nodeId)
        {
            const string Appended = "<<contentapiprefix>>/";

            return nodeId.Substring(Appended.Length, nodeId.Length - Appended.Length);
        }
    }
}
