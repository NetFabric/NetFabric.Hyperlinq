## List.ValueType.ListValueTypeWhereSelect

### Source
[ListValueTypeWhereSelect.cs](../LinqBenchmarks/List/ValueType/ListValueTypeWhereSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqFaster.SIMD: [1.1.2](https://www.nuget.org/packages/LinqFaster.SIMD/1.0.3)
- LinqFasterer: [2.1.0](https://www.nuget.org/packages/LinqFasterer/2.1.0)
- LinqAF: [3.0.0.0](https://www.nuget.org/packages/LinqAF/3.0.0.0)
- LinqOptimizer.CSharp: [0.7.0](https://www.nuget.org/packages/LinqOptimizer.CSharp/0.7.0)
- SpanLinq: [1.0.0](https://www.nuget.org/packages/SpanLinq/1.0.0)
- Streams.CSharp: [0.6.0](https://www.nuget.org/packages/Streams.CSharp/0.6.0)
- StructLinq.BCL: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1538-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |      Mean |     Error |    StdDev |    Median | Ratio | RatioSD |   Gen 0 |   Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |----------:|----------:|----------:|----------:|------:|--------:|--------:|--------:|------:|----------:|
|                  ForLoop |   100 |  1.028 μs | 0.0041 μs | 0.0036 μs |  1.028 μs |  1.00 |    0.00 |       - |       - |     - |         - |
|              ForeachLoop |   100 |  1.207 μs | 0.0043 μs | 0.0036 μs |  1.207 μs |  1.17 |    0.01 |       - |       - |     - |         - |
|                     Linq |   100 |  1.930 μs | 0.0141 μs | 0.0132 μs |  1.926 μs |  1.88 |    0.01 |  0.1793 |       - |     - |     376 B |
|               LinqFaster |   100 |  3.636 μs | 0.0238 μs | 0.0222 μs |  3.630 μs |  3.54 |    0.03 |  3.8605 |       - |     - |   8,088 B |
|             LinqFasterer |   100 |  2.681 μs | 0.0534 μs | 0.1557 μs |  2.603 μs |  2.67 |    0.15 |  6.4087 |       - |     - |  13,416 B |
|                   LinqAF |   100 |  2.776 μs | 0.0235 μs | 0.0208 μs |  2.777 μs |  2.70 |    0.02 |       - |       - |     - |         - |
|            LinqOptimizer |   100 | 72.815 μs | 1.0911 μs | 0.9111 μs | 72.741 μs | 70.83 |    0.93 | 65.1855 | 17.8223 |     - | 157,309 B |
|                  Streams |   100 |  7.128 μs | 0.0480 μs | 0.0425 μs |  7.119 μs |  6.94 |    0.05 |  0.4730 |       - |     - |   1,000 B |
|               StructLinq |   100 |  1.256 μs | 0.0047 μs | 0.0042 μs |  1.256 μs |  1.22 |    0.00 |  0.0343 |       - |     - |      72 B |
| StructLinq_ValueDelegate |   100 |  1.130 μs | 0.0063 μs | 0.0056 μs |  1.129 μs |  1.10 |    0.01 |       - |       - |     - |         - |
|                Hyperlinq |   100 |  1.563 μs | 0.0083 μs | 0.0073 μs |  1.563 μs |  1.52 |    0.01 |       - |       - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |  1.294 μs | 0.0074 μs | 0.0069 μs |  1.293 μs |  1.26 |    0.01 |       - |       - |     - |         - |
