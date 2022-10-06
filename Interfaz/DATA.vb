Module DATA

    Public autoEjemplo As New Auto With {.Marca = "Toyota",
        .Cilindrada = 100,
        .Color = "Negro",
        .Combustible = "Diesel",
        .Estilo = "PickUp",
        .Kilometraje = 100,
        .Año = 2022,
        .Modelo = "Hilux",
        .Precio = 100000,
        .Transmision = "Manual"}
    Public autoEjemplo1 As New Auto With {.Marca = "Nissan",
        .Cilindrada = 100,
        .Color = "Negro",
        .Combustible = "Diesel",
        .Estilo = "PickUp",
        .Kilometraje = 100,
        .Año = 2020,
        .Modelo = "Hilux",
        .Precio = 100000,
        .Transmision = "Manual"}
    Public listaAutos As New List(Of Auto)

    Public listaMarcas() As String = {"Toyota", "BWM", "Nissan", "Subaro", "Honda", "Kawasaki"}

    Public listaEstilos() As String = {"SUV", "Sedan", "hatchback", "Convertible"}





End Module
