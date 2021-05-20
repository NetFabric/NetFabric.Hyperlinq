## Array.ValueType.ArrayValueTypeSelectSum

### Source
[ArrayValueTypeSelectSum.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSelectSum.cs)

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

BenchmarkDotNet=v0.13.0, OS=Windows 10.0.19043.985 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21227.6
  [Host] : .NET 5.0.6 (5.0.621.22011), X64 RyuJIT
  .NET 6 : .NET 6.0.0 (6.0.21.22210), X64 RyuJIT

Job=.NET 6  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|                   Method | Count |         Mean |      Error |     StdDev |          Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |------ |-------------:|-----------:|-----------:|---------------:|--------:|-------:|------:|------:|----------:|
|                  ForLoop |   100 |     77.07 ns |   0.359 ns |   0.318 ns |       baseline |         |      - |     - |     - |         - |
|              ForeachLoop |   100 |    151.96 ns |   1.154 ns |   1.079 ns |   1.97x slower |   0.02x |      - |     - |     - |         - |
|                     Linq |   100 |    596.10 ns |   9.338 ns |   8.278 ns |   7.73x slower |   0.12x | 0.0153 |     - |     - |      32 B |
|               LinqFaster |   100 |    344.48 ns |   1.118 ns |   0.991 ns |   4.47x slower |   0.02x |      - |     - |     - |         - |
|             LinqFasterer |   100 |    229.55 ns |   2.033 ns |   1.697 ns |   2.98x slower |   0.03x |      - |     - |     - |         - |
|                   LinqAF |   100 |    724.28 ns |  14.388 ns |  17.670 ns |   9.44x slower |   0.23x |      - |     - |     - |         - |
|            LinqOptimizer |   100 | 31,458.07 ns | 231.957 ns | 193.694 ns | 408.13x slower |   3.46x | 9.0332 |     - |     - |  18,930 B |
|                  Streams |   100 |    659.98 ns |   4.813 ns |   4.019 ns |   8.56x slower |   0.06x | 0.1717 |     - |     - |     360 B |
|               StructLinq |   100 |    213.60 ns |   1.160 ns |   1.085 ns |   2.77x slower |   0.02x | 0.0153 |     - |     - |      32 B |
| StructLinq_ValueDelegate |   100 |     86.20 ns |   0.717 ns |   0.636 ns |   1.12x slower |   0.01x |      - |     - |     - |         - |
|                Hyperlinq |   100 |    501.03 ns |   5.761 ns |   5.107 ns |   6.50x slower |   0.07x |      - |     - |     - |         - |
|  Hyperlinq_ValueDelegate |   100 |    346.79 ns |   1.437 ns |   1.200 ns |   4.50x slower |   0.03x |      - |     - |     - |         - |
