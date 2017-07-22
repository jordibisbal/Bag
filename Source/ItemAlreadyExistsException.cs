using System;

namespace JordiBisbal.Bag {
    /// <summary>
    /// Whena an item is add to a bag but the bag already has an item with that name
    /// </summary>
    public class ItemAlreadyExistsException : Exception {
        public ItemAlreadyExistsException(string message) : base(message) {
        }
    }
}
