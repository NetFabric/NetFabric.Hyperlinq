## List.Int32.ListInt32Distinct

### Source
[ListInt32Distinct.cs](../LinqBenchmarks/List/Int32/ListInt32Distinct.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [0.0.1](https://www.nuget.org/packages/SpanLinq/0.0.1)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.0, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Duplicates | Count |       Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |-----------:|---------:|---------:|-------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 3,422.0 ns | 16.67 ns | 15.59 ns |     baseline |         | 2.8687 |     - |     - |   6,000 B |
|              ForeachLoop |          4 |   100 | 3,491.0 ns | 10.28 ns |  9.61 ns | 1.02x slower |   0.00x | 2.8687 |     - |     - |   6,000 B |
|                     Linq |          4 |   100 | 4,368.2 ns |  7.31 ns |  6.48 ns | 1.28x slower |   0.01x | 2.8687 |     - |     - |   6,000 B |
|               LinqFaster |          4 |   100 |   706.3 ns |  0.93 ns |  0.82 ns | 4.85x faster |   0.02x |      - |     - |     - |         - |
|             LinqFasterer |          4 |   100 | 4,297.5 ns | 26.83 ns | 23.79 ns | 1.26x slower |   0.01x | 5.2032 |     - |     - |  10,896 B |
|                   LinqAF |          4 |   100 | 7,358.6 ns | 20.14 ns | 18.84 ns | 2.15x slower |   0.01x | 5.9280 |     - |     - |  12,400 B |
|               StructLinq |          4 |   100 | 3,800.2 ns |  1.37 ns |  1.21 ns | 1.11x slower |   0.00x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |          4 |   100 | 3,816.9 ns |  1.65 ns |  1.38 ns | 1.11x slower |   0.00x |      - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 3,461.0 ns |  2.43 ns |  2.15 ns | 1.01x slower |   0.00x |      - |     - |     - |         - |
