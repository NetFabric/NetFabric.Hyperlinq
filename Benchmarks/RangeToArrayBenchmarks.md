## RangeToArrayBenchmarks

### Source
[RangeToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RangeToArrayBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.7.21377.19
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.27.0](https://www.nuget.org/packages/StructLinq/0.27.0)
- NetFabric.Hyperlinq: [3.0.0-beta45](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta45)

### Results:
``` ini

BenchmarkDotNet=v0.13.1.1606-nightly, OS=macOS Catalina 10.15.7 (19H1323) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.7.21379.14
  [Host]     : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT
  .NET 6 PGO : .NET 6.0.0 (6.0.21.37719), X64 RyuJIT

Job=.NET 6 PGO  EnvironmentVariables=COMPlus_ReadyToRun=0,COMPlus_TC_QuickJitForLoops=1,COMPlus_TieredPGO=1  Runtime=.NET 6.0  

```
|          Method |  Categories | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|---------------- |------------ |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|            Linq |       Range |   100 |  98.10 ns | 0.503 ns | 0.393 ns |     baseline |         | 0.2217 |     464 B |
|      StructLinq |       Range |   100 | 106.79 ns | 2.013 ns | 1.785 ns | 1.09x slower |   0.02x | 0.2142 |     448 B |
| LinqFaster_SIMD |       Range |   100 |  46.08 ns | 0.330 ns | 0.292 ns | 2.13x faster |   0.02x | 0.2027 |     424 B |
|       Hyperlinq |       Range |   100 |  52.06 ns | 0.499 ns | 0.417 ns | 1.88x faster |   0.02x | 0.2027 |     424 B |
|                 |             |       |           |          |          |              |         |        |           |
|      Linq_Async | Range_Async |   100 | 129.59 ns | 1.059 ns | 0.884 ns |     baseline |         | 0.2255 |     472 B |
| Hyperlinq_Async | Range_Async |   100 | 166.08 ns | 1.368 ns | 1.213 ns | 1.28x slower |   0.01x | 0.2027 |     424 B |
