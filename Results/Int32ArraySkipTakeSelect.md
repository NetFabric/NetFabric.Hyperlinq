## Int32ArraySkipTakeSelect

### Source
[Int32ArraySkipTakeSelect.cs](../LinqBenchmarks/Int32/Array/Int32ArraySkipTakeSelect.cs)

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
|           ForLoop | 1000 |   100 |    54.02 ns |  0.484 ns |  0.453 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|       ForeachLoop | 1000 |   100 | 2,326.50 ns | 43.565 ns | 40.751 ns | 43.07 |    0.99 | 0.0153 |     - |     - |      32 B |
|              Linq | 1000 |   100 |   964.04 ns | 11.538 ns | 10.793 ns | 17.85 |    0.22 | 0.0725 |     - |     - |     152 B |
|        LinqFaster | 1000 |   100 |   274.35 ns |  2.431 ns |  2.274 ns |  5.08 |    0.06 | 0.2027 |     - |     - |     424 B |
| Hyperlinq_Foreach | 1000 |   100 |   266.65 ns |  5.060 ns |  8.994 ns |  4.95 |    0.14 |      - |     - |     - |         - |
|     Hyperlinq_For | 1000 |   100 |   462.72 ns |  3.691 ns |  3.082 ns |  8.57 |    0.09 |      - |     - |     - |         - |
