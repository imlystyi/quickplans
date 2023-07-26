using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Sharpnado.CollectionView;

namespace QuickPlans;

/// <summary>
/// Entry point of the application.
/// </summary>
public static class MauiProgram
{
    /// <summary>
    /// Builds .NET MAUI application by builder configuration.
    /// </summary>
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSans-Regular");
                fonts.AddFont("OpenSans-Light.ttf", "OpenSans-Light");
            })
            .UseSharpnadoCollectionView(false);
#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
