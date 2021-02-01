## RepeatBenchmarks

### Source
[RepeatBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/RepeatBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta29](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta29)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                 Method |   Categories | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|----------------------- |------------- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|            Linq_Repeat |       Repeat |   100 |   411.33 ns | 0.895 ns | 0.793 ns |     ? |       ? | 0.0191 |     - |     - |      40 B |
|                        |              |       |             |          |          |       |         |        |       |       |           |
|      Linq_Repeat_Count | Repeat_Count |   100 |   395.45 ns | 0.913 ns | 0.809 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_Repeat_Count | Repeat_Count |   100 |    39.67 ns | 0.053 ns | 0.047 ns |  0.10 |    0.00 |      - |     - |     - |         - |
|                        |              |       |             |          |          |       |         |        |       |       |           |
|      Linq_Repeat_Async | Repeat_Async |   100 | 5,712.92 ns | 8.605 ns | 8.049 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
| Hyperlinq_Repeat_Async | Repeat_Async |   100 |   921.54 ns | 4.343 ns | 3.391 ns |  0.16 |    0.00 |      - |     - |     - |         - |
