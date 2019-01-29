using BrailleIO.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tud.mci.tangram.TangramLector.Extension
{
    public interface IBrailleIOAdapterSupplier
    {
        /// <summary>
        /// Gets the Adapter.
        /// </summary>
        /// <returns></returns>
        IBrailleIOAdapter GetAdapter(BrailleIO.Interface.IBrailleIOAdapterManager manager);

        /// <summary>
        /// Initializes the adapter.
        /// </summary>
        /// <returns><c>true</c>if the initialization was successful, otherwise <c>false</c></returns>
        bool InitializeAdapter();

        /// <summary>
        /// Determines whether this adapter should be used as main adapter.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [is main adapter]; otherwise, <c>false</c>.
        /// </returns>
        bool IsMainAdapter();

    }
}
