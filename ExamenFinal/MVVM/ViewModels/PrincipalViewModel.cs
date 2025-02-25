
using ExamenFinal.MVVM.Models;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExamenFinal.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class PrincipalViewModel
    {
        public ObservableCollection<LibroModel> ObservableLibros { get; set; } = new ObservableCollection<LibroModel>();

        public PrincipalViewModel()
        {
            ObservableLibros = new ObservableCollection<LibroModel>()
            {
                new LibroModel()
                {
                    Titulo = "Titulo1",
                    Autor = "Autor1",
                    NumPagTotales = 100,
                    NumPagLeidas = 60,
                    PorcentajeLeido = 60*100/100
                },
                new LibroModel()
                {
                    Titulo = "Titulo2",
                    Autor = "Autor2",
                    NumPagTotales = 200,
                    NumPagLeidas = 5,
                    PorcentajeLeido = 5*100/200
                },
                new LibroModel()
                {
                    Titulo = "Titulo3",
                    Autor = "Autor3",
                    NumPagTotales = 300,
                    NumPagLeidas = 299,
                    PorcentajeLeido = 299*100/300
                }
            };

        }

        //Command usado para buscar los libros por título. Debería de funcionar pero por alguna razón me obliga a que el
        // ObservableCollection sea static, pero si lo pongo así deja de mostrarse los datos en el CollectionView

        /*
        public ICommand Comando = new Command((titulo) =>
        {

            if(titulo == null)
            {
                TituloLabel.Text = "";
                AutorLabel.Text = "";
                PaginasTotalesLabel.Text = "";
                PaginasLeidasLabel.Text = "";
                BarraProgresoBuscado.Progress = "0.0";
            }
            
            var libroEncontrado = ObservableLibros.Where(libro => libro.Titulo == titulo.ToString()).FirstOrDefault();

            if(libroEncontrado != null)
            {
                TituloLabel.Text = libroEncontrado.Titulo;
                AutorLabel.Text = libroEncontrado.Autor;
                PaginasTotalesLabel.Text = libroEncontrado.NumPagTotales;
                PaginasLeidasLabel.Text = libroEncontrado.NumPagLeidas;
                BarraProgresoBuscado.Progress = libroEncontrado.PorcentajeLeido;
            }


        });

        */

        //Command para agregar libros
        /*
         public ICommand ComandoAgregar = new Command((titulo, autor, pagTotales, pagLeidas) =>
         {

               ObservableLibros.Add(new LibroModel()
               {
                    Titulo = titulo;
                    Autor = autor;  
                    NumPagTotales = pagTotales
                    NumPagLeidas = pagLeidas
                    PorcentajeLeido = pagLeidas*100/pagTotales
               });
         }
         
        */



    }
}
