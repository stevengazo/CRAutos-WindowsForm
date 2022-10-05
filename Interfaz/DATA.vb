Module DATA

    Public autoEjemplo As New Auto With {.Marca = "Toyota",
        .Cilindrada = 100,
        .Color = "Negro",
        .Combustible = "Diesel",
        .Estilo = "PickUp",
        .Kilometraje = 100,
        .Modelo = "Hilux",
        .Precio = 100000,
        .Transmision = "Manual"}

    Public listaAutos As New List(Of Auto)

    Public listaMarcas() As String = {"Toyota", "BWM", "Nissan", "Subaro", "Honda", "Kawasaki"}

    Public listaEstilos() As String = {"SUV", "Sedan", "hatchback", "Convertible"}





End Module
