## Int32ListSkipTakeWhere

### Source
[Int32ListSkipTakeWhere.cs](../LinqBenchmarks/Int32/List/Int32ListSkipTakeWhere.cs)

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
|      Method | Skip | Count |        Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |    84.81 ns |  0.664 ns |  0.588 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 | 3,624.36 ns | 15.341 ns | 11.978 ns | 42.76 |    0.36 | 0.0191 |     - |     - |      40 B |
|        Linq | 1000 |   100 | 1,262.19 ns |  7.741 ns |  7.241 ns | 14.88 |    0.13 | 0.0725 |     - |     - |     152 B |
|   Hyperlinq | 1000 |   100 |   405.58 ns |  1.542 ns |  1.287 ns |  4.78 |    0.04 |      - |     - |     - |         - |
