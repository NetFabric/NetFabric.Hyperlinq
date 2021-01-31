## IterationBenchmarks

### Source
[IterationBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/IterationBenchmarks.cs)

### References:
- Linq: 4.8.4300.0
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.19.3](https://www.nuget.org/packages/StructLinq/0.19.3)
- NetFabric.Hyperlinq: [3.0.0-beta28](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta28)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4300.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.2 (CoreCLR 5.0.220.61120, CoreFX 5.0.220.61120), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
| Method |     Count |     Mean |    Error |   StdDev | Ratio | RatioSD |
|------- |---------- |---------:|---------:|---------:|------:|--------:|
|     LT | 100000000 | 37.93 ms | 3.088 ms | 9.106 ms |  1.00 |    0.00 |
|    LTE | 100000000 | 28.49 ms | 0.386 ms | 0.361 ms |  0.61 |    0.03 |
