namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork2Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork2Tests() : base("9.255.255.255", "10.0.0.0", "10.255.255.255", "11.0.0.0")
        {
        }
    }
}
