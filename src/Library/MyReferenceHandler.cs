// Tomado de https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-preserve-references?pivots=dotnet-5-0

using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ClassLibrary
{
    /// <summary>
    /// 
    /// </summary>
    public class MyReferenceHandler : ReferenceHandler
    {
        private static MyReferenceHandler instance;
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
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
        /// 
        /// </summary>
        /// <returns></returns>
        public MyReferenceHandler() => Reset();
        private ReferenceResolver _rootedResolver;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override ReferenceResolver CreateResolver() => _rootedResolver;

        /// <summary>
        /// 
        /// </summary>
        public void Reset() => _rootedResolver = new MyReferenceResolver();
    }

    class MyReferenceResolver : ReferenceResolver
    {
        private uint _referenceCount;
        private readonly Dictionary<string, object> _referenceIdToObjectMap = new ();
        private readonly Dictionary<object, string> _objectToReferenceIdMap = new (ReferenceEqualityComparer.Instance);

        public override void AddReference(string referenceId, object value)
        {
            if (!_referenceIdToObjectMap.TryAdd(referenceId, value))
            {
                throw new JsonException();
            }
        }

        public override string GetReference(object value, out bool alreadyExists)
        {
            if (this._objectToReferenceIdMap.TryGetValue(value, out string referenceId))
            {
                alreadyExists = true;
            }
            else
            {
                this._referenceCount++;
                referenceId = this._referenceCount.ToString();
                this._objectToReferenceIdMap.Add(value, referenceId);
                alreadyExists = false;
            }

            return referenceId;
        }

        public override object ResolveReference(string referenceId)
        {
            if (!_referenceIdToObjectMap.TryGetValue(referenceId, out object value))
            {
                throw new JsonException();
            }

            return value;
        }
    }
}