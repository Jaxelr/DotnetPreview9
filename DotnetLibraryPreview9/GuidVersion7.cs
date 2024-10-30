using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetLibraryPreview9;

public class GuidVersion7
{
    public GuidVersion7()
    {
        for (int i = 0; i < 5; i++)
        {
            var guid = Guid.NewGuid();

            Console.WriteLine($"V{guid.Version}: {guid}");
        }
        Console.WriteLine();
        for (int i = 0; i < 5; i++)
        {
            // This new Guid most of the data is still random,
            // but some of it is reserved for data based on a timestamp,
            // which enables these values to have a natural sort order.
            var guid = Guid.CreateVersion7();

            Console.WriteLine($"V{guid.Version}: {guid}");
        }

        // V4: 0557b321 - abcf - 4390 - abee - 4b8fbf93ff34
        // V4: 21a98165 - af1e - 477e - 9dee - 7eb9c79e6c77
        // V4: 7dbbf973 - c55a - 4917 - 87a5 - 95c16f356262
        // V4: b13892f2 - 334f - 409a - b9de - d90dea21eed4
        // V4: 52dc44f7 - 76e0 - 4689 - a5e6 - 1a0f1c5f37a3

        // V7: 01917bbe - d973 - 7beb - a813 - 106fcb4eff98
        // V7: 01917bbe - d973 - 703c - 8365 - b7596740ac82
        // V7: 01917bbe - d973 - 7234 - a580 - 5f07730a3ad7
        // V7: 01917bbe - d973 - 7751 - b8ba - bb73afab4a5d
        // V7: 01917bbe - d973 - 7d36 - 9be0 - 2e6317919153
    }
}
