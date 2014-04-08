namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork10Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork10Tests() : base("192.167.255.255", "192.168.0.0", "192.168.255.255", "192.169.0.0")
        {
        }
    }
}
