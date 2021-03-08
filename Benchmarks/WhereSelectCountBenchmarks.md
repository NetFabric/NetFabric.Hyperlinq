## WhereSelectCountBenchmarks

### Source
[WhereSelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSelectCountBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   350.6 ns |  1.76 ns |  1.65 ns |  1.00 |    0.00 | 0.0496 |     - |     - |     104 B |
|                     Hyperlinq_Array |                     Array |   100 |   185.4 ns |  0.64 ns |  0.56 ns |  0.53 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   208.7 ns |  0.57 ns |  0.53 ns |  0.60 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   235.4 ns |  0.69 ns |  0.61 ns |  0.67 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,294.6 ns |  4.13 ns |  3.45 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   271.9 ns |  1.40 ns |  1.17 ns |  0.21 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,306.4 ns |  4.39 ns |  3.89 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   278.0 ns |  1.46 ns |  1.37 ns |  0.21 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,304.3 ns |  6.10 ns |  5.41 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   728.3 ns |  2.34 ns |  2.18 ns |  0.56 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,045.1 ns | 13.08 ns | 10.92 ns |  1.00 |    0.00 | 0.0839 |     - |     - |     176 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 5,979.0 ns | 14.62 ns | 12.21 ns |  0.99 |    0.00 | 0.0992 |     - |     - |     216 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   874.9 ns |  3.15 ns |  2.95 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   588.4 ns |  2.12 ns |  1.65 ns |  0.67 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   868.3 ns |  5.41 ns |  5.06 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   597.1 ns |  2.42 ns |  2.26 ns |  0.69 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   888.1 ns |  3.56 ns |  3.15 ns |  1.00 |    0.00 | 0.0725 |     - |     - |     152 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   691.4 ns |  2.45 ns |  2.17 ns |  0.78 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 5,988.0 ns | 92.53 ns | 77.27 ns |  1.00 |    0.00 | 0.0839 |     - |     - |     176 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,261.3 ns | 31.48 ns | 27.91 ns |  1.05 |    0.02 | 0.1068 |     - |     - |     224 B |
