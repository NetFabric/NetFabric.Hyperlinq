## ValueTypeListSkipTakeWhere

### Source
[ValueTypeListSkipTakeWhere.cs](../LinqBenchmarks/ValueType/Array/ValueTypeListSkipTakeWhere.cs)

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
|     ForLoop | 1000 |   100 |    80.79 ns |  1.633 ns |  1.677 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 | 3,357.60 ns | 21.503 ns | 17.956 ns | 41.56 |    1.02 | 0.0191 |     - |     - |      40 B |
|        Linq | 1000 |   100 | 1,264.87 ns |  7.215 ns |  6.748 ns | 15.68 |    0.33 | 0.0725 |     - |     - |     152 B |
|   Hyperlinq | 1000 |   100 |   409.41 ns |  1.657 ns |  1.550 ns |  5.07 |    0.11 |      - |     - |     - |         - |
