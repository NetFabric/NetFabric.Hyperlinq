## SelectToArrayBenchmarks

### Source
[SelectToArrayBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectToArrayBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |     Error |    StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|----------:|----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   218.37 ns |  0.777 ns |  0.689 ns |  1.00 | 0.2255 |     - |     - |     472 B |
|                    StructLinq_Array |                     Array |   100 |   202.86 ns |  0.536 ns |  0.475 ns |  0.93 | 0.2027 |     - |     - |     424 B |
|                LinqFasterSIMD_Array |                     Array |   100 |    60.50 ns |  0.588 ns |  0.521 ns |  0.28 | 0.2027 |     - |     - |     424 B |
|                     Hyperlinq_Array |                     Array |   100 |   224.01 ns |  0.614 ns |  0.544 ns |  1.03 | 0.2027 |     - |     - |     424 B |
|                      Hyperlinq_Span |                     Array |   100 |   220.48 ns |  0.517 ns |  0.459 ns |  1.01 | 0.2027 |     - |     - |     424 B |
|                 Hyperlinq_Span_SIMD |                     Array |   100 |    83.63 ns |  0.475 ns |  0.444 ns |  0.38 | 0.2027 |     - |     - |     424 B |
|                    Hyperlinq_Memory |                     Array |   100 |   205.19 ns |  0.535 ns |  0.474 ns |  0.94 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 | 1,061.61 ns |  5.401 ns |  5.052 ns |  1.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 | 1,015.27 ns |  2.714 ns |  2.539 ns |  0.96 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   592.61 ns |  2.300 ns |  1.921 ns |  0.56 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 | 1,110.86 ns |  5.239 ns |  4.644 ns |  1.00 | 0.5913 |     - |     - |    1240 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 | 1,042.22 ns |  3.429 ns |  3.207 ns |  0.94 | 0.2174 |     - |     - |     456 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   353.91 ns |  1.729 ns |  1.617 ns |  0.32 | 0.2027 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   458.50 ns |  1.027 ns |  0.911 ns |  1.00 | 0.2294 |     - |     - |     480 B |
|               StructLinq_List_Value |                List_Value |   100 |   441.10 ns |  1.118 ns |  0.991 ns |  0.96 | 0.2027 |     - |     - |     424 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   696.29 ns |  1.633 ns |  1.528 ns |  1.52 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,885.74 ns | 29.711 ns | 26.338 ns |  1.00 | 0.7935 |     - |     - |    1680 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 9,265.66 ns | 21.819 ns | 19.342 ns |  1.04 | 0.8087 |     - |     - |    1712 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   810.75 ns |  7.108 ns |  6.648 ns |  1.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   830.35 ns |  2.574 ns |  2.282 ns |  1.02 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   921.03 ns |  1.969 ns |  1.644 ns |  1.13 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   803.69 ns |  2.578 ns |  2.412 ns |  1.00 | 0.5922 |     - |     - |    1240 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   860.91 ns |  1.918 ns |  1.701 ns |  1.07 | 0.2174 |     - |     - |     456 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   595.25 ns |  2.095 ns |  1.857 ns |  0.74 | 0.2174 |     - |     - |     456 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   409.95 ns |  1.539 ns |  1.364 ns |  1.00 | 0.2294 |     - |     - |     480 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   859.42 ns |  2.938 ns |  2.453 ns |  2.10 | 0.2174 |     - |     - |     456 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   718.73 ns |  1.751 ns |  1.552 ns |  1.75 | 0.2022 |     - |     - |     424 B |
|                                     |                           |       |             |           |           |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,963.73 ns | 48.719 ns | 43.188 ns |  1.00 | 0.7935 |     - |     - |    1680 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 9,444.31 ns | 25.266 ns | 22.397 ns |  1.05 | 0.8240 |     - |     - |    1728 B |
