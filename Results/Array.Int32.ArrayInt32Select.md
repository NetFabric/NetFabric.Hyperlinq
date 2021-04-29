## Array.Int32.ArrayInt32Select

### Source
[ArrayInt32Select.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Select.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [](https://www.nuget.org/packages/LinqOptimizer.CSharp/)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1527-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.4 (5.0.421.11614), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |          Mean |         Error |        StdDev |    Ratio |  RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |--------------:|--------------:|--------------:|---------:|---------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |      56.34 ns |      0.312 ns |      0.292 ns |     1.00 |     0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |      57.61 ns |      0.211 ns |      0.187 ns |     1.02 |     0.01 |      - |     - |     - |         - |
|                     Linq |   100 |     453.74 ns |      1.594 ns |      1.413 ns |     8.05 |     0.06 | 0.0229 |     - |     - |      48 B |
|               LinqFaster |   100 |     244.11 ns |      1.715 ns |      1.339 ns |     4.34 |     0.03 | 0.2027 |     - |     - |     424 B |
|          LinqFaster_SIMD |   100 |     111.18 ns |      0.629 ns |      0.588 ns |     1.97 |     0.01 | 0.2027 |     - |     - |     424 B |
|             LinqFasterer |   100 |     411.34 ns |      0.992 ns |      0.879 ns |     7.30 |     0.04 | 0.2179 |     - |     - |     456 B |
|                   LinqAF |   100 |     471.58 ns |      1.056 ns |      0.882 ns |     8.37 |     0.04 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 230,437.36 ns | 16,378.395 ns | 45,926.774 ns | 4,095.33 | 1,125.37 |      - |     - |     - |  28,056 B |
|                  Streams |   100 |   1,300.83 ns |      5.677 ns |      5.032 ns |    23.09 |     0.14 | 0.2785 |     - |     - |     584 B |
|               StructLinq |   100 |     208.03 ns |      1.036 ns |      0.809 ns |     3.69 |     0.02 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     161.96 ns |      0.890 ns |      0.743 ns |     2.87 |     0.02 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     210.36 ns |      1.144 ns |      0.956 ns |     3.73 |     0.03 |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |     183.20 ns |      0.563 ns |      0.470 ns |     3.25 |     0.02 |      - |     - |     - |         - |
