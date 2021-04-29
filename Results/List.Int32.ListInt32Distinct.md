## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

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
|                   Method | Duplicates | Count |       Mean |     Error |    StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |-----------:|----------:|----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 3,816.9 ns |  43.99 ns |  39.00 ns | 3,814.2 ns |  1.00 |    0.00 | 2.8610 |     - |     - |   6,000 B |
|              ForeachLoop |          4 |   100 | 3,819.4 ns |  18.34 ns |  16.26 ns | 3,823.8 ns |  1.00 |    0.01 | 2.8610 |     - |     - |   6,000 B |
|                     Linq |          4 |   100 | 6,066.8 ns |  36.42 ns |  32.29 ns | 6,061.9 ns |  1.59 |    0.01 | 2.8610 |     - |     - |   6,000 B |
|               LinqFaster |          4 |   100 |   610.0 ns |   2.99 ns |   2.50 ns |   610.3 ns |  0.16 |    0.00 |      - |     - |     - |         - |
|                   LinqAF |          4 |   100 | 9,886.3 ns | 195.60 ns | 357.67 ns | 9,696.7 ns |  2.69 |    0.11 | 5.9204 |     - |     - |  12,400 B |
|               StructLinq |          4 |   100 | 3,442.0 ns |  12.67 ns |  11.23 ns | 3,441.1 ns |  0.90 |    0.01 | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |          4 |   100 | 3,352.1 ns |  22.60 ns |  20.03 ns | 3,345.7 ns |  0.88 |    0.01 |      - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 3,553.7 ns |  21.35 ns |  19.97 ns | 3,551.1 ns |  0.93 |    0.01 |      - |     - |     - |         - |
