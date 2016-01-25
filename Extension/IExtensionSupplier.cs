using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tud.mci.tangram.TangramLector.Extension
{
    /// <summary>
    /// General informations for extension
    /// </summary>
    public interface IExtensionSupplier
    {

        /// <summary>
        /// Gets the name of the extension.
        /// </summary>
        /// <value>The name.</value>
        string Name { get; }
        /// <summary>
        /// Gets the version of the extension.
        /// </summary>
        /// <value>The version.</value>
        string Version { get; }
        
    }



}
