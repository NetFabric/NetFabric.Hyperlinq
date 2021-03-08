## AllBenchmarks

### Source
[AllBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AllBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   610.9 ns |  3.87 ns |  3.62 ns |   609.9 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   197.4 ns |  1.22 ns |  1.08 ns |   197.0 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   202.8 ns |  4.08 ns |  6.82 ns |   199.5 ns |  0.33 |    0.01 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   198.2 ns |  0.89 ns |  0.83 ns |   198.2 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   761.1 ns |  2.12 ns |  1.77 ns |   760.9 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   209.2 ns |  3.16 ns |  2.95 ns |   207.9 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   758.5 ns |  5.27 ns |  4.40 ns |   756.9 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   212.5 ns |  1.19 ns |  1.05 ns |   212.1 ns |  0.28 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   723.9 ns |  2.19 ns |  2.05 ns |   724.1 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 | 1,025.3 ns |  4.39 ns |  4.11 ns | 1,026.5 ns |  1.42 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,204.6 ns |  9.65 ns |  8.55 ns | 2,207.1 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   326.1 ns |  2.18 ns |  1.93 ns |   325.6 ns |  0.15 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   542.3 ns | 10.73 ns | 13.17 ns |   535.4 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   558.7 ns |  1.97 ns |  1.85 ns |   559.2 ns |  1.04 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   531.7 ns |  2.15 ns |  1.91 ns |   531.1 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   560.2 ns |  2.47 ns |  2.19 ns |   560.3 ns |  1.05 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   563.6 ns |  7.16 ns |  6.34 ns |   563.4 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   938.8 ns |  2.77 ns |  2.46 ns |   938.9 ns |  1.67 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,124.7 ns | 40.26 ns | 35.69 ns | 2,111.4 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |   353.8 ns |  0.80 ns |  0.75 ns |   353.7 ns |  0.17 |    0.00 | 0.0191 |     - |     - |      40 B |
