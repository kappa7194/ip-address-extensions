namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork01Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork01Tests() : base(null, "0.0.0.0", "0.255.255.255", "1.0.0.0")
        {
        }
    }
}
