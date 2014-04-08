namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork12Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork12Tests() : base("192.51.99.255", "198.51.100.0", "198.51.100.255", "198.51.101.0")
        {
        }
    }
}
