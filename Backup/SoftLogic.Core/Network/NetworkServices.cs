using System;
using System.Net;
using System.Runtime.InteropServices;
using System.DirectoryServices;

namespace SoftLogik.Networking
{
    public class NetworkServices
    {

        [DllImport("iphlpapi.dll", ExactSpelling = true)]
        public extern static int SendARP(int DestIP, int SrcIP, out byte[] pMacAddr, ref int PhyAddrLen);

        public static string GetMACAddress(string HostIPAddress)
        {
            byte[] macBytes = new byte[6];
            int len = macBytes.Length;
            string mac = string.Empty;

            try
            {

                char[] addressChars = HostIPAddress.ToCharArray();
                byte[] addressBytes = new byte[addressChars.Length];
                int i = 0;
                foreach (char c in addressChars)
                {
                    addressBytes[i] = (byte)c;
                    i++;
                }
                int iAddr = BitConverter.ToInt32((new IPAddress(addressBytes)).GetAddressBytes(), 0);

                // This Function Used to Get The Physical Address
                int r = SendARP(iAddr, 0, out macBytes, ref len);
                mac = BitConverter.ToString(macBytes, 0, 6);
            }
            catch (Exception ex)
            {
            }

            return mac;
        }

    }
}