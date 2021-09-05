## RepeatToArrayBenchmarks

### Source
[RepeatToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatToArrayBenchmarks.cs)

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
|          Method |   Categories | Count |      Mean |    Error |   StdDev |        Ratio | RatioSD |  Gen 0 | Allocated |
|---------------- |------------- |------ |----------:|---------:|---------:|-------------:|--------:|-------:|----------:|
|            Linq |       Repeat |   100 |  48.20 ns | 0.986 ns | 1.923 ns |     baseline |         | 0.2180 |     456 B |
|      StructLinq |       Repeat |   100 |  87.02 ns | 0.783 ns | 0.694 ns | 1.72x slower |   0.06x | 0.2142 |     448 B |
| LinqFaster_SIMD |       Repeat |   100 |  40.09 ns | 0.580 ns | 0.542 ns | 1.25x faster |   0.05x | 0.2027 |     424 B |
|       Hyperlinq |       Repeat |   100 |  42.98 ns | 0.979 ns | 1.690 ns | 1.12x faster |   0.05x | 0.2027 |     424 B |
|  Hyperlinq_SIMD |       Repeat |   100 |  51.60 ns | 1.154 ns | 1.830 ns | 1.07x slower |   0.03x | 0.2027 |     424 B |
|                 |              |       |           |          |          |              |         |        |           |
|      Linq_Async | Repeat_Async |   100 | 120.20 ns | 1.425 ns | 1.333 ns |     baseline |         | 0.2255 |     472 B |
| Hyperlinq_Async | Repeat_Async |   100 | 146.16 ns | 2.165 ns | 2.025 ns | 1.22x slower |   0.03x | 0.2027 |     424 B |
