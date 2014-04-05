namespace Albireo.IPAddressExtensions
{
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Net;

    public static class IPAddressExtensions
    {
        public static IPAddress GetNetworkAddress(
            this IPAddress address,
            byte maskBits)
        {
            Contract.Requires<ArgumentNullException>(address != null);
            Contract.Ensures(Contract.Result<IPAddress>() != null);

            return
                IPAddressExtensions.GetNetworkAddress(
                    address,
                    IPAddressExtensions.BitsToMask(maskBits));
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
                    IPAddressExtensions.BitsToMask(maskBits));
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
                    IPAddressExtensions.BitsToMask(maskBits));
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

        public static IPAddress BitsToMask(byte bits)
        {
            Contract.Ensures(Contract.Result<IPAddress>() != null);

            var mask = string.Empty.PadRight(bits, '1').PadRight(32, '0');
            var maskValue = Convert.ToInt32(mask, 2);
            var maskBytes = BitConverter.GetBytes(maskValue).Reverse().ToArray();

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
