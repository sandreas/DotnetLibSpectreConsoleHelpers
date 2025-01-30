using Spectre.Console;
using Spectre.Console.Rendering;

namespace Sandreas.SpectreConsoleHelpers.Services;

public class SpectreConsoleService : IAnsiConsole
{
    private IAnsiConsole Output { get; }
    public IAnsiConsole Error { get; }

    public SpectreConsoleService(IAnsiConsole? stdout = null, IAnsiConsole? stderr = null)
    {
        Output = stdout ?? AnsiConsole.Console;
        Error = stderr ?? AnsiConsole.Create(new AnsiConsoleSettings
        {
            Out = new AnsiConsoleOutput(Console.Error)
        });
    }

    public Profile Profile => Output.Profile;
    public IAnsiConsoleCursor Cursor => Output.Cursor;
    public IAnsiConsoleInput Input => Output.Input;
    public IExclusivityMode ExclusivityMode => Output.ExclusivityMode;
    public RenderPipeline Pipeline => Output.Pipeline;

    public void WriteNoBreakLine(string text)
    {
        var oldWidth = Output.Profile.Width;
        Output.Profile.Width = text.Length;
        Output.WriteLine(text, Style.Plain);
        Output.Profile.Width = oldWidth;
    } 
    
    public void Clear(bool home)
    {
        Output.Clear(home);
    }

    public void Write(IRenderable renderable)
    {
        Output.Write(renderable);
    }
}