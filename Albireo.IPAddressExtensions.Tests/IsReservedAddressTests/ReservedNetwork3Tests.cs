namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork3Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork3Tests() : base("100.63.255.255", "100.64.0.0", "100.127.255.255", "100.128.0.0")
        {
        }
    }
}
