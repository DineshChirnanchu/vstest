﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Microsoft.VisualStudio.TestPlatform.SettingsMigrator
{
    using System;
    using System.Globalization;
    using System.IO;
    using CommandLineResources = Resources.Resources;

    /// <summary>
    /// Entry point for SettingsMigrator.
    /// </summary>
    public static class Program
    {
        private const string RunSettingsExtension = ".runsettings";

        /// <summary>
        /// Main entry point. Hands off execution to Migrator.
        /// </summary>
        /// <param name="args">Arguments on the commandline</param>
        /// <returns>Exit code</returns>
        public static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine(string.Format(CultureInfo.CurrentCulture, CommandLineResources.ValidUsage));
                return 1;
            }

            string oldFilePath = args[0];
            var newFileName = string.Concat(Guid.NewGuid().ToString(), RunSettingsExtension);
            string newFilePath = Path.Combine(Path.GetDirectoryName(oldFilePath), newFileName);

            var migrator = new Migrator();
            migrator.Migrate(oldFilePath, newFilePath);

            return 0;
        }
    }
}