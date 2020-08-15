## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

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
|      Method | Skip | Count |        Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |------------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |    531.5 ns |  0.26 ns |  0.21 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 |  5,819.9 ns | 12.08 ns | 11.30 ns | 10.95 |    0.02 | 0.0305 |     - |     - |      72 B |
|        Linq | 1000 |   100 |  1,717.4 ns |  4.47 ns |  3.96 ns |  3.23 |    0.01 | 0.1183 |     - |     - |     248 B |
|  LinqFaster | 1000 |   100 |  2,687.0 ns | 14.20 ns | 11.86 ns |  5.06 |    0.02 | 6.3171 |     - |     - |   13224 B |
|      LinqAF | 1000 |   100 | 10,280.5 ns | 16.56 ns | 13.83 ns | 19.34 |    0.03 |      - |     - |     - |         - |
|  StructLinq | 1000 |   100 |  1,676.9 ns |  2.79 ns |  2.47 ns |  3.15 |    0.01 | 0.0763 |     - |     - |     160 B |
|   Hyperlinq | 1000 |   100 |    839.1 ns |  2.24 ns |  1.87 ns |  1.58 |    0.00 |      - |     - |     - |         - |
