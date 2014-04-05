namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork1Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork1Tests() : base(null, "0.0.0.0", "0.255.255.255", "1.0.0.0")
        {
        }
    }
}
