## ContainsComparerBenchmarks

### Source
[ContainsComparerBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ContainsComparerBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |       Mean |    Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|--------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   634.7 ns |  3.41 ns | 3.19 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   223.9 ns |  0.98 ns | 0.87 ns |  0.35 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   222.5 ns |  1.17 ns | 0.91 ns |  0.35 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   224.6 ns |  0.89 ns | 0.79 ns |  0.35 |      - |     - |     - |         - |
|                                     |                           |       |            |          |         |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   801.0 ns |  2.06 ns | 1.82 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   762.8 ns |  4.55 ns | 4.04 ns |  0.95 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |         |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   818.3 ns |  4.62 ns | 4.10 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   824.5 ns |  4.28 ns | 4.00 ns |  1.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |         |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   800.2 ns |  2.67 ns | 2.23 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   652.0 ns |  2.02 ns | 1.58 ns |  0.81 |      - |     - |     - |         - |
|                                     |                           |       |            |          |         |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,205.6 ns |  5.55 ns | 4.92 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,156.6 ns |  7.99 ns | 7.48 ns |  0.98 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |         |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   575.1 ns |  2.34 ns | 2.07 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   576.2 ns |  3.17 ns | 2.81 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |         |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   573.1 ns |  3.04 ns | 2.85 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   581.5 ns |  4.02 ns | 3.76 ns |  1.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |         |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   577.1 ns |  3.05 ns | 2.70 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   650.9 ns |  1.57 ns | 1.39 ns |  1.13 |      - |     - |     - |         - |
|                                     |                           |       |            |          |         |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,056.8 ns | 10.74 ns | 9.52 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,046.8 ns |  5.44 ns | 4.82 ns |  1.00 | 0.0305 |     - |     - |      64 B |
