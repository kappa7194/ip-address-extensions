namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork4Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork4Tests() : base("126.255.255.255", "127.0.0.0", "127.255.255.255", "128.0.0.0")
        {
        }
    }
}
