## List.ValueType.ListValueTypeSkipTakeWhere

### Source
[ListValueTypeSkipTakeWhere.cs](../LinqBenchmarks/List/ValueType/ListValueTypeSkipTakeWhere.cs)

### References:
- JM.LinqFaster: [1.1.2](https://www.nuget.org/packages/JM.LinqFaster/1.1.2)
- StructLinq.BCL: [0.19.1](https://www.nuget.org/packages/StructLinq.BCL/0.19.1)
- NetFabric.Hyperlinq: [3.0.0-beta23](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta23)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|      Method | Skip | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------ |----- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|     ForLoop | 1000 |   100 |   479.9 ns |  2.16 ns |  1.92 ns |  1.00 |    0.00 |      - |     - |     - |         - |
| ForeachLoop | 1000 |   100 | 4,315.7 ns | 26.07 ns | 23.11 ns |  8.99 |    0.04 | 0.0305 |     - |     - |      72 B |
|        Linq | 1000 |   100 | 1,578.2 ns | 14.83 ns | 13.15 ns |  3.29 |    0.03 | 0.1183 |     - |     - |     248 B |
|  LinqFaster | 1000 |   100 | 2,361.3 ns | 45.79 ns | 40.59 ns |  4.92 |    0.08 | 6.3133 |     - |     - |   13224 B |
|  StructLinq | 1000 |   100 | 1,461.2 ns | 14.77 ns | 12.33 ns |  3.05 |    0.03 | 0.0763 |     - |     - |     160 B |
|   Hyperlinq | 1000 |   100 |   706.2 ns |  3.10 ns |  2.90 ns |  1.47 |    0.01 |      - |     - |     - |         - |
