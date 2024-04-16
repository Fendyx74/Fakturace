using Fakturace.Data;
using Microsoft.Maui.Graphics;

namespace Fakturace
{
    public partial class MainPage : ContentPage
    {
        private bool isDarkMode = false;

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

            ApplyTheme();
        }

        //Honza

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

        

        private void SwitchDark_Clicked(object sender, EventArgs e)
        {
            
            isDarkMode = true;
            ApplyTheme();
        }

        private void SwitchLight_Clicked(object sender, EventArgs e)
        {
            
            isDarkMode = false;
            ApplyTheme();
        }

        private void ApplyTheme()
        {
            if (isDarkMode)
            {
                
                this.BindingContext = new ThemeViewModel
                {
                    PageBackgroundColor = Colors.Black,
                    ButtonBackgroundColor = Colors.Black,
                    ButtonTextColor = Color.FromHex("#FFDD00"),
                    ButtonBorderColor = Colors.White,
                    ButtonMarginColor = Colors.Black,
                    HeaderTextColor = Colors.White,
                    SeparatorColor = Colors.Gray,
                    SimulationButtonBackgroundColor = Colors.Black, 
                    SimulationButtonTextColor = Colors.Green,
                    DarkButtonBackgroundColor = Colors.Black, 
                    DarkButtonTextColor = Colors.White,
                    LightButtonBackgroundColor = Colors.White, 
                    LightButtonTextColor = Colors.Black
                };
            }
            else
            {
                
                this.BindingContext = new ThemeViewModel
                {
                    PageBackgroundColor = Colors.Gray,
                    ButtonBackgroundColor = Color.FromHex("#FFDD00"),
                    ButtonTextColor = Colors.Black,
                    ButtonBorderColor = Colors.Black, 
                    ButtonMarginColor = Color.FromHex("#FFDD00"), 
                    HeaderTextColor = Colors.Black,
                    SeparatorColor = Colors.Gray,
                    SimulationButtonBackgroundColor = Colors.Green, 
                    SimulationButtonTextColor = Colors.Black, 
                    DarkButtonBackgroundColor = Colors.Black, 
                    DarkButtonTextColor = Colors.White,
                    LightButtonBackgroundColor = Colors.White, 
                    LightButtonTextColor = Colors.Black
                };
            }
        }
    }

    public class ThemeViewModel
    {
        public Color PageBackgroundColor { get; set; }
        public Color ButtonBackgroundColor { get; set; }
        public Color ButtonTextColor { get; set; }
        public Color HeaderTextColor { get; set; }
        public Color SeparatorColor { get; set; }
        public Color ButtonMarginColor { get; set; }
        public Color ButtonBorderColor { get; set; }
        public Color SimulationButtonTextColor { get; set; }
        public Color SimulationButtonBackgroundColor { get; set; }
        public Color DarkButtonBackgroundColor { get; set; }
        public Color DarkButtonTextColor { get; set; }
        public Color LightButtonBackgroundColor { get; set; }
        public Color LightButtonTextColor { get; set; }
    }
}
