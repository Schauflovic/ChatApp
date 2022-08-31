using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatClient.Net.IO
{
    /*//Klasse ermöglicht uns Daten an einen MemoryStream anzuhängen, 
     * den man verwenden kann, um die Bytes zu erhalten, 
     * die an den Server gesendet werden sollen, 
     * denn der Datenaustausch zwischen Client und Server passiert 
     * nur mit Bytes
     */
    class PacketBuilder 
    {
        MemoryStream _ms;
        public PacketBuilder()
        {
            _ms = new MemoryStream();
        }

        /*
         * 3 Funktionen:
         * 1. ermöglicht schreiben von OPCode in das Paket
         */

        public void WriteOpCode(byte opcode)
        {
            _ms.WriteByte(opcode);
        }

        public void WriteMessage(string msg)
        {
            var msgLength = msg.Length;
            _ms.Write(BitConverter.GetBytes(msgLength));
            _ms.Write(Encoding.ASCII.GetBytes(msg));
        }

        public byte[] GetPacketBytes()
        {
            return _ms.ToArray();
        }
    }
}
