﻿/* Copyright 2023 imlystyi
* Licensed under the Apache License, Version 2.0 (the "License"); 
* you may not use this file except in compliance with the License. 
* You may obtain a copy of the License at 
* http://www.apache.org/licenses/LICENSE-2.0
* Unless required by applicable law or agreed to in writing, 
* software distributed under the License is distributed on an "AS IS" 
* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express 
* or implied. See the License for the specific language governing 
* permissions and limitations under the License. */
namespace QuickPlans;

/// <summary>
/// Provides application-specific behavior to supplement the default <see cref="Application"/> class.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Initializes the singleton application object.
    /// </summary>
    public App()
    {
        InitializeComponent();

        MainPage = new AppShell();
    }
}
