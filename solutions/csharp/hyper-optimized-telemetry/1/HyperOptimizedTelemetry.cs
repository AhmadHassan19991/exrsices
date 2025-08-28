using System;
using System.Net.Http.Headers;
public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var bytes = new byte[9];
        byte[] readingBytes;
        
        switch (reading)
        {
            case >= 4_294_967_296 and <= 9_223_372_036_854_775_807:
                bytes[0] = Convert.ToByte(0xF8);
                readingBytes = BitConverter.GetBytes(reading);
                break;
            case >= 2_147_483_648 and <= 4_294_967_295:
                bytes[0] = Convert.ToByte(0x04);
                readingBytes = BitConverter.GetBytes((uint)reading);
                break;
            case >= 65_536 and <= 2_147_483_647:
                bytes[0] = Convert.ToByte(0xFC);
                readingBytes = BitConverter.GetBytes((int)reading);
                break;
            case >= 0 and <= 65_535:
                bytes[0] = Convert.ToByte(0x02);
                readingBytes = BitConverter.GetBytes((ushort)reading);
                break;
            case >= -32_768 and <= -1:
                bytes[0] = Convert.ToByte(0xFE);
                readingBytes = BitConverter.GetBytes((short)reading);
                break;
            case >= -2_147_483_648 and <= -32_769:
                bytes[0] = Convert.ToByte(0xFC);
                readingBytes = BitConverter.GetBytes((int)reading);
                break;
            case >= -9_223_372_036_854_775_808 and <= -2_147_483_649:
                bytes[0] = Convert.ToByte(0xF8);
                readingBytes = BitConverter.GetBytes(reading);
                break;
        }
        for (var i = 1; i <= readingBytes.Length; i++)
        {
            bytes[i] = readingBytes[i-1];
        }
        return bytes;
    }
    public static long FromBuffer(byte[] buffer)
    {
        var bytes = new byte[8];
        for (var i = 1; i < buffer.Length; i++)
        {
            bytes[i - 1] = buffer[i];
        }
        return buffer[0] switch
        {
            0xF8 => BitConverter.ToInt64(bytes),
            0x04 => BitConverter.ToUInt32(bytes),
            0xFC => BitConverter.ToInt32(bytes),
            0x02 => BitConverter.ToUInt16(bytes),
            0xFE => BitConverter.ToInt16(bytes),
            _ => 0
        };
    }
}