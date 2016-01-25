using System.Collections.Generic;

namespace tud.mci.tangram.TangramLector.Classes
{
    /// <summary>
    /// Comparer for <see cref="IInteractionContextProxy"/> width respect to their adding time stamp and their zIndex.
    /// </summary>
    public class InteractionContextProxyComparer : Comparer<KeyValuePair<int, IInteractionContextProxy>>, IComparer<KeyValuePair<int, object>>
    {
        /*
         * return:
         *      > 0 |   x < y
         *      = 0 |   x == x
         *      < 0 |   x > y
         * */

        public override int Compare(KeyValuePair<int, IInteractionContextProxy> x, KeyValuePair<int, IInteractionContextProxy> y)
        {
            int zx = 0;
            int zy = 0;

            if (x.Value is IInteractionContextProxy) zx = ((IInteractionContextProxy)x.Value).ZIndex;
            if (y.Value is IInteractionContextProxy) zy = ((IInteractionContextProxy)y.Value).ZIndex;

            return zy - zx;
        }

        public int Compare(KeyValuePair<int, object> x, KeyValuePair<int, object> y)
        {

            if (x.Value is IInteractionContextProxy && y.Value is IInteractionContextProxy)
                return Compare(
                    new KeyValuePair<int, IInteractionContextProxy>(x.Key, ((IInteractionContextProxy)x.Value)),
                    new KeyValuePair<int, IInteractionContextProxy>(y.Key, ((IInteractionContextProxy)x.Value)));

            return 0;
        }
    }
}
