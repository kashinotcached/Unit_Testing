﻿using NetworkUtility.DNS;
using System.Net.NetworkInformation;

namespace NetworkUtility.Ping
{
    public class NetworkService
    {
        private readonly IDNS _dNS;

        public NetworkService(IDNS dNS)
        {
            _dNS = dNS;
        }

        public string SendPing()
        {
            var dnsSuccess = _dNS.SendDNS();

            if(dnsSuccess)
                return "Success: Ping Sent!";

            return "Failed: Ping not Sent!";
        }

        public int PingTimeout(int a, int b)
        {
            return a + b;
        }

        public DateTime LastPingDate()
        {
            return DateTime.Now;
        }

        public PingOptions PingOptions()
        {
            return new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };
        }

        public IEnumerable<PingOptions> MostRecentPings()
        {
            IEnumerable<PingOptions> pingOptions = new List<PingOptions>()
            {
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl= 1
                },
                new PingOptions()
                {
                    DontFragment = true,
                    Ttl= 2
                }
            };
            
            return pingOptions;
        }
    }
}