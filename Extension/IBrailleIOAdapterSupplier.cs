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

        /// <summary>
        /// Determines whether the specified adapter can be used as a monitor for another adapter.
        /// </summary>
        /// <param name="monitoringAdapter">The adapter type that can be monitored.</param>
        /// <returns>
        /// 	<c>true</c> if the specified adapter is a monitor; otherwise, <c>false</c>.
        /// </returns>
        bool IsMonitor(out List<String> monitoringAdapter);

        /// <summary>
        /// Monitors the adapter.
        /// </summary>
        /// <param name="adapter">The adapter to monitor.</param>
        /// <returns>
        /// <c>true</c> if the specified adapter can be monitored; otherwise, <c>false</c>.
        /// </returns>
        bool StartMonitoringAdapter(IBrailleIOAdapter adapter);

        /// <summary>
        /// Stops the monitoring of the adapter.
        /// </summary>
        /// <param name="adapter">The adapter to monitor.</param>
        /// <returns>
        /// <c>true</c> if the specified adapter monitoring was stopped; otherwise, <c>false</c>.
        /// </returns>
        bool StopMonitoringAdapter(IBrailleIOAdapter adapter);

    }
}
