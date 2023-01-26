using System.Reflection;

namespace OnlineAccountingServer.Presentation
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(Assembly).Assembly;
        /*
         WebApi katmanının içerisindeki Controller ve program.cs dosyalarını bu katman içerisinde kullanmak istediğimiz için .
         Başka katmandaki dosyaları taşımak istiyorsak; taşıdığımız katmanın assembly'sini vermek gerekiyor.

         
         */
    }
}
