namespace Trisatech.Kamlinko.WebApp.Helpers;
public static class  Common
{
    public static byte[] StreamToBytes(Stream streamContent) {
        MemoryStream ms = new MemoryStream();
        
        streamContent.CopyTo(ms);

        return ms.ToArray();
    }

    public static string ToEmpty(this string content){
        return "";
    }

    public static byte[] ToBytes(this Stream streamContent) {
        MemoryStream ms = new MemoryStream();
        
        streamContent.CopyTo(ms);
        
        return ms.ToArray();
    }    
}