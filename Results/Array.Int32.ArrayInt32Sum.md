## Array.Int32.ArrayInt32Sum

### Source
[ArrayInt32Sum.cs](../LinqBenchmarks/Array/Int32/ArrayInt32Sum.cs)

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
|                   Method | Count |         Mean |      Error |     StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|-------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     45.06 ns |   0.228 ns |   0.178 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|              ForeachLoop |   100 |     45.41 ns |   0.432 ns |   0.337 ns |   1.01 |    0.01 |      - |     - |     - |         - |
|                     Linq |   100 |    166.88 ns |   1.520 ns |   1.270 ns |   3.70 |    0.03 | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |     50.82 ns |   0.242 ns |   0.227 ns |   1.13 |    0.01 |      - |     - |     - |         - |
|          LinqFaster_SIMD |   100 |     11.42 ns |   0.046 ns |   0.043 ns |   0.25 |    0.00 |      - |     - |     - |         - |
|             LinqFasterer |   100 |     63.53 ns |   0.309 ns |   0.274 ns |   1.41 |    0.01 |      - |     - |     - |         - |
|                   LinqAF |   100 |    211.11 ns |   1.034 ns |   0.916 ns |   4.68 |    0.03 |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 20,580.88 ns | 216.848 ns | 169.301 ns | 456.74 |    3.33 | 7.6599 |     - |     - |  16,071 B |
|                  Streams |   100 |    259.41 ns |   2.164 ns |   2.025 ns |   5.75 |    0.04 | 0.0992 |     - |     - |     208 B |
|               StructLinq |   100 |     83.50 ns |   0.145 ns |   0.121 ns |   1.85 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     62.39 ns |   0.274 ns |   0.256 ns |   1.38 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |   100 |     21.80 ns |   0.255 ns |   0.238 ns |   0.48 |    0.00 |      - |     - |     - |         - |
