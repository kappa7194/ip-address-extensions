namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork14Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork14Tests() : base("223.255.255.255", "224.0.0.0", "255.255.255.255", null)
        {
        }
    }
}
