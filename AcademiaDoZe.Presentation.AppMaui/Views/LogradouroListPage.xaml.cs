using AcademiaDoZe.Application.DTOs;
using AcademiaDoZe.Presentation.AppMaui.ViewModels;
namespace AcademiaDoZe.Presentation.AppMaui.Views;
public partial class LogradouroListPage : ContentPage
{
    public LogradouroListPage(LogradouroListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (BindingContext is LogradouroListViewModel viewModel)
        {
            await viewModel.LoadLogradourosCommand.ExecuteAsync(null);
        }
    }
    private async void OnEditButtonClicked(object sender, EventArgs e)
    {
        try
        {
            // [ALTERA��O SUTIL] Usa Pattern Matching mais conciso para extrair o DTO do BindingContext do bot�o
            if (sender is Button { BindingContext: LogradouroDTO logradouro } && BindingContext is LogradouroListViewModel viewModel)
            {
                await viewModel.EditLogradouroCommand.ExecuteAsync(logradouro);
            }
        }
        catch (Exception ex) { await DisplayAlert("Erro", $"Erro ao editar logradouro: {ex.Message}", "OK"); }
    }
    private async void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        try
        {
            // [ALTERA��O SUTIL] Usa Pattern Matching mais conciso para extrair o DTO do BindingContext do bot�o
            if (sender is Button { BindingContext: LogradouroDTO logradouro } && BindingContext is LogradouroListViewModel viewModel)
            {
                // Inclui uma confirma��o de exclus�o, que � uma boa pr�tica de UX
                bool confirmed = await DisplayAlert("Confirma��o", $"Tem certeza que deseja excluir o logradouro {logradouro.Cep}?", "Sim", "N�o");
                if (confirmed)
                {
                    await viewModel.DeleteLogradouroCommand.ExecuteAsync(logradouro);
                }
            }
        }
        catch (Exception ex) { await DisplayAlert("Erro", $"Erro ao excluir logradouro: {ex.Message}", "OK"); }
    }
}