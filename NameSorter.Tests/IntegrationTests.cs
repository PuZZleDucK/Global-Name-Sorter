using System;
using System.IO;
using System.Collections.Generic;
using Xunit;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace NameSorter.Tests
{
    public class IntegrationTests
    {
        private static Process _global_name_sorter;

        public IntegrationTests()
        {
            _global_name_sorter = PrepareNameSorterProcess(_global_name_sorter);
        }

        [Fact]
        public void ProgramPrintsUsageWithoutArgs()
        {
            _global_name_sorter.StartInfo.Arguments = "";
            _global_name_sorter.Start();
            string output = _global_name_sorter.StandardOutput.ReadToEnd();
            _global_name_sorter.WaitForExit();
            Assert.Matches("GlobalNameSorter requires at least one argument. Example usage:\n    GlobalNameSorter <./unsorted-names-list.txt>", output);
        }


        public static Process PrepareNameSorterProcess(Process _global_name_sorter)
        {
            if (_global_name_sorter == null) {
                var _global_name_sorter_builder = new Process();
                _global_name_sorter_builder.StartInfo.FileName = @"dotnet-sdk.dotnet";
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    _global_name_sorter_builder.StartInfo.Arguments = "publish -c Release -r ubuntu.14.04-x64 ../../../../../GlobalNameSorter";
                } else {
                    _global_name_sorter_builder.StartInfo.Arguments = @"publish -c Release -r win10-x64 ..\..\..\..\..\GlobalNameSorter";
                }
                _global_name_sorter_builder.Start();
                _global_name_sorter_builder.WaitForExit();
            }
            var global_name_sorter = new Process();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                global_name_sorter.StartInfo.FileName = @"../../../../GlobalNameSorter/bin/Release/netcoreapp2.1/ubuntu.14.04-x64/GlobalNameSorter";
            } else {
                global_name_sorter.StartInfo.FileName = @"..\..\..\..\GlobalNameSorter\bin\Release\netcoreapp2.1\win10-x64\GlobalNameSorter";
            }
            global_name_sorter.StartInfo.RedirectStandardOutput = true;
            return global_name_sorter;
        }



    }
}
