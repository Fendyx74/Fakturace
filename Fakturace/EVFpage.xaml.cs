using Fakturace.Model;
using Fakturace.Data;

namespace Fakturace;

public partial class EVFpage : ContentPage
{
    ContextVystavenych DbVystavenych;
    ContextOdberatelu DbOdberatelu;
    Faktura F;

    public EVFpage(ContextOdberatelu dbOdberatelu, ContextVystavenych dbVystavenych)
	{
        InitializeComponent();
        DbVystavenych = dbVystavenych;
        DbOdberatelu = dbOdberatelu;
        vystaveneList.ItemsSource = DbVystavenych.Faktury.ToList();
    }

    public async void Button_Nova_Faktura(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovaFaktura(DbVystavenych, vystaveneList, DbOdberatelu));
    }

    public void VystaveneList_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        Faktura f = (sender as ListView).SelectedItem as Faktura;
        F = f;
        vybranaFaktura.Text = "Vybrána faktura è. " + F.CisloFaktury;
    }

    public void Button_Otevrit_Fakturu(object sender, EventArgs e)
    {
        if (F != null)
        {
            F.OpenFile($"Faktura {F.CisloFaktury}.pdf", "application/pdf");
        }
        else
            DisplayAlert("Chyba", "Nebyla vybrána žádná faktura.", "OK");

    }
    private async void Button_Smazat_Fakturu(object sender, EventArgs e)
    {
        if (F != null)
        {
            var result = await DisplayAlert("Pozor", "Opravdu chcete odstranit tuhle fakturu?", "Ano", "Zrušit");
            if (result)
            {
                DbVystavenych.Faktury.Remove(F);
                DbVystavenych.SaveChanges();
                vystaveneList.ItemsSource = null;
                vystaveneList.ItemsSource = DbVystavenych.Faktury.ToList();
                vybranaFaktura.Text = "Vybrána faktura è. ---";
            }
            F = null;
        }
        else
        {
            await DisplayAlert("Chyba", "Nebyla vybrána žádná faktura", "OK");
        }
    }
}