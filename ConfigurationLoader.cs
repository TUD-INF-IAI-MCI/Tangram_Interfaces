using System;

namespace tud.mci.tangram.TangramLector
{
    /// <summary>
    /// Helper Class for loading values from the app configuration
    /// </summary>
    public static class ConfigurationLoader
    {
        /// <summary>
        /// Gets the global APP configuration (app.config) content.
        /// </summary>
        /// <returns></returns>
        public static System.Collections.Specialized.NameValueCollection GetGlobalConfiguration()
        {
            System.Collections.Specialized.NameValueCollection config = System.Configuration.ConfigurationManager.AppSettings;
            return config;
        }

        /// <summary>
        /// Checks if th configuration contains a certain key.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <param name="config">The configuration to search in.</param>
        /// <returns><c>true</c> if the key was found; otherwise, <c>false</c>.</returns>
        public static bool ConfigContainsKey(string key, System.Collections.Specialized.NameValueCollection config = null)
        {
            if (config == null) config = GetGlobalConfiguration();
            if (config != null && config.Count > 0)
            {
                return config[key] != null;
            }
            return false;
        }

        /// <summary>
        /// Gets the value from configuration.
        /// </summary>
        /// <param name="obj">The object.</param>
        /// <param name="key">The key.</param>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        public static bool GetValueFromConfiguration(ref object obj, string key, System.Collections.Specialized.NameValueCollection config = null)
        {
            if (obj != null)
            {
                string value = GetValueFromConfig(key, config);
                try
                {
                    obj = Convert.ChangeType(value, obj.GetType());
                    return true;
                }
                catch (InvalidCastException) { }
            }
            return false;
        }

        /// <summary>
        /// Gets the value of the certain key from the app configuration.
        /// </summary>
        /// <typeparam name="T">The object type/class of the return value.</typeparam>
        /// <param name="key">The key to search for.</param>
        /// <param name="config">The configuration to search in. if this is <c>null</c>, the global app.config file is used to search in.</param>
        /// <returns>
        /// the string value of the special key if set; otherwise null or the empty string.
        /// </returns>
        public static T GetValueFromConfig<T>(string key, System.Collections.Specialized.NameValueCollection config = null)
        {

            string value = GetValueFromConfig(key, config);
            if (!String.IsNullOrEmpty(value))
            {
                try
                {
                    return (T)Convert.ChangeType(value, typeof(T));
                }
                catch (InvalidCastException e) { }
            }

            return default(T);
        }

        /// <summary>
        /// Gets the value of the certain key from the app configuration.
        /// </summary>
        /// <param name="key">The key to search for.</param>
        /// <param name="config">The configuration to search in. if this is <c>null</c>, the global app.config file is used to search in.</param>
        /// <returns>the string value of the special key if set; otherwise null or the empty string.</returns>
        public static String GetValueFromConfig(string key, System.Collections.Specialized.NameValueCollection config = null)
        {
            if (!String.IsNullOrWhiteSpace(key))
            {
                if (config == null) config = GetGlobalConfiguration();
                if (config != null && config.Count > 0)
                {
                    return config[key];
                }
            }
            return null;
        }
    }
}
