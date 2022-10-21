using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        var p = new Program();
        await p.Test1();
    }

    private readonly AsyncLocal<string> _al =
        new AsyncLocal<string>() { Value = "ctor-value" };

    public async Task Test1()
    {
        //M1_sync();
        await M1();
        await M2();
    }

    private void M1_sync()
    {
        _al.Value = "42";
    }

    private async Task M1()
    {
        _al.Value = "42";
        if (_al.Value != "42")
            throw new InvalidOperationException($"direct: got {_al.Value}");
        await Task.Delay(10);
    }

    private async Task M2()
    {
        if (_al.Value != "42")
            throw new InvalidOperationException($"got {_al.Value}");
        await Task.Delay(10);
    }
}