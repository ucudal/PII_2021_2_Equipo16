// Tomado de https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-preserve-references?pivots=dotnet-5-0

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// Este handler sirve pare referenciar a los handlers, usa Singleton.
    /// </summary>
    public class MyReferenceHandler : ReferenceHandler
    {
        private static MyReferenceHandler instance;
        
        /// <summary>
        /// Sirve para la instanciacion de handler de referencia.
        /// </summary>
        public static MyReferenceHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyReferenceHandler();
                }
                return instance;
            }
        }

        /// <summary>
        /// Con esto se resetea el handler de referencia.
        /// </summary>
        public MyReferenceHandler() => Reset();
        private ReferenceResolver rootedResolver;

        /// <summary>
        /// Con esto se resetea el handler de referencia.
        /// </summary>
        public override ReferenceResolver CreateResolver() => this.rootedResolver;

        /// <summary>
        /// Con esto se resetea el handler de referencia.
        /// </summary>
        public void Reset() => this.rootedResolver = new MyReferenceResolver();
    }

    class MyReferenceResolver : ReferenceResolver
    {
        private uint referenceCount;
        private readonly Dictionary<string, object> referenceIdToObjectMap = new ();
        private readonly Dictionary<object, string> objectToReferenceIdMap = new (ReferenceEqualityComparer.Instance);

        public override void AddReference(string referenceId, object value)
        {
            if (!this.referenceIdToObjectMap.TryAdd(referenceId, value))
            {
                throw new JsonException();
            }
        }

        public override string GetReference(object value, out bool alreadyExists)
        {
            if (this.objectToReferenceIdMap.TryGetValue(value, out string referenceId))
            {
                alreadyExists = true;
            }
            else
            {
                this.referenceCount++;
                referenceId = this.referenceCount.ToString();
                this.objectToReferenceIdMap.Add(value, referenceId);
                alreadyExists = false;
            }

            return referenceId;
        }

        public override object ResolveReference(string referenceId)
        {
            if (!this.referenceIdToObjectMap.TryGetValue(referenceId, out object value))
            {
                throw new JsonException();
            }

            return value;
        }
    }
}