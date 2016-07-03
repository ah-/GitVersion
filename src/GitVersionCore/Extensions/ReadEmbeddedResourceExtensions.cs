namespace GitVersionCore.Extensions
{
    using System.IO;
    using System.Reflection;

    public static class ReadEmbeddedResourceExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="resourceName">Should include Namespace separated path to resource in assembly referenced by <typeparamref name="T"/></param>
        /// <returns></returns>
        public static string ReadAsStringFromEmbeddedResource<T>(this string resourceName)
        {
            using (var stream = resourceName.ReadFromEmbeddedResource<T>())
            {
                using (var rdr = new StreamReader(stream))
                {
                    return rdr.ReadToEnd();
                }
            }
        }

        public static Stream ReadFromEmbeddedResource<T>(this string resourceName)
        {
#if NETSTANDARD
            var assembly = typeof(T).GetTypeInfo().Assembly;
#else
            var assembly = typeof(T).Assembly;
#endif
            return assembly.GetManifestResourceStream(resourceName);
        }
    }
}
