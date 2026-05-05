using FromUMLtoApp.Enums;
using FromUMLtoApp.Models;

var actores = new List<Actor>
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
pelicula1.Clasificacion = ClasificacionEnum.Mas16;
pelicula1.Actors = actores;
pelicula1.AñoLanzamiento = 2007;
pelicula1.DuracionEnMinutos = 2203;
pelicula1.Titulo = "Casados con primos";
pelicula1.Director = director1;
pelicula1.Genero = genero1;
