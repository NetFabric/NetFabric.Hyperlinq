## List.ValueType.ListValueTypeDistinct

### Source
[ListValueTypeDistinct.cs](../LinqBenchmarks/List/ValueType/ListValueTypeDistinct.cs)

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
|                   Method | Duplicates | Count |      Mean |     Error |    StdDev | Ratio | RatioSD |   Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------- |----------- |------ |----------:|----------:|----------:|------:|--------:|--------:|------:|------:|----------:|
|                  ForLoop |          4 |   100 | 13.869 μs | 0.0567 μs | 0.0530 μs |  1.00 |    0.00 | 12.8174 |     - |     - |  26,976 B |
|              ForeachLoop |          4 |   100 | 14.400 μs | 0.0530 μs | 0.0496 μs |  1.04 |    0.01 | 12.8174 |     - |     - |  26,976 B |
|                     Linq |          4 |   100 | 17.243 μs | 0.0941 μs | 0.0880 μs |  1.24 |    0.01 | 12.8174 |     - |     - |  26,912 B |
|               LinqFaster |          4 |   100 |  3.065 μs | 0.0544 μs | 0.0482 μs |  0.22 |    0.00 |  0.0076 |     - |     - |      24 B |
|             LinqFasterer |          4 |   100 | 16.850 μs | 0.1146 μs | 0.1072 μs |  1.21 |    0.01 | 34.8816 |     - |     - |  73,168 B |
|                   LinqAF |          4 |   100 | 43.081 μs | 0.2159 μs | 0.1914 μs |  3.11 |    0.02 | 21.0571 |     - |     - |  44,120 B |
|               StructLinq |          4 |   100 | 15.587 μs | 0.0858 μs | 0.0803 μs |  1.12 |    0.01 |  0.0305 |     - |     - |      64 B |
| StructLinq_ValueDelegate |          4 |   100 |  5.099 μs | 0.0300 μs | 0.0281 μs |  0.37 |    0.00 |       - |     - |     - |         - |
|                Hyperlinq |          4 |   100 | 13.887 μs | 0.0531 μs | 0.0443 μs |  1.00 |    0.01 |       - |     - |     - |         - |
