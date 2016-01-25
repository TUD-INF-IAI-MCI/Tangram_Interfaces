using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tud.mci.tangram.TangramLector.Extension
{
    /// <summary>
    /// Generic interface for object initialization
    /// </summary>
    public interface IInitialObjectReceiver
    {
        /// <summary>
        /// Initializes the objects.
        /// </summary>
        /// <param name="objs">The objects used for initializing.</param>
        /// <returns><c>true</c> if initializing was successful, otherwise <c>false</c>.</returns>
        bool InitializeObjects(params object[] objs);

    }
}
