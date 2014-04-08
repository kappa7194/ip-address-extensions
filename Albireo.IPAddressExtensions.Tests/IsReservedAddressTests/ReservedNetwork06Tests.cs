namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork06Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork06Tests() : base("172.15.255.255", "172.16.0.0", "172.31.255.255", "172.32.0.0")
        {
        }
    }
}
