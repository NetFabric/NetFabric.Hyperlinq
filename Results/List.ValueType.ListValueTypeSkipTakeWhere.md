## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta24](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta24)

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
|     ForLoop | 1000 |   100 |    529.8 ns |  4.55 ns |  3.80 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 |  5,648.2 ns | 15.12 ns | 14.14 ns | 10.66 |    0.08 | 0.0305 |     - |     - |      72 B |
|        Linq | 1000 |   100 |  1,701.8 ns |  2.91 ns |  2.43 ns |  3.21 |    0.03 | 0.1183 |     - |     - |     248 B |
|  LinqFaster | 1000 |   100 |  2,621.2 ns | 26.83 ns | 23.78 ns |  4.94 |    0.06 | 6.3171 |     - |     - |   13224 B |
|      LinqAF | 1000 |   100 | 10,270.5 ns | 40.15 ns | 37.56 ns | 19.39 |    0.17 |      - |     - |     - |         - |
|  StructLinq | 1000 |   100 |  1,657.4 ns |  2.86 ns |  2.39 ns |  3.13 |    0.02 | 0.0763 |     - |     - |     160 B |
|   Hyperlinq | 1000 |   100 |    838.2 ns |  1.88 ns |  1.57 ns |  1.58 |    0.01 |      - |     - |     - |         - |
