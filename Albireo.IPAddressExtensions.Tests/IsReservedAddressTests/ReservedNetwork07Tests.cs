namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork07Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork07Tests() : base("191.255.255.255", "192.0.0.0", "192.0.0.7", "192.0.0.8")
        {
        }
    }
}
