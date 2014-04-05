namespace Albireo.IPAddressExtensions.Tests.IsReservedAddressTests
{
    using System.Net;

    using Xunit;

    public abstract class ReservedNetworkTestsBase
    {
        private readonly IPAddress lowerBoundMinusOne;
        private readonly IPAddress lowerBound;
        private readonly IPAddress upperBound;
        private readonly IPAddress upperBoundPlusOne;

        public ReservedNetworkTestsBase(
            string lowerBoundMinusOne,
            string lowerBound,
            string upperBound,
            string upperBoundPlusOne)
        {
            this.lowerBoundMinusOne = lowerBoundMinusOne != null ? IPAddress.Parse(lowerBoundMinusOne) : null;
            this.lowerBound = IPAddress.Parse(lowerBound);
            this.upperBound = IPAddress.Parse(upperBound);
            this.upperBoundPlusOne = upperBoundPlusOne != null ? IPAddress.Parse(upperBoundPlusOne) : null;
        }

        [Fact]
        public void LowerBoundMinusOneTest()
        {
            this.Check(this.lowerBoundMinusOne, false);
        }

        [Fact]
        public void LowerBoundTest()
        {
            this.Check(this.lowerBound, true);
        }

        [Fact]
        public void UpperBoundTest()
        {
            this.Check(this.upperBound, true);
        }

        [Fact]
        public void UpperBoundPlusOneTest()
        {
            this.Check(this.upperBoundPlusOne, false);
        }

        private void Check(IPAddress address, bool shouldBeReserved)
        {
            if (address == null)
            {
                return;
            }

            Assert.Equal(shouldBeReserved, IPAddressExtensions.IsReservedAddress(address));
        }
    }
}
