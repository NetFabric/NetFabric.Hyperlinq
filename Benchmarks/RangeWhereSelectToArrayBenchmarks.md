## RangeWhereSelectToArrayBenchmarks

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
|    Method | Count |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------- |------ |------------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|      **Linq** |     **0** |    **76.27 ns** | **0.584 ns** | **0.546 ns** |  **1.00** | **0.0573** |     **-** |     **-** |     **120 B** |
| Hyperlinq |     0 |    55.46 ns | 0.304 ns | 0.284 ns |  0.73 | 0.0112 |     - |     - |      24 B |
|           |       |             |          |          |       |        |       |       |           |
|      **Linq** |     **1** |   **139.52 ns** | **1.281 ns** | **1.198 ns** |  **1.00** | **0.1109** |     **-** |     **-** |     **232 B** |
| Hyperlinq |     1 |    91.44 ns | 0.476 ns | 0.446 ns |  0.66 | 0.0153 |     - |     - |      32 B |
|           |       |             |          |          |       |        |       |       |           |
|      **Linq** |    **10** |   **207.57 ns** | **0.861 ns** | **0.806 ns** |  **1.00** | **0.1450** |     **-** |     **-** |     **304 B** |
| Hyperlinq |    10 |   121.85 ns | 0.787 ns | 0.736 ns |  0.59 | 0.0229 |     - |     - |      48 B |
|           |       |             |          |          |       |        |       |       |           |
|      **Linq** |   **100** | **1,025.21 ns** | **6.287 ns** | **5.573 ns** |  **1.00** | **0.3967** |     **-** |     **-** |     **832 B** |
| Hyperlinq |   100 |   624.09 ns | 5.146 ns | 4.562 ns |  0.61 | 0.1068 |     - |     - |     224 B |
