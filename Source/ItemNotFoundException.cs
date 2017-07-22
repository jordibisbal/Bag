using System;
using System.Runtime.Serialization;

namespace JordiBisbal.Bag {
    /// <summary>
    /// The item was for found in the bag
    /// </summary>
    public class ItemNotFoundException : Exception {
        public ItemNotFoundException() {
        }

        public ItemNotFoundException(string message) : base(message) {
        }

        public ItemNotFoundException(string message, Exception innerException) : base(message, innerException) {
        }

        protected ItemNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }
    }
}
