## ArraySkipTakeWhereSelectBenchmarks

### References:
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|    Method | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|      **Linq** |     **0** | **135.09 ns** | **0.744 ns** | **0.660 ns** |  **1.00** | **0.1032** |     **-** |     **-** |     **216 B** |
| Hyperlinq |     0 |  32.49 ns | 0.100 ns | 0.089 ns |  0.24 |      - |     - |     - |         - |
|           |       |           |          |          |       |        |       |       |           |
|      **Linq** |     **1** | **146.28 ns** | **0.439 ns** | **0.343 ns** |  **1.00** | **0.1032** |     **-** |     **-** |     **216 B** |
| Hyperlinq |     1 |  39.04 ns | 0.359 ns | 0.336 ns |  0.27 |      - |     - |     - |         - |
|           |       |           |          |          |       |        |       |       |           |
|      **Linq** |    **10** | **300.95 ns** | **1.787 ns** | **1.584 ns** |  **1.00** | **0.1030** |     **-** |     **-** |     **216 B** |
| Hyperlinq |    10 | 106.25 ns | 1.707 ns | 1.513 ns |  0.35 |      - |     - |     - |         - |
|           |       |           |          |          |       |        |       |       |           |
|      **Linq** |   **100** | **299.66 ns** | **2.495 ns** | **2.211 ns** |  **1.00** | **0.1030** |     **-** |     **-** |     **216 B** |
| Hyperlinq |   100 | 104.14 ns | 0.965 ns | 0.903 ns |  0.35 |      - |     - |     - |         - |
