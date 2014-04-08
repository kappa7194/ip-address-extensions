namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    public class ReservedNetwork05Tests : ReservedNetworkTestsBase
    {
        public ReservedNetwork05Tests() : base("169.253.255.255", "169.254.0.0", "169.254.255.255", "169.255.0.0")
        {
        }
    }
}
