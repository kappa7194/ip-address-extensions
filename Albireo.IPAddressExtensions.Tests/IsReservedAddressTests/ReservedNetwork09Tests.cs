namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork09Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork09Tests() : base("192.88.98.255", "192.88.99.0", "192.88.99.255", "192.88.100.0")
        {
        }
    }
}
