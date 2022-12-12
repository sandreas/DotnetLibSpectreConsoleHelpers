namespace Sandreas.SpectreConsoleHelpers.DependencyInjection;
using Spectre.Console.Cli;


public class CustomCommandInterceptor: ICommandInterceptor
{
    private readonly CustomCommandSettingsProvider _settingsProvider;
    public CustomCommandInterceptor(CustomCommandSettingsProvider settingsProvider) => _settingsProvider = settingsProvider;

    public void Intercept(CommandContext context, CommandSettings settings) => _settingsProvider.Settings = settings;
}