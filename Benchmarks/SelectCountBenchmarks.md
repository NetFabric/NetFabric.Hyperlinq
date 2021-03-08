## SelectCountBenchmarks

### Source
[SelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectCountBenchmarks.cs)

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
|                              Method |                Categories | Count |         Mean |      Error |     StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|-----------:|-----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   209.920 ns |  0.6620 ns |  0.5528 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |    10.517 ns |  0.0277 ns |  0.0246 ns |  0.05 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    15.894 ns |  0.0671 ns |  0.0628 ns |  0.08 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |    15.676 ns |  0.0344 ns |  0.0322 ns |  0.07 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |    16.197 ns |  0.0431 ns |  0.0382 ns |  0.08 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   838.314 ns |  8.9948 ns |  7.9737 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   840.435 ns |  3.1482 ns |  2.9449 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   150.865 ns |  0.2568 ns |  0.2403 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   837.494 ns |  6.5789 ns |  6.1539 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   822.768 ns |  1.5705 ns |  1.3922 ns |  0.98 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    16.855 ns |  0.0366 ns |  0.0306 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   408.705 ns |  2.5574 ns |  2.1355 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|               StructLinq_List_Value |                List_Value |   100 |    10.544 ns |  0.0367 ns |  0.0344 ns |  0.03 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     9.834 ns |  0.0593 ns |  0.0554 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,119.741 ns | 38.6211 ns | 34.2366 ns |  1.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,056.003 ns | 39.7531 ns | 37.1851 ns |  0.99 | 0.0610 |     - |     - |     144 B |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   575.996 ns |  3.0140 ns |  2.6718 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   604.944 ns |  3.0974 ns |  2.7458 ns |  1.05 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   272.668 ns |  1.3281 ns |  1.2423 ns |  0.47 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   624.120 ns |  2.9442 ns |  2.4586 ns | 1.000 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   605.562 ns |  2.0432 ns |  1.8113 ns | 0.970 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     4.430 ns |  0.0248 ns |  0.0207 ns | 0.007 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   454.141 ns |  1.7165 ns |  1.4334 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   601.366 ns |  2.1509 ns |  1.7961 ns |  1.32 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     9.978 ns |  0.0558 ns |  0.0495 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,401.558 ns | 34.6861 ns | 32.4454 ns |  1.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,069.331 ns | 31.3409 ns | 29.3163 ns |  0.96 | 0.0610 |     - |     - |     152 B |
