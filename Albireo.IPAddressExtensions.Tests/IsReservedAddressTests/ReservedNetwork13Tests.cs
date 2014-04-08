namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork13Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork13Tests() : base("203.0.112.255", "203.0.113.0", "203.0.113.255", "203.0.114.0")
        {
        }
    }
}
