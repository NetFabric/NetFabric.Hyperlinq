## AnyPredicateBenchmarks

### Source
[AnyPredicateBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyPredicateBenchmarks.cs)

### References:
- Linq: 5.0.0-preview.7.20364.11
- System.Linq.Async: [4.1.1](https://www.nuget.org/packages/System.Linq.Async/4.1.1)
- System.Interactive: [4.1.1](https://www.nuget.org/packages/System.Interactive/4.1.1)
- System.Interactive.Async: [4.1.1](https://www.nuget.org/packages/System.Interactive.Async/4.1.1)
- StructLinq: [0.19.2](https://www.nuget.org/packages/StructLinq/0.19.2)
- NetFabric.Hyperlinq: [3.0.0-beta26](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta26)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19042
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=5.0.100-preview.7.20366.6
  [Host]        : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.0 (CoreCLR 5.0.20.36411, CoreFX 5.0.20.36411), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   526.73 ns |  2.931 ns |  2.598 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   193.47 ns |  1.524 ns |  1.425 ns |  0.37 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |   167.89 ns |  1.228 ns |  1.089 ns |  0.32 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |   217.39 ns |  0.976 ns |  0.815 ns |  0.41 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   740.01 ns |  7.295 ns |  6.467 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   200.01 ns |  0.951 ns |  0.843 ns |  0.27 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   742.85 ns |  5.958 ns |  5.282 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   234.82 ns |  1.307 ns |  1.159 ns |  0.32 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   747.75 ns | 11.674 ns | 10.920 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   406.47 ns |  1.352 ns |  1.199 ns |  0.54 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,251.51 ns |  8.144 ns |  7.220 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   100.02 ns |  0.776 ns |  0.688 ns |  0.04 | 0.0191 |     - |     - |      40 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   575.58 ns |  4.400 ns |  4.116 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   526.07 ns |  3.210 ns |  3.003 ns |  0.91 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   575.98 ns |  2.536 ns |  2.248 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   557.26 ns |  4.455 ns |  4.167 ns |  0.97 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   578.51 ns |  2.919 ns |  2.730 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   376.12 ns |  1.699 ns |  1.589 ns |  0.65 |      - |     - |     - |         - |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,136.81 ns | 14.388 ns | 13.459 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |    96.67 ns |  0.547 ns |  0.485 ns |  0.05 | 0.0305 |     - |     - |      64 B |
