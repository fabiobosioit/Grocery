using Microsoft.JSInterop;

namespace Grocery.UI.Services;

public class ConfirmService:IAsyncDisposable, IConfirmService
{
    private readonly IJSRuntime _jsRuntime;
    private IJSObjectReference? _moduleJs=null;

    public ConfirmService(IJSRuntime jsRuntime)
    {
        _jsRuntime = jsRuntime;
    }

    public async Task Init()
    {
        _moduleJs = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./_content/Grocery.UI/confirm.js");

    }
    public async Task ShowConfirm(string confirmId)
    {
        if (_moduleJs is not null)
        {
            await _moduleJs.InvokeVoidAsync("showConfirm", confirmId);
        }
    }

    public async Task HideConfirm(string confirmId)
    {
      
        if (_moduleJs is not null)
        {
            await _moduleJs.InvokeVoidAsync("hideConfirm", confirmId);
        }
    }

    public async ValueTask DisposeAsync()
    {
        if (_moduleJs is not null)
        {
            await _moduleJs.DisposeAsync();
        }
    }
}