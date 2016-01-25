using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tud.mci.tangram.TangramLector
{
    /// <summary>
    /// Interface for a connection to Open Office Draw application
    /// </summary>
    public interface IOoDrawConnection
    {
        /// <summary>
        /// Determines if a connection is established or not.
        /// </summary>
        /// <returns><c>true</c> if a connection to Open Office was established.</returns>
        bool ISConnected();

        /// <summary>
        /// Get the active draw document
        /// </summary>
        /// <returns>the active document</returns>
        Object GetActiveDrawDocument();

        /// <summary>
        /// Get the current selection in a draw application
        /// </summary>
        /// <returns>the selected item</returns>
        Object GetCurrentDrawSelection();
  
    }
}
