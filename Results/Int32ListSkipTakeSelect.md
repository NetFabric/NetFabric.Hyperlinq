## Int32ListSkipTakeSelect

### Source
[Int32ListSkipTakeSelect.cs](../LinqBenchmarks/Int32/List/Int32ListSkipTakeSelect.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.1.9](https://www.nuget.org/packages/StructLinq.BCL/0.1.9)
- NetFabric.Hyperlinq: [3.0.0-beta19](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta19)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|            Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------ |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|           ForLoop | 1000 |   100 |    71.69 ns |  0.508 ns |  0.424 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 3,503.76 ns | 16.883 ns | 14.966 ns | 48.87 |    0.30 | 0.0191 |     - |     - |      40 B |
|              Linq | 1000 |   100 |   912.80 ns |  3.564 ns |  3.159 ns | 12.73 |    0.09 | 0.0725 |     - |     - |     152 B |
| Hyperlinq_Foreach | 1000 |   100 |   316.80 ns |  1.405 ns |  1.246 ns |  4.42 |    0.03 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 |   475.23 ns |  3.701 ns |  3.461 ns |  6.64 |    0.05 |      - |     - |     - |         - |
