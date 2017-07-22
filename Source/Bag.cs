using System;
using System.Collections.Generic;

namespace JordiBisbal.Bag {
    public class Bag<BagType> {

        /// <summary>
        /// Name of the bag, used when an exception is thrown
        /// </summary>
        private string bagName = "";

        /// <summary>
        /// The bag contents
        /// </summary>
        private Dictionary<string, BagType> bag = new Dictionary<string, BagType>();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="bagName">Name of the bag (used when an exception is thrown or debugging)</param>
        public Bag(string bagName = "unnamed") {
            this.bagName = bagName;
        }

        /// <summary>
        /// Checks if the bag contains a value (or a) itemName item
        /// </summary>
        /// <param name="itemName">Name of the item to check for</param>
        /// <returns>True if the item is in the bag</returns>
        public bool Has(string itemName) {
            return bag.ContainsKey(itemName);
        }

        /// <summary>
        /// Adds an item to the bag
        /// </summary>
        /// <param name="itemName">Name of the item to add</param>
        /// <param name="value"></param>
        public void Add(string itemName, BagType value) {
            if (Has(itemName)) {
                throw new ItemAlreadyExistsException("Item \"" + itemName + "\" already exists in " + GetBagNameMessage() + "");
            }

            bag.Add(itemName, value);
        }

        /// <summary>
        /// Return the bag name to be used on messages
        /// </summary>
        /// <returns></returns>
        private string GetBagNameMessage() {
            return "\"" + bagName + "\" bag";
        }

        /// <summary>
        /// Removes an item from the bag
        /// </summary>
        /// <param name="itemName">Name of item to remove</param>
        public void Remove(string itemName) {
            if (!Has(itemName)) {
                throw new ItemNotFoundException("Item \"" + itemName + "\" not found in " + GetBagNameMessage());
            }

            bag.Remove(itemName);
        }

        /// <summary>
        /// Replace an item in the bag
        /// </summary>
        /// <param name="itemName">Item name to replace</param>
        /// <param name="value">Value of the new item</param>
        public void Replace(string itemName, BagType value) {
            Remove(itemName);
            Add(itemName, value);
        }

        /// <summary>
        /// Gets a value from the bag
        /// </summary>
        /// <param name="itemName">Name of the item to retrieve</param>
        /// <param name="defaultValue">Value to be returned if the value is not in the bag</param>
        /// <returns></returns>
        public BagType Get(string itemName, BagType defaultValue) {
            if (! Has(itemName)) {
                Add(itemName, defaultValue);
            }

            BagType value = default(BagType);
            if (! bag.TryGetValue(itemName, out value)) {
                throw new ItemNotFoundException("Unable to retrieve \"" + itemName + "\" from " + GetBagNameMessage());
            }

            return value;
        }

        /// <summary>
        /// Gets a value from the bag
        /// </summary>
        /// <param name="itemName">Name of the item to retrieve</param>
        /// <returns></returns>
        public BagType Get(string itemName) {
            BagType value = default(BagType);
            if (!bag.TryGetValue(itemName, out value)) {
                throw new ItemNotFoundException("Unable to retrieve \"" + itemName + "\" from " + GetBagNameMessage() + " (not found)");
            }

            return value;
        }
    }
}
