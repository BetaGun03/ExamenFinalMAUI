using ExamenFinal.MVVM.Models;
using ExamenFinal.MVVM.ViewModels;
using PropertyChanged;

namespace ExamenFinal.MVVM.Views;

public partial class BuscadorView : ContentPage
{
    public PrincipalViewModel vm { get; set; }
    public LibroModel libroEncontrado { get; set; }
    public BuscadorView()
	{
		InitializeComponent();
        this.BindingContext = this;
    }

	public BuscadorView(PrincipalViewModel vm)
    {
        InitializeComponent();
        this.vm = vm;
        this.BindingContext = this; //Hace falta poner estos BindingContext el libroEncontrado, sino alguna cosas no funcionan como el converter
    }

    //Método que busca un libro por su título
    public LibroModel buscarLibroPorTitulo(string titulo)
    {
        foreach (LibroModel libro in vm.ObservableLibros)
        {
            if (libro.Titulo.ToLower() == titulo.ToLower())
            {
                this.libroEncontrado = libro;
                return libro;
            }
        }
        return null;
    }

    //Método que actualiza los datos de un libro en el ObservableCollection y en el libroEncontrado
    public void actualizarLibroEncontrado(String titulo, String autor, int pagTotales, int pagLeidas, int porcentajeLeido)
    {
        if (libroEncontrado != null)
        {
            foreach(LibroModel libro in vm.ObservableLibros)
            {
                if (libro.Titulo == libroEncontrado.Titulo)
                {
                    libro.Titulo = titulo;
                    libro.Autor = autor;
                    libro.NumPagTotales = pagTotales;
                    libro.NumPagLeidas = pagLeidas;
                    libro.PorcentajeLeido = porcentajeLeido;
                    libroEncontrado = libro;
                }
            }
        }
    }

    private void BtnBuscar_Clicked(object sender, EventArgs e)
    {
        LibroModel libro = null;

        if(EntryBuscar.Text != null)
        {
           libro = buscarLibroPorTitulo(EntryBuscar.Text);
        }

        if(libro != null)
        {
            TituloEntry.Text = libro.Titulo;
            AutorEntry.Text = libro.Autor;
            PaginasTotalesEntry.Text = libro.NumPagTotales.ToString();
            PaginasLeidasEntry.Text = libro.NumPagLeidas.ToString();
        }
        else
        {
            TituloEntry.Text = "";
            AutorEntry.Text = "";
            PaginasTotalesEntry.Text = "";
            PaginasLeidasEntry.Text = "";
            BarraProgresoBuscado.Progress = 0.0;
            libroEncontrado = null;
            Application.Current.MainPage.DisplayAlert("Libro no encontrado", "El libro no ha sido encontrado", "OK");
        }
    }

    private void BtnActualizarGuardar_Clicked(object sender, EventArgs e)
    {
        if(libroEncontrado != null)
        {
            actualizarLibroEncontrado(TituloEntry.Text, AutorEntry.Text, int.Parse(PaginasTotalesEntry.Text), int.Parse(PaginasLeidasEntry.Text), int.Parse(PaginasLeidasEntry.Text) * 100 / int.Parse(PaginasTotalesEntry.Text));
            Application.Current.MainPage.DisplayAlert("Libro actualizado", "El libro ha sido actualizado correctamente", "OK");
        }
        else
        {
            vm.ObservableLibros.Add(new LibroModel()
            {
                Titulo = TituloEntry.Text,
                Autor = AutorEntry.Text,
                NumPagTotales = int.Parse(PaginasTotalesEntry.Text),
                NumPagLeidas = int.Parse(PaginasLeidasEntry.Text),
                PorcentajeLeido = int.Parse(PaginasLeidasEntry.Text) * 100 / int.Parse(PaginasTotalesEntry.Text)
            });
            Application.Current.MainPage.DisplayAlert("Libro añadido", "El libro ha sido añadido correctamente", "OK");
        }
    }
}