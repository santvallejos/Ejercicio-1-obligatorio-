//Weather Forecast

weatherForescast();

void weatherForescast()
{
    var starAnswer = starProgram();

    if(!evaluateAnswers(starAnswer))
    {
        Console.WriteLine("Respuesta erronea o vacia!");
    }
    else
    {
        if(starAnswer == "si" || starAnswer == "Si" || starAnswer == "s")
        {

            int temperature = enterTemperature();

            resultTemp(temperature);

            tempNextDays(temperature);

            askAnotherTemp();

        }
    }

    //endProgram
    Console.WriteLine("\nSaliendo...");
}

string starProgram(){
    Console.WriteLine("Hola! Deseas consultar alguna temperatura? (Si | No)");
    return Console.ReadLine();
}

//Evalua si la respuesta es null
bool evaluateAnswers(string answers)
{
    return !string.IsNullOrWhiteSpace(answers);
}

int enterTemperature()
{
    Console.WriteLine("\nIngrese la temperatura de la zona: ");
    var temperature = Console.ReadLine();
    int tempInt;
    Int32.TryParse(temperature, out tempInt);
    return tempInt;
}

void resultTemp(int temperature)
{
    if(temperature < 0)
    {
        Console.WriteLine("\nHace mucho frío afuera, asegúrate de abrigarte bien.");
    }
    else if (temperature >= 0 && temperature <= 20)
    {
        Console.WriteLine("\nEl clima está fresco, una chaqueta ligera sería perfecta.");
    }
    else
    {
        Console.WriteLine("\nHace calor afuera, no necesitas una chaqueta.");
    }
}

void tempNextDays(int temperature)
{
    Console.WriteLine("\nDeseas consultar la temperatura de los proximos siguientes 5 días? (Si | No)");
    var answerProx5Day = Console.ReadLine();
    if(!evaluateAnswers(answerProx5Day))
    {
        Console.WriteLine("Respuesta erronea o vacia!");
    }
    else
    {

        if(answerProx5Day == "si" || answerProx5Day == "Si" || answerProx5Day == "s")
            generateTempNext5(temperature);

    }
}

void generateTempNext5(int temperature)
{
    for(int i = 1; i < 4; i++)
    {
        temperature++;
        Console.WriteLine($"Dia {i}: {temperature}");
    }
    Console.WriteLine($"Dia 4: {temperature}\nDia 5: {temperature - 1}");
}

void askAnotherTemp()
{
    Console.WriteLine("\nQuieres consultar otra temperatura? (Si | No) ");
    var answerAnotherTemp = Console.ReadLine();

    if(!evaluateAnswers(answerAnotherTemp))
    {
        Console.WriteLine("Respuesta erronea o vacia!");
    }
    else
    {
        while(answerAnotherTemp == "si" || answerAnotherTemp == "Si" || answerAnotherTemp == "s")
        {
            var anotherTemp = enterTemperature();
            resultTemp(anotherTemp);
            Console.WriteLine("\nQuieres consultar otra temperatura? (Si | No)");
            answerAnotherTemp = Console.ReadLine();
        }
    }
}