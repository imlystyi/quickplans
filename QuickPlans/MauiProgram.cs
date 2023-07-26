/* Copyright 2023 imlystyi
* Licensed under the Apache License, Version 2.0 (the "License"); 
* you may not use this file except in compliance with the License. 
* You may obtain a copy of the License at 
* http://www.apache.org/licenses/LICENSE-2.0
* Unless required by applicable law or agreed to in writing, 
* software distributed under the License is distributed on an "AS IS" 
* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express 
* or implied. See the License for the specific language governing 
* permissions and limitations under the License. */
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
