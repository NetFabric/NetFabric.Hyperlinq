## RangeSelectDistinctToListBenchmarks

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
|    Method | Count |        Mean |     Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|---------- |------ |------------:|----------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|      **Linq** |     **0** |    **75.58 ns** |  **0.509 ns** | **0.476 ns** |  **1.00** |    **0.00** | **0.1490** |     **-** |     **-** |     **312 B** |
| Hyperlinq |     0 |    77.00 ns |  0.365 ns | 0.342 ns |  1.02 |    0.01 | 0.0457 |     - |     - |      96 B |
|           |       |             |           |          |       |         |        |       |       |           |
|      **Linq** |     **1** |   **125.05 ns** |  **1.158 ns** | **1.084 ns** |  **1.00** |    **0.00** | **0.2065** |     **-** |     **-** |     **432 B** |
| Hyperlinq |     1 |   176.35 ns |  1.547 ns | 1.208 ns |  1.41 |    0.02 | 0.0610 |     - |     - |     128 B |
|           |       |             |           |          |       |         |        |       |       |           |
|      **Linq** |    **10** |   **344.76 ns** |  **2.000 ns** | **1.871 ns** |  **1.00** |    **0.00** | **0.3633** |     **-** |     **-** |     **760 B** |
| Hyperlinq |    10 |   311.74 ns |  2.047 ns | 1.915 ns |  0.90 |    0.01 | 0.0763 |     - |     - |     160 B |
|           |       |             |           |          |       |         |        |       |       |           |
|      **Linq** |   **100** | **1,649.35 ns** | **10.476 ns** | **9.799 ns** |  **1.00** |    **0.00** | **0.3624** |     **-** |     **-** |     **760 B** |
| Hyperlinq |   100 | 1,157.62 ns |  7.961 ns | 6.648 ns |  0.70 |    0.01 | 0.0763 |     - |     - |     160 B |
