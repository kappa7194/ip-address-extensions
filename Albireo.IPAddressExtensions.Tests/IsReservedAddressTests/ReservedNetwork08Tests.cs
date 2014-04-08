namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork08Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork08Tests() : base("192.0.1.255", "192.0.2.0", "192.0.2.255", "192.0.3.0")
        {
        }
    }
}
