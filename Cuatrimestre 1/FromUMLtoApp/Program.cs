using FromUMLtoApp;
using FromUMLtoApp.Enums;
using FromUMLtoApp.Models;

List<Actor> actores = new List<Actor> 
{
    new Actor { Nombre = "Pepe", Nacionalidad = "Argentino", AñoNacimiento = 1974 },
    new Actor { Nombre = "Ana", Nacionalidad = "Española", AñoNacimiento = 1982 },
    new Actor { Nombre = "John", Nacionalidad = "Estadounidense", AñoNacimiento = 1965 },
    new Actor { Nombre = "Yuki", Nacionalidad = "Japonesa", AñoNacimiento = 1990 }
};
var director1 = new Director();
director1.Nombre = "Juan";
director1.Nacionalidad = "Peru";
director1.AñoNacimiento = 2005;
var genero1 = new Genero();
genero1.Nombre = "Accion";
 
Pelicula pelicula1 = new Pelicula();
pelicula1.Clasificacion = ClasificacionEnum.Mas18;
pelicula1.Actors = actores;
pelicula1.AñoLanzamiento = 1233;
pelicula1.DuracionEnMinutos = 3523;
pelicula1.Titulo = "Casados con primos";
pelicula1.Director = director1;
pelicula1.Genero = genero1;

Console.WriteLine(pelicula1.MostrarInfo());
Console.ReadKey();
Console.Clear();
Pelicula pelicula2 = new Pelicula();
pelicula2.Clasificacion = ClasificacionEnum.Mas16;
pelicula2.Actors = actores;
pelicula2.AñoLanzamiento = 2007;
pelicula2.DuracionEnMinutos = 2203;
pelicula2.Titulo = "Casados con primos";
pelicula2.Director = director1;
pelicula2.Genero = genero1;

Console.WriteLine(pelicula2.MostrarInfo());
Console.ReadKey();
Console.Clear();

Serie serie1 = new Serie();
serie1.CantidadTemporada = 5;
serie1.CantidadEpisodios = 11;
serie1.Actors = actores;
serie1.AñoLanzamiento = 2019;
serie1.DuracionEnMinutos = 55023;
serie1.Titulo = "Stranger Things";
serie1.Director = director1;
serie1.Genero = genero1;
Console.WriteLine(serie1.MostrarInfo());
Console.ReadKey();
Console.Clear();

Serie serie2 = new Serie();
serie2.CantidadTemporada = 2;
serie2.CantidadEpisodios = 15;
serie2.Actors = actores;
serie2.AñoLanzamiento = 2000;
serie2.DuracionEnMinutos = 684323;
serie2.Titulo = "Como tan muchacho";
serie2.Director = director1;
serie2.Genero = genero1;
Console.WriteLine(serie2.MostrarInfo());
Console.ReadKey();
Console.Clear();