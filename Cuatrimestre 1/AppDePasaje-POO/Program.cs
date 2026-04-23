using AppDePasaje_POO;

Pasajero pasajero1 = new Pasajero("Pepe", "1233 1235 3213", 0, TipoBeneficio.Null);

pasajero1.showData();

Boleto boleto1 = new Boleto();

Console.WriteLine(boleto1.Cobrar(pasajero1));

pasajero1.CargarSaldo(1000);
Console.WriteLine(boleto1.Cobrar(pasajero1));