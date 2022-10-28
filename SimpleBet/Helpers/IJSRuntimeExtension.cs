using Microsoft.JSInterop;

namespace SimpleBet.Helpers
{
    public static class IJSRuntimeExtension
    {
        public static async ValueTask ToastrSuccess(this IJSRuntime JSRuntime, string message, string header = null)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "success", message, header);
        }
        public static async ValueTask ToastrInfo(this IJSRuntime JSRuntime, string message, string header = null)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "info", message, header);
        }
        public static async ValueTask ToastrWarning(this IJSRuntime JSRuntime, string message, string header = null)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "warning", message, header);
        }

        public static async ValueTask ToastrError(this IJSRuntime JSRuntime, string message, string header = null)
        {
            await JSRuntime.InvokeVoidAsync("ShowToastr", "error", message, header);
        }
    }
}
