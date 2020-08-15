## Array.ValueType.ArrayValueTypeSkipTakeWhere

### Source
[ArrayValueTypeSkipTakeWhere.cs](../LinqBenchmarks/Array/ValueType/ArrayValueTypeSkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- LinqAF: [1.0.0](https://www.nuget.org/packages/LinqAF/1.0.0)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta25](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta25)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=macOS Catalina 10.15.6 (19G73) [Darwin 19.6.0]
Intel Core i5-7360U CPU 2.30GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.6.20318.15
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.30506, CoreFX 5.0.20.30506), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |   520.2 ns |  0.48 ns |  0.40 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 | 3,252.6 ns |  4.73 ns |  3.95 ns |  6.25 |    0.01 | 0.0153 |     - |     - |      32 B |
|        Linq | 1000 |   100 | 1,803.5 ns |  4.26 ns |  3.56 ns |  3.47 |    0.01 | 0.1183 |     - |     - |     248 B |
|  LinqFaster | 1000 |   100 | 1,721.1 ns | 11.40 ns |  9.52 ns |  3.31 |    0.02 | 6.7329 |     - |     - |   14096 B |
|      LinqAF | 1000 |   100 | 5,739.0 ns | 16.25 ns | 15.20 ns | 11.03 |    0.03 |      - |     - |     - |         - |
|  StructLinq | 1000 |   100 | 1,752.1 ns |  4.61 ns |  4.31 ns |  3.37 |    0.01 | 0.0763 |     - |     - |     160 B |
|   Hyperlinq | 1000 |   100 |   839.6 ns |  1.28 ns |  1.00 ns |  1.61 |    0.00 |      - |     - |     - |         - |
