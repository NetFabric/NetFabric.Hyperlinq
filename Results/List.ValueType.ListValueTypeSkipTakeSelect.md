## List.ValueType.ListValueTypeSkipTakeSelect

### Source
[ListValueTypeSkipTakeSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeSelect.cs)

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
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|-------:|------:|----------:|
|                  ForLoop | 1000 |   100 |  1.651 μs | 0.0009 μs | 0.0007 μs |      baseline |         |       - |      - |     - |         - |
|                     Linq | 1000 |   100 |  2.331 μs | 0.0013 μs | 0.0011 μs |  1.41x slower |   0.00x |  0.1526 |      - |     - |     320 B |
|               LinqFaster | 1000 |   100 |  4.950 μs | 0.0083 μs | 0.0073 μs |  3.00x slower |   0.01x |  9.2545 |      - |     - |  19,368 B |
|             LinqFasterer | 1000 |   100 |  8.499 μs | 0.0877 μs | 0.0733 μs |  5.15x slower |   0.04x | 39.2151 |      - |     - |  83,304 B |
|                   LinqAF | 1000 |   100 |  9.485 μs | 0.0162 μs | 0.0152 μs |  5.75x slower |   0.01x |       - |      - |     - |         - |
|            LinqOptimizer | 1000 |   100 | 73.181 μs | 0.4503 μs | 0.3760 μs | 44.32x slower |   0.23x | 76.7822 | 0.1221 |     - | 161,846 B |
|                 SpanLinq | 1000 |   100 |  2.245 μs | 0.0009 μs | 0.0008 μs |  1.36x slower |   0.00x |       - |      - |     - |         - |
|                  Streams | 1000 |   100 | 11.555 μs | 0.0250 μs | 0.0234 μs |  7.00x slower |   0.01x |  0.5493 |      - |     - |   1,176 B |
|               StructLinq | 1000 |   100 |  1.906 μs | 0.0008 μs | 0.0007 μs |  1.15x slower |   0.00x |  0.0572 |      - |     - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.619 μs | 0.0003 μs | 0.0003 μs |  1.02x faster |   0.00x |       - |      - |     - |         - |
|                Hyperlinq | 1000 |   100 |  1.925 μs | 0.0011 μs | 0.0010 μs |  1.17x slower |   0.00x |       - |      - |     - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.842 μs | 0.0062 μs | 0.0055 μs |  1.12x slower |   0.00x |       - |      - |     - |         - |
