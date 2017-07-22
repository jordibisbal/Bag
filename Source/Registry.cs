namespace JordiBisbal.Bag {
    /// <summary>
    /// Registry singleton
    /// </summary>
    public class Registry {
        /// <summary>
        /// Registry bag
        /// </summary>
        private static Bag<object> registry = null;
        
        /// <summary>
        /// Returns the registry instance
        /// </summary>
        /// <returns></returns>
        public static Bag<object> GetInstance() {
            if (registry == null) {
                registry = new Bag<object>("Registry");
            }

            return registry;
        }

        /// <summary>
        /// Return a value in the registry
        /// </summary>
        /// <param name="item">Item name</param>
        /// <param name="defaultValue">Default value</param>
        public static object Get(string item, object defaultValue = null) {
            return GetInstance().Get(item, defaultValue);
        }

        /// <summary>
        /// Sets a value in the registry
        /// </summary>
        /// <param name="item">Item name</param>
        /// <param name="value">New value</param>
        public static void Add(string item, object value) {
            GetInstance().Add(item, value);
        }

        /// <summary>
        /// Replaces a value in the registry
        /// </summary>
        /// <param name="item">Item name</param>
        /// <param name="value">New value</param>
        public static void Replace(string item, object value) {
            GetInstance().Replace(item, value);
        }

        /// <summary>
        /// Removes a value from the registry
        /// </summary>
        /// <param name="item">Item name</param>
        public static void Remove(string item) {
            GetInstance().Remove(item);
        }

        /// <summary>
        /// Sets the registry instance, this method is intended primarelly for testing pourpouses, can also be uses to persist some of the game status
        /// </summary>
        public static void setRegistry(Bag<object> newRegistry) {
            registry = newRegistry;
        }
    }
}
