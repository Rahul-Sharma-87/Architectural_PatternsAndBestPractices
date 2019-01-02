using System;
using System.Collections;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Dymanic
{
    public class HostRequest {
        public string HostName { get; }

        public HostRequest(string hostName ) {
            HostName = hostName;
        }

        public IPHostEntry HostEntry { get; set; }

        public SocketException ExceptionObject { get; set; }
    }

    public class AsyncCallbackWithState {
        private static int requestCounter;
        private static ArrayList hostData = new ArrayList();

        private static void UpdateUserInterface(int itemsPending)
        {
            Console.WriteLine("UI update: " + itemsPending);
        }

        public static void Main1() {
            AsyncCallback asyncCallback = new AsyncCallback(ProcessDNSInformation);
            string host;
            do {
                Console.WriteLine("Enter computer name");
                host = Console.ReadLine();
                if (host.Length > 0) {
                    var request = new HostRequest(host);
                    hostData.Add(new HostRequest(host));
                    Interlocked.Increment(ref requestCounter);
                    Dns.BeginGetHostAddresses(host, asyncCallback, request);
                }
            } while (host.Length > 0);

            while (requestCounter > 0) {
                UpdateUserInterface(requestCounter);
            }

            foreach (HostRequest request in hostData) {
                if (request.ExceptionObject != null) {
                    Console.WriteLine("Error occured: " + request.ExceptionObject.Message);
                } else {
                    string[] aliases = request.HostEntry.Aliases;
                    IPAddress[] addresses = request.HostEntry.AddressList;
                    Console.WriteLine("Total Aliases found : "+ aliases.Length);
                    Console.WriteLine("Total Addresses found : "+ addresses.Length);
                }
            }
        }

        private static void ProcessDNSInformation(IAsyncResult iAsyncResult) {
            HostRequest request = (HostRequest)iAsyncResult.AsyncState;
            try {
                IPHostEntry hostEntry = Dns.EndGetHostEntry(iAsyncResult);
                request.HostEntry = hostEntry;
            } catch (SocketException e) {
                request.ExceptionObject = e;
            }
            finally {
                Interlocked.Decrement(ref requestCounter);
            }
        }

    }
}
