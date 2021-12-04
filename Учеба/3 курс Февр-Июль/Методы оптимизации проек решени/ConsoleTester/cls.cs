using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleTester
{
    delegate void PacketHandlerDelegate(ref byte[] packet, int size);
    class SocksProxy
    {
        public PacketHandlerDelegate ServerPacketHandler;
        public PacketHandlerDelegate ClientPacketHandler;
        public int Port;

        public SocksProxy(int port)
        {
            this.Port = port;
        }

        public void Listen()
        {
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Any, Port));
            listener.Listen(100);
            listener.BeginAccept(listener_Accept, listener);
        }

        public void listener_Accept(IAsyncResult ar)
        {
            byte[] buffer = new byte[2048];
            Socket listener = (Socket)ar.AsyncState;
            listener.BeginAccept(listener_Accept, listener);

            Socket _in = listener.EndAccept(ar);
            Socket _out = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            _in.Receive(buffer, 0, buffer.Length, SocketFlags.None);

            if (buffer[0] == 5 && buffer[2] == 0)
            {
                buffer[1] = 0;
                _in.Send(buffer, 0, 2, SocketFlags.None);
                _in.Receive(buffer, 0, buffer.Length, SocketFlags.None);

                IPEndPoint remoteEndPoint = GetAddress(ref buffer);
                switch (buffer[1])
                {
                    case 1:
                        _out.Connect(remoteEndPoint);
                        Console.WriteLine("Socket connected to " + remoteEndPoint);
                        break;

                    case 2:
                        _out.Bind(remoteEndPoint);
                        Console.WriteLine("Socket binded to " + remoteEndPoint);
                        break;
                }

                buffer[1] = 0;
                _in.Send(buffer, 0, 10, SocketFlags.None);


                NetworkState state = new NetworkState(_in, _out, buffer);
                _out.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, out_Receive, state);
                _in.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, in_Receive, state);
            }
        }

        private IPEndPoint GetAddress(ref byte[] buf)
        {
            switch (buf[3])
            {
                case 1:
                    string ip = buf[4] + "." + buf[5] + "." + buf[6] + "." + buf[7];
                    int port = buf[8] * 256 + buf[9];
                    return new IPEndPoint(IPAddress.Parse(ip), port);

                case 3:
                    byte len = buf[8];
                    string host = Encoding.ASCII.GetString(buf, 9, len);
                    return HostResolve(host);

                default:
                    return new IPEndPoint(0, 0);
            }
        }

        private IPEndPoint HostResolve(string hostname)
        {
            IPHostEntry host = Dns.GetHostEntry(hostname);
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return new IPEndPoint(ip, 80);
                }
            }
            return new IPEndPoint(0, 0);
        }

        private void in_Receive(IAsyncResult ar)
        {
            NetworkState state = (NetworkState)ar.AsyncState;
            int received = state.In.EndReceive(ar);

            if (received > 0)
            {
                Console.WriteLine("{0} -> {1}", state.In.RemoteEndPoint, state.Out.RemoteEndPoint);
                //Console.WriteLine(Utils.HexDump(state.Buffer, received));
                if (ClientPacketHandler != null)
                    ClientPacketHandler(ref state.Buffer, received);
                state.Out.Send(state.Buffer, 0, received, SocketFlags.None);
                state.In.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, in_Receive,
                    new NetworkState(state.In, state.Out, state.Buffer));
            }
            else
            {
                state.In.Shutdown(SocketShutdown.Both);
                Console.WriteLine("{0} отключен", state.In.RemoteEndPoint);
            }
        }

        private void out_Receive(IAsyncResult ar)
        {
            NetworkState state = (NetworkState)ar.AsyncState;
            int received = state.Out.EndReceive(ar);

            if (received > 0)
            {
                Console.WriteLine("{0} -> {1}", state.Out.RemoteEndPoint, state.In.RemoteEndPoint);
                if (ServerPacketHandler != null)
                    ServerPacketHandler(ref state.Buffer, received);
                state.In.Send(state.Buffer, 0, received, SocketFlags.None);
                state.Out.BeginReceive(state.Buffer, 0, state.Buffer.Length, SocketFlags.None, out_Receive,
                    new NetworkState(state.In, state.Out, state.Buffer));
            }
            else
            {
                state.Out.Shutdown(SocketShutdown.Both);
                Console.WriteLine("{0} отключен", state.Out.RemoteEndPoint);
            }
        }
        private class NetworkState
        {
            public byte[] Buffer;
            public Socket In;
            public Socket Out;
            public NetworkState(Socket sin, Socket sout, byte[] buff)
            {
                this.Buffer = buff;
                this.In = sin;
                this.Out = sout;
            }
        }
    }
}
