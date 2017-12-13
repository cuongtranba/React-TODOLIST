using Thrift.Protocol;
using Thrift.Transport;

namespace shit.Extention
{
    public static class CVExtention
    {
        public static TCurriculum ExtractCV(this byte[] cv)
        {
            var stream = new System.IO.MemoryStream(cv);
            TProtocol tProtocol = new TBinaryProtocol(new TStreamTransport(stream, stream));
            var a = new TCurriculum();
            a.Read(tProtocol);
            return a;
        }
    }
}
