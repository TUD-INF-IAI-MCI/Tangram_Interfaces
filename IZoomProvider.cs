using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tud.mci.tangram.TangramLector
{
    /// <summary>
    /// Interface for Instances who are able to zoom
    /// </summary>
    public interface IZoomProvider
    {
        /// <summary>
        /// get the current zoom level
        /// </summary>
        /// <returns></returns>
        double GetZoomLevel();

        /// <summary>
        /// set the current zoom level
        /// </summary>
        /// <param name="zoom"></param>
        /// <returns></returns>
        double SetZoomLevel(double zoom);

        /// <summary>
        /// get the maximum allows zoom level
        /// </summary>
        /// <returns></returns>
        double GetMaxZoomLevel();
    }
}
