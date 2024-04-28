# Memory.Manipulation [![NuGet](https://img.shields.io/nuget/v/Memory.Manipulation.svg)](https://www.nuget.org/packages/Memory.Manipulation)

Library for memory manipulating, get regions, set rights, use pattern scan, calculate offsets, validate pointers and etc

Get regions
------------------------------
```C#
Mem.GetAllRegions() // All regions, even free
Mem.GetRegions(mbi => ...) // Regions adopting the condition in the arguments
Mem.GetAccesibleRegions() // Commited regions without Guard that has access flags
Mem.GetCommitedRegions() // All Commited regions
Mem.GetReadableRegions() // Regions available for reading
Mem.GetWriteableRegions() // Regions available for writing
```

Create pattern for signature scan
------------------------------
```C#
Mem.CreatePattern("0 2F 90 ?") // 00 2F 90 ??
Mem.CreatePattern("0 0x2F 90 ?????") // 00 2F 90 ??
Mem.CreatePattern("00 2F 90 .") // 00 2F 90 ??

Mem.CreatePattern(2d) // 40 00 00 00 00 00 00 00
// So work for all primitive types

Mem.CreatePattern([0, 0x2F, 0x90, null]) // 00 2F 90 ??
```

Signature scan
------------------------------
```C#
var regions = ...;
var pattern = ...;
var found = Mem.Scan(pattern, regions);
```

Pointer validating
------------------------------
```C#
var pointer = ...;
var isValid = Mem.IsValid(pointer); // Checks if the pointer is inside the commited region
```

Calculate offsets
------------------------------
```C#
var pointer = ...;
var shifted = Mem.CalcOffsets(pointer, 0, 8, 0x90, 0);
/*
  Alternative for:
    var shifted = *(nint*)(*(nint*)(*(nint*)(*(nint*)(pointer + 0) + 8) + 0x90) + 0);
*/
```

Versions
------------------------------
| Start ordinal | Framework | Description                  | Date         |
| ---           | ---       | ---                          | ---          |
| 1.0.0         | .net8.0   | Published                    | Apr 29, 2024 |
|               | .net8.0   | Changed framework            | Apr 26, 2024 |
|               | .net7.0   |                              | Sep 28, 2023 |
