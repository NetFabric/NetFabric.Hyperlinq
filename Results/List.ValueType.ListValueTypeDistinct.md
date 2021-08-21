## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev |        Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|-------------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 12.370 μs | 0.0181 μs | 0.0169 μs |     baseline |         | 12.8784 |     - |     - |  26,976 B |
|              ForeachLoop |          4 |   100 | 13.397 μs | 0.0168 μs | 0.0141 μs | 1.08x slower |   0.00x | 12.8784 |     - |     - |  26,976 B |
|                     Linq |          4 |   100 | 15.083 μs | 0.0218 μs | 0.0193 μs | 1.22x slower |   0.00x | 12.8174 |     - |     - |  26,912 B |
|               LinqFaster |          4 |   100 |  2.792 μs | 0.0014 μs | 0.0011 μs | 4.43x faster |   0.01x |  0.0114 |     - |     - |      24 B |
|             LinqFasterer |          4 |   100 | 17.228 μs | 0.1209 μs | 0.1131 μs | 1.39x slower |   0.01x | 34.8816 |     - |     - |  73,168 B |
|                   LinqAF |          4 |   100 | 38.352 μs | 0.0902 μs | 0.0704 μs | 3.10x slower |   0.01x | 20.9961 |     - |     - |  43,944 B |
|               StructLinq |          4 |   100 | 13.138 μs | 0.0082 μs | 0.0077 μs | 1.06x slower |   0.00x |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.081 μs | 0.0045 μs | 0.0042 μs | 2.43x faster |   0.00x |       - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 13.089 μs | 0.0104 μs | 0.0092 μs | 1.06x slower |   0.00x |       - |     - |     - |         - |
