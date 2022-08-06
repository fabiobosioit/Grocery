namespace Grocery.UI.Services;

public interface IConfirmService
{
    Task Init();
    Task ShowConfirm(string confirmId);
    Task HideConfirm(string confirmId);
}