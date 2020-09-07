## WhereCountBenchmarks

### Source
[WhereCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereCountBenchmarks.cs)

### References:
- Linq: 4.8.4180.0
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.3](https://www.nuget.org/packages/StructLinq/0.19.3)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
  [Host]        : .NET Framework 4.8 (4.8.4180.0), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.40711, CoreFX 5.0.20.40711), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 | 1,098.5 ns | 21.58 ns | 20.18 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|                    StructLinq_Array |                     Array |   100 |   285.7 ns |  5.72 ns | 11.16 ns |  0.26 |    0.01 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |   204.7 ns |  3.86 ns |  3.97 ns |  0.19 |    0.00 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   177.6 ns |  1.55 ns |  1.37 ns |  0.16 |    0.00 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   207.3 ns |  2.41 ns |  2.26 ns |  0.19 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,631.0 ns | 31.33 ns | 32.17 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,224.7 ns | 22.92 ns | 20.31 ns |  0.75 |    0.02 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   275.2 ns |  2.38 ns |  2.11 ns |  0.17 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,657.9 ns | 29.48 ns | 28.95 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,206.2 ns | 14.54 ns | 12.15 ns |  0.73 |    0.02 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   213.4 ns |  1.59 ns |  1.24 ns |  0.13 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 | 1,246.1 ns | 10.07 ns |  8.41 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|               StructLinq_List_Value |                List_Value |   100 | 1,205.7 ns | 15.66 ns | 13.88 ns |  0.97 |    0.01 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   398.5 ns |  3.11 ns |  2.60 ns |  0.32 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,283.6 ns | 21.63 ns | 19.17 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,096.6 ns | 37.32 ns | 29.14 ns |  2.68 |    0.02 | 0.0610 |     - |     - |     136 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   829.8 ns | 14.18 ns | 11.84 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   745.8 ns |  5.45 ns |  4.25 ns |  0.90 |    0.02 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   611.6 ns |  4.94 ns |  4.38 ns |  0.74 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   815.9 ns |  5.02 ns |  4.19 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   792.4 ns | 15.57 ns | 15.29 ns |  0.97 |    0.02 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   611.1 ns | 11.15 ns |  9.89 ns |  0.75 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   817.2 ns | 11.22 ns |  9.95 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   755.0 ns |  6.17 ns |  5.47 ns |  0.92 |    0.02 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   400.1 ns |  3.32 ns |  2.94 ns |  0.49 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,168.0 ns | 11.60 ns | 10.28 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,358.9 ns | 46.26 ns | 41.01 ns |  2.93 |    0.03 | 0.0687 |     - |     - |     152 B |
