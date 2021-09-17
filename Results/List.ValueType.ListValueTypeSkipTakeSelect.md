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
- StructLinq.BCL: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.13.1, OS=macOS Catalina 10.15.7 (19H1417) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-rc.1.21458.32
  [Host]     : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.45113), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Skip | Count |      Mean |     Error |    StdDev |         Ratio | RatioSD |   Gen 0 |   Gen 1 | Allocated |
|------------------------- |----- |------ |----------:|----------:|----------:|--------------:|--------:|--------:|--------:|----------:|
|                  ForLoop | 1000 |   100 |  1.652 μs | 0.0027 μs | 0.0026 μs |      baseline |         |       - |       - |         - |
|                     Linq | 1000 |   100 |  2.333 μs | 0.0071 μs | 0.0066 μs |  1.41x slower |   0.00x |  0.1526 |       - |     320 B |
|               LinqFaster | 1000 |   100 |  4.974 μs | 0.0181 μs | 0.0151 μs |  3.01x slower |   0.01x |  9.2545 |       - |  19,368 B |
|             LinqFasterer | 1000 |   100 |  8.504 μs | 0.0773 μs | 0.0685 μs |  5.15x slower |   0.04x | 39.2151 |       - |  83,304 B |
|                   LinqAF | 1000 |   100 |  9.481 μs | 0.0139 μs | 0.0109 μs |  5.74x slower |   0.01x |       - |       - |         - |
|            LinqOptimizer | 1000 |   100 | 74.629 μs | 0.8551 μs | 0.7999 μs | 45.17x slower |   0.49x | 72.6318 | 18.0664 | 161,841 B |
|                 SpanLinq | 1000 |   100 |  2.251 μs | 0.0087 μs | 0.0077 μs |  1.36x slower |   0.01x |       - |       - |         - |
|                  Streams | 1000 |   100 | 11.351 μs | 0.0541 μs | 0.0480 μs |  6.87x slower |   0.04x |  0.5493 |       - |   1,176 B |
|               StructLinq | 1000 |   100 |  1.935 μs | 0.0017 μs | 0.0014 μs |  1.17x slower |   0.00x |  0.0572 |       - |     120 B |
| StructLinq_ValueDelegate | 1000 |   100 |  1.621 μs | 0.0033 μs | 0.0031 μs |  1.02x faster |   0.00x |       - |       - |         - |
|                Hyperlinq | 1000 |   100 |  1.925 μs | 0.0066 μs | 0.0061 μs |  1.17x slower |   0.00x |       - |       - |         - |
|  Hyperlinq_ValueDelegate | 1000 |   100 |  1.842 μs | 0.0045 μs | 0.0042 μs |  1.11x slower |   0.00x |       - |       - |         - |
