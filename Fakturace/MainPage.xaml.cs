using Fakturace.Data;

namespace Fakturace
{
    public partial class MainPage : ContentPage
    {
        ContextPrijatych DbPrijatych;
        ContextVystavenych DbVystavenych;
        ContextDodavatelu DbDodavatelu;
        ContextOdberatelu DbOdberatelu;

        ListView PrijateList;
        ListView VystaveneList;

        public MainPage()
        {
            InitializeComponent();
            DbPrijatych = new ContextPrijatych();
            DbVystavenych = new ContextVystavenych();
            DbDodavatelu = new ContextDodavatelu();
            DbOdberatelu = new ContextOdberatelu();
            PrijateList = new ListView();
            VystaveneList = new ListView();
        }

        private async void Button_Prijate(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EPFpage(DbDodavatelu, DbPrijatych));
        }

        private async void Button_Vystavene(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EVFpage(DbOdberatelu, DbVystavenych));
        }

        private async void Button_Dodavatele(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EDpage(DbDodavatelu, DbPrijatych, PrijateList));
        }

        private async void Button_Odberatele(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EOpage(DbOdberatelu, DbVystavenych, VystaveneList));
        }

        private async void Button_Simulace(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SIMpage(DbDodavatelu, DbOdberatelu, DbPrijatych, DbVystavenych));
        }
    }
}