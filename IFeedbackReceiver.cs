using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tud.mci.tangram.TangramLector
{
    /// <summary>
    /// Allows an implementing instance to receive information for a feedback to sent
    /// </summary>
    public interface IFeedbackReceiver
    {
        /// <summary>
        /// Receives a textual feedback.
        /// </summary>
        /// <param name="text">The feedback text</param>
        void ReceiveTextualFeedback(String text);

        /// <summary>
        /// Receives a textual notification - means a short term feedback only for notifying something.
        /// </summary>
        /// <param name="text">The feedback text</param>
        void ReceiveTextualNotification(String text);


        /// <summary>
        /// Receives an auditory feedback - e.g. text to output as text to speech.
        /// </summary>
        /// <param name="audio">The text that should be interpretetd for an auditory feedback.</param>
        void ReceiveAuditoryFeedback(String audio);

    }
}
