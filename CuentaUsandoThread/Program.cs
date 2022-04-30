// Thread es una clase que permite hacer programación paralela
// es decir ejecutar mas de un flujo de instrucciones.
// Para lanzar un hilo hay que crearlo con t = new Thread(new ThreadStart(NombreDelProcedimientoQueEjecute));
// Y luego usar t.Start();

/// <summary>
/// Cuenta de 0 a 20 y se demora un segundo en cada paso, 
/// como usa dos hilos
/// el tiempo que le toma es solo 10 segundos.
/// </summary>
class Program
{
    private static object _semaforo = new object();
    private static int _final = 20;
    private static int _demoraEnMilisegundos = 1000;
    private static int _actual = 0;

    public static void Main()
    {
        Thread t1 = new Thread(new ThreadStart(ThreadContador));
        Thread t2 = new Thread(new ThreadStart(ThreadContador));
        t1.Start();
        t2.Start();
    }
    public static void ThreadContador()
    {
        while (true)
        {
            lock (_semaforo)
            {
                if (_actual < _final)
                {
                    _actual++;
                    Console.WriteLine($"Contando: {_actual}");
                }
                else
                {
                    return;
                }
            }
            Thread.Sleep(_demoraEnMilisegundos);
        }
    }
}


