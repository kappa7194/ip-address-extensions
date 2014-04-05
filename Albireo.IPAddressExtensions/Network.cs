namespace Albireo.IPAddressExtensions
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Net;

    internal class Network
    {
        public Network(string address, byte maskBits)
        {
            Contract.Requires<ArgumentNullException>(address != null);

            this.Address = IPAddress.Parse(address);
            this.Mask = IPAddressExtensions.MaskBitsToMask(maskBits);
        }

        public IPAddress Address { get; set; }

        public IPAddress Mask { get; set; }
    }
}
