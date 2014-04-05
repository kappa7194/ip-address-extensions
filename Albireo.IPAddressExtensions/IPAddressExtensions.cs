namespace Albireo.IPAddressExtensions
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Net;

    public static class IPAddressExtensions
    {
        private static readonly Network[] ReservedNetworks =
        {
            new Network("0.0.0.0", 8),
            new Network("10.0.0.0", 8),
            new Network("100.64.0.0", 10),
            new Network("127.0.0.0", 8),
            new Network("169.254.0.0", 16),
            new Network("172.16.0.0", 12),
            new Network("192.0.0.0", 29),
            new Network("192.0.2.0", 24),
            new Network("192.88.99.0", 24),
            new Network("192.168.0.0", 16),
            new Network("198.18.0.0", 15),
            new Network("198.51.100.0", 24),
            new Network("203.0.113.0", 24),
            new Network("224.0.0.0", 4),
            new Network("240.0.0.0", 4),
            new Network("255.255.255.255", 32),
            new Network("::", 128),
            new Network("::1", 128),
            new Network("::ffff:0:0", 96),
            new Network("100::", 64),
            new Network("64:ff9b::", 96),
            new Network("2001::", 32),
            new Network("2001:10::", 28),
            new Network("2001:db8::", 32),
            new Network("2002::", 16),
            new Network("fc00::", 7),
            new Network("fe80::", 10),
            new Network("ff00::", 8)
        };

        public static IPAddress GetNetworkAddress(
            this IPAddress address,
            byte maskBits)
        {
            Contract.Requires<ArgumentNullException>(address != null);
            Contract.Ensures(Contract.Result<IPAddress>() != null);

            return
                IPAddressExtensions.GetNetworkAddress(
                    address,
                    IPAddressExtensions.MaskBitsToMask(maskBits));
        }

        public static IPAddress GetNetworkAddress(
            this IPAddress address,
            IPAddress mask)
        {
            Contract.Requires<ArgumentNullException>(address != null);
            Contract.Requires<ArgumentNullException>(mask != null);
            Contract.Ensures(Contract.Result<IPAddress>() != null);

            return
                TransformAddressWithMask(
                    address,
                    mask,
                    (a, m) => (byte) (a & m));
        }
        public static IPAddress GetBroadcastAddress(
            this IPAddress address,
            byte maskBits)
        {
            Contract.Requires<ArgumentNullException>(address != null);
            Contract.Ensures(Contract.Result<IPAddress>() != null);

            return
                IPAddressExtensions.GetBroadcastAddress(
                    address,
                    IPAddressExtensions.MaskBitsToMask(maskBits));
        }

        public static IPAddress GetBroadcastAddress(
            this IPAddress address,
            IPAddress mask)
        {
            Contract.Requires<ArgumentNullException>(address != null);
            Contract.Requires<ArgumentNullException>(mask != null);
            Contract.Ensures(Contract.Result<IPAddress>() != null);

            return
                TransformAddressWithMask(
                    address,
                    mask,
                    (a, m) => (byte) (a | m ^ 255));
        }

        public static bool IsInSameNetworkAs(
            this IPAddress firstAddress,
            IPAddress secondAddress,
            byte maskBits)
        {
            Contract.Requires<ArgumentNullException>(firstAddress != null);
            Contract.Requires<ArgumentNullException>(secondAddress != null);

            return
                IPAddressExtensions.IsInSameNetworkAs(
                    firstAddress,
                    secondAddress,
                    IPAddressExtensions.MaskBitsToMask(maskBits));
        }

        public static bool IsInSameNetworkAs(
            this IPAddress firstAddress,
            IPAddress secondAddress,
            IPAddress mask)
        {
            Contract.Requires<ArgumentNullException>(firstAddress != null);
            Contract.Requires<ArgumentNullException>(secondAddress != null);
            Contract.Requires<ArgumentNullException>(mask != null);

            return
                firstAddress
                .GetNetworkAddress(mask)
                .Equals(
                    secondAddress
                    .GetNetworkAddress(mask));
        }

        public static bool IsReservedAddress(this IPAddress address)
        {
            return
                ReservedNetworks
                .Any(n =>
                    n.Address.AddressFamily == address.AddressFamily
                    && address.IsInSameNetworkAs(n.Address, n.Mask));
        }

        public static IPAddress MaskBitsToMask(byte bits)
        {
            Contract.Ensures(Contract.Result<IPAddress>() != null);

            var maskLength = bits > 32 ? 16 : 4;
            var maskBytes = new byte[maskLength];

            for (int i = 0; i < maskLength; i++)
            {
                maskBytes[i] = unchecked((byte) (bits >= 8 ? 255 : 255 << (8 - bits)));
                bits = (byte) (bits > 8 ? bits - 8 : 0);
            }

            return new IPAddress(maskBytes);
        }

        private static IPAddress TransformAddressWithMask(
            IPAddress address,
            IPAddress mask,
            Func<byte, byte, byte> transformation)
        {
            Contract.Requires<ArgumentNullException>(address != null);
            Contract.Requires<ArgumentNullException>(mask != null);
            Contract.Requires<ArgumentNullException>(transformation != null);
            Contract.Ensures(Contract.Result<IPAddress>() != null);

            var addressBytes = address.GetAddressBytes();
            var maskBytes = mask.GetAddressBytes();
            var outputBytes = new byte[addressBytes.Length];

            for (int i = 0, j = outputBytes.Length; i < j; i++)
            {
                outputBytes[i] = transformation(addressBytes[i], maskBytes[i]);
            }

            return new IPAddress(outputBytes);
        }
    }
}
