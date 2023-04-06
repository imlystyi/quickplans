using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Sharpnado.CollectionView;

namespace QuickPlans;

public static class MauiProgram
{
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
            }).
            UseSharpnadoCollectionView(false);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
