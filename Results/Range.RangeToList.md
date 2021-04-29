## Range.RangeToList

### Source
[RangeToList.cs](../LinqBenchmarks/Range/RangeToList.cs)

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
|     Method | Start | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------- |------ |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|    ForLoop |     0 |   100 | 309.44 ns | 6.279 ns | 8.383 ns |  1.00 |    0.00 | 0.5660 |     - |     - |   1,184 B |
|       Linq |     0 |   100 | 200.14 ns | 0.916 ns | 0.812 ns |  0.63 |    0.01 | 0.2370 |     - |     - |     496 B |
| LinqFaster |     0 |   100 | 141.41 ns | 2.908 ns | 5.243 ns |  0.46 |    0.03 | 0.4206 |     - |     - |     880 B |
|     LinqAF |     0 |   100 | 276.37 ns | 2.130 ns | 1.992 ns |  0.88 |    0.02 | 0.2179 |     - |     - |     456 B |
| StructLinq |     0 |   100 |  94.15 ns | 1.123 ns | 1.050 ns |  0.30 |    0.01 | 0.2180 |     - |     - |     456 B |
|  Hyperlinq |     0 |   100 |  62.36 ns | 1.322 ns | 2.135 ns |  0.20 |    0.01 | 0.2180 |     - |     - |     456 B |
