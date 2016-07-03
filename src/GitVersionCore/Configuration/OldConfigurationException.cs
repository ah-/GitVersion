namespace GitVersion
{
    using System;
#if !NETSTANDARD
    using System.Runtime.Serialization;
#endif

#if !NETSTANDARD
    [Serializable]
#endif
    public class OldConfigurationException : Exception
    {
        public OldConfigurationException(string message) : base(message)
        {
        }

#if !NETSTANDARD
        protected OldConfigurationException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
#endif
    }
}