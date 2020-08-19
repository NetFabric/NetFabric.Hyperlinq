## AsyncEnumerableBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]     : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  DefaultJob : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Categories=Linq  

```
|            Method | Count |          Mean |        Error |       StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |------ |--------------:|-------------:|-------------:|------:|-------:|------:|------:|----------:|
| **Linq_AwaitForEach** |     **0** |      **59.82 ns** |     **0.524 ns** |     **0.490 ns** |  **1.00** |      **-** |     **-** |     **-** |         **-** |
|       Linq_Manual |     0 |      60.83 ns |     0.313 ns |     0.293 ns |  1.02 |      - |     - |     - |         - |
|                   |       |               |              |              |       |        |       |       |           |
| **Linq_AwaitForEach** |    **10** |     **648.48 ns** |     **3.064 ns** |     **2.716 ns** |  **1.00** | **0.0229** |     **-** |     **-** |      **48 B** |
|       Linq_Manual |    10 |     634.00 ns |     2.989 ns |     2.796 ns |  0.98 | 0.0229 |     - |     - |      48 B |
|                   |       |               |              |              |       |        |       |       |           |
| **Linq_AwaitForEach** |   **100** |   **5,102.63 ns** |    **16.621 ns** |    **13.879 ns** |  **1.00** | **0.0229** |     **-** |     **-** |      **48 B** |
|       Linq_Manual |   100 |   5,076.94 ns |    39.236 ns |    34.782 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                   |       |               |              |              |       |        |       |       |           |
| **Linq_AwaitForEach** | **10000** | **501,067.69 ns** | **3,421.246 ns** | **3,032.846 ns** |  **1.00** |      **-** |     **-** |     **-** |      **48 B** |
|       Linq_Manual | 10000 | 489,305.60 ns | 2,860.053 ns | 2,388.274 ns |  0.98 |      - |     - |     - |      48 B |
