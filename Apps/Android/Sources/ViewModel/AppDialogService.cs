using Android.Content;
using Android.Support.V7.App;
using GalaSoft.MvvmLight.Views;
using System;
using System.Threading.Tasks;
using VideoManager.Droid.Sources.Activities.Abstracts;

namespace VideoManager.Droid.Sources.ViewModel
{
    public class AppDialogService : IDialogService
    {

        /// <summary>
        /// Displays information about an error.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonText">The text shown in the only button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task ShowError(
                                string message,
                                string title,
                                string buttonText,
                                Action afterHideCallback)
        {
            Action<bool> callback = result =>
            {
                afterHideCallback?.Invoke();
                afterHideCallback = null;
            };

            var info = CreateDialog(message, title, buttonText, null, callback);
            info.Dialog.Show();

            return info.Tcs.Task;
        }

        /// <summary>
        /// Displays information about an error.
        /// </summary>
        /// <param name="error">The exception of which the message must be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonText">The text shown in the only button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task ShowError(
                                Exception error,
                                string title,
                                string buttonText,
                                Action afterHideCallback)
        {
            Action<bool> callback = result =>
            {
                afterHideCallback?.Invoke();
                afterHideCallback = null;
            };

            var info = CreateDialog(error.Message, title, buttonText, null, callback);
            info.Dialog.Show();

            return info.Tcs.Task;
        }

        /// <summary>
        /// Displays information to the user. The dialog box will have only
        /// one button with the text "OK".
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task ShowMessage(string message, string title)
        {
            var info = CreateDialog(message, title);
            info.Dialog.Show();

            return info.Tcs.Task;
        }

        /// <summary>
        /// Displays information to the user. The dialog box will have only
        /// one button.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonText">The text shown in the only button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task ShowMessage(
                                string message,
                                string title,
                                string buttonText,
                                Action afterHideCallback)
        {
            Action<bool> callback = result =>
            {
                afterHideCallback?.Invoke();
                afterHideCallback = null;
            };

            var info = CreateDialog(message, title, buttonText, null, callback);
            info.Dialog.Show();

            return info.Tcs.Task;
        }

        /// <summary>
        /// Displays information to the user. The dialog box will have only
        /// one button.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <param name="buttonConfirmText">The text shown in the "confirm" button
        /// in the dialog box. If left null, the text "OK" will be used.</param>
        /// <param name="buttonCancelText">The text shown in the "cancel" button
        /// in the dialog box. If left null, the text "Cancel" will be used.</param>
        /// <param name="afterHideCallback">A callback that should be executed after
        /// the dialog box is closed by the user. The callback method will get a boolean
        /// parameter indicating if the "confirm" button (true) or the "cancel" button
        /// (false) was pressed by the user.</param>
        /// <returns>A Task allowing this async method to be awaited. The task will return
        /// true or false depending on the dialog result.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task<bool> ShowMessage(
                                string message,
                                string title,
                                string buttonConfirmText,
                                string buttonCancelText,
                                Action<bool> afterHideCallback)
        {
            Action<bool> callback = result =>
            {
                afterHideCallback?.Invoke(result);
                afterHideCallback = null;
            };

            var info = CreateDialog(message, title, buttonConfirmText, buttonCancelText ?? "Cancel", callback);
            info.Dialog.Show();

            return info.Tcs.Task;
        }

        /// <summary>
        /// Displays information to the user in a simple dialog box. The dialog box will have only
        /// one button with the text "OK". This method should be used for debugging purposes.
        /// </summary>
        /// <param name="message">The message to be shown to the user.</param>
        /// <param name="title">The title of the dialog box. This may be null.</param>
        /// <returns>A Task allowing this async method to be awaited.</returns>
        /// <remarks>Displaying dialogs in Android is synchronous. As such,
        /// this method will be executed synchronously even though it can be awaited
        /// for cross-platform compatibility purposes.</remarks>
        public Task ShowMessageBox(string message, string title)
        {
            return ShowMessage(message, title);
        }

        private static AlertDialogInfo CreateDialog(
                                string content,
                                string title,
                                string okText = null,
                                string cancelText = null,
                                Action<bool> afterHideCallbackWithResponse = null)
        {
            var tcs = new TaskCompletionSource<bool>();

            var builder = new AlertDialog.Builder(AbstractAppCompatActivity.CurrentActivity, Resource.Style.AppThemeDialog);
            builder.SetMessage(content);
            builder.SetTitle(title);

            AlertDialog dialog = null;
            builder.SetPositiveButton(
                                okText ?? "OK",
                                (sender, index) =>
                                {
                                    tcs.TrySetResult(true);

                                    // ReSharper disable AccessToModifiedClosure
                                    dialog?.Dismiss();
                                    dialog?.Dispose();

                                    afterHideCallbackWithResponse?.Invoke(true);
                                    // ReSharper restore AccessToModifiedClosure
                                });

            if (cancelText != null)
            {
                builder.SetNegativeButton(
                                cancelText,
                                (sender, index) =>
                                {
                                    tcs.TrySetResult(false);

                                    // ReSharper disable AccessToModifiedClosure
                                    dialog?.Dismiss();
                                    dialog?.Dispose();

                                    afterHideCallbackWithResponse?.Invoke(true);
                                    // ReSharper restore AccessToModifiedClosure
                                });
            }

            builder.SetOnDismissListener(new OnDismissListener(() =>
                                {
                                    tcs.TrySetResult(false);

                                    afterHideCallbackWithResponse?.Invoke(true);
                                }));

            dialog = builder.Create();

            return new AlertDialogInfo
            {
                Dialog = dialog,
                Tcs = tcs
            };
        }

        private struct AlertDialogInfo
        {
            public AlertDialog Dialog;
            public TaskCompletionSource<bool> Tcs;
        }

        #region OnDismissListener

        private sealed class OnDismissListener : Java.Lang.Object, IDialogInterfaceOnDismissListener
        {
            private Action action;

            public OnDismissListener(Action action)
            {
                this.action = action;
            }

            public void OnDismiss(IDialogInterface dialog)
            {
                action?.Invoke();
            }
        }

        #endregion

    }
}