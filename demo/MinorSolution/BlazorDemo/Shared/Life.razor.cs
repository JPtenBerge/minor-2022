using Microsoft.AspNetCore.Components;

namespace BlazorDemo.Shared;

public partial class Life : ComponentBase, IDisposable
{
    private Timer? _timer;
    
    [Parameter] public int Getal { get; set; }
    public Life()
    {
        Console.WriteLine("[life] constructor met getal: " + Getal);
    }
    
    protected override void OnInitialized()
    {
        Console.WriteLine("[life] OnInitialized met getal: " + Getal);

        _timer = new Timer(new TimerCallback(state =>
        {
            Console.WriteLine("Hallo vanuit timer!");
        }), null, 1000, 1000);

    }

    public void Dispose()
    {
        _timer?.Dispose();
        
        // timeouts/intervals
        // websockets
        // database connections
        // - indexed database
        // - (deprecated) web sql
        // web workers
        // bluetooth
        // camera API
        // geolocation
    }
}