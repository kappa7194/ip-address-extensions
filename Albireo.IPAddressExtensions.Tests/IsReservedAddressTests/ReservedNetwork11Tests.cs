namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork11Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork11Tests() : base("198.17.255.255", "198.18.0.0", "198.19.255.255", "198.20.0.0")
        {
        }
    }
}
