
using System.Drawing;
using System.Windows.Forms;
using CarLib.Common.Properties;

namespace CarLib.Common
{
    /// <summary>
    /// Specifies constants defining which buttons to display 
    /// on a <see cref="MessageBoxEx"/>.
    /// </summary>
    public enum MessageBoxButtonTypes
    {
        /// <summary>
        /// The message box contains an OK button.
        /// </summary>
        Ok = 0,

        /// <summary>
        /// The message box contains Abort and Retry buttons.
        /// </summary>
        RetryAbort,

        /// <summary>
        /// The message box contains Abort and Ignore buttons.
        /// </summary>
        IgnoreAbort,

        /// <summary>
        /// The message box contains Abort, Retry, and Ignore buttons.
        /// </summary>
        RetryIgnoreAbort
    }

    /// <summary>
    /// Specifies constants defining which information to display.
    /// </summary>
    public enum MessageBoxIconType
    {
        /// <summary>
        /// The message box contain no symbols.
        /// </summary>
        None = 0,

        /// <summary>
        /// The message box contains a symbol consisting of an exclamation 
        /// point in a triangle with a yellow background.
        /// </summary>
        Warning = 16,

        /// <summary>
        /// The message box contains a symbol consisting of a lowercase 
        /// letter i in a circle.
        /// </summary>
        Information = 32
    }

    /// <summary>
    /// Represents a customized message box that can contain text, caption, 
    /// buttons, icons, etc.
    /// </summary>
    public partial class MessageBoxEx : Form
    {
        private bool IgnoreAllTheSameProblems { get; set; }

        private bool IsAltF4Pressed { get; set; }

        public MessageBoxEx()
        {
            InitializeComponent();
            // hide the close button
            ControlBox = false;

            KeyPreview = true;
            KeyDown += MessageBoxEx_KeyDown;
        }

        /// <summary>
        /// Displays the <see cref="MessageBoxEx"/> with the specified owner, 
        /// text, caption, buttons and icon.
        /// </summary>
        /// <param name="owner">n object that serves as a dialog box's top-level window and owner.</param>
        /// <param name="text">A string value that specifies the text to display in the message box.</param>
        /// <param name="caption">A string value that specifies the message box's caption.</param>
        /// <param name="buttons">A value that specifies which buttons to display in the message box.</param>
        /// <param name="icon">One of the <see cref="MessageBoxIconType"/> values that specifies which icon to display in the message box.</param>
        /// <param name="ignoreAllSameProblems">If the same problems will be ignored.</param>
        /// <returns>One of the <see cref="DialogResult"/> values.</returns>
        public static DialogResult Show(
            IWin32Window owner,
            string text,
            string caption,
            MessageBoxButtonTypes buttons,
            MessageBoxIconType icon,
            out bool ignoreAllSameProblems)
        {
            var messageBox = new MessageBoxEx();

            messageBox.SetCaption(caption);
            messageBox.SetMessage(text);
            messageBox.ToggleButtonVisibilities(buttons);
            messageBox.SetIcon(icon);

            var result = messageBox.ShowDialog(owner);
            ignoreAllSameProblems = messageBox.IgnoreAllTheSameProblems;
            return result;
        }

        private void SetCaption(string caption)
        {
            Text = caption;
        }

        private void SetMessage(string message)
        {
            labelMessage.Text = message;
        }

        private void ToggleButtonVisibilities(MessageBoxButtonTypes buttons)
        {
            switch (buttons)
            {
                case MessageBoxButtonTypes.IgnoreAbort:
                    btnIgnore.Visible = true;
                    btnIgnoreAll.Visible = true;
                    btnAbort.Visible = true;
                    btnRetry.Visible = false;
                    break;

                case MessageBoxButtonTypes.RetryAbort:
                    btnRetry.Visible = true;
                    btnAbort.Visible = true;
                    btnIgnore.Visible = false;
                    btnIgnoreAll.Visible = false;
                    break;

                case MessageBoxButtonTypes.RetryIgnoreAbort:
                    btnRetry.Visible = true;
                    btnIgnore.Visible = true;
                    btnIgnoreAll.Visible = true;
                    btnAbort.Visible = true;
                    break;
            }
        }

        private void SetIcon(MessageBoxIconType icon)
        {
            switch (icon)
            {
                case MessageBoxIconType.Information:
                    pictureBox.Image = SystemIcons.Information.ToBitmap();
                    break;

                case MessageBoxIconType.Warning:
                    pictureBox.Image = SystemIcons.Warning.ToBitmap();
                    break;
            }
        }

        private void btnIgnoreAll_Click(object sender, System.EventArgs e)
        {
            IgnoreAllTheSameProblems = true;
        }

        private void btnAbort_Click(object sender, System.EventArgs e)
        {
            var result = MessageBox.Show(
                this,
                Resources.MsgBox_Msg_AbortConfirmationText,
                Resources.MsgBox_Title_AbortConfirmation,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Asterisk);

            if (result == DialogResult.Yes)
            {
                DialogResult = DialogResult.Abort;
            }
        }

        private void MessageBoxEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt && e.KeyCode == Keys.F4)
            {
                IsAltF4Pressed = true;
            }
        }

        private void MessageBoxEx_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsAltF4Pressed)
            {
                if (e.CloseReason == CloseReason.UserClosing)
                {
                    e.Cancel = true;
                }

                IsAltF4Pressed = false;
            }
        }
    }
}
