using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tud.mci.tangram.TangramLector.Extension
{
    public interface IInitializable
    {

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        /// <returns><c>true</c> if the initialization was successful, otherwise <c>false</c>.</returns>
        bool Initialize();

    }
}
