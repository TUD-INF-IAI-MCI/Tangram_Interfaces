using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tud.mci.tangram.TangramLector.Extension
{
    public interface IRegistrable
    {

        /// <summary>
        /// Registers the instance to the given object.
        /// </summary>
        /// <param name="obj">The object to register.</param>
        /// <returns><c>true</c> if the initialization was successfull, othewise <c>false</c>.</returns>
        bool RegisterTo(Object obj);

    }
}
