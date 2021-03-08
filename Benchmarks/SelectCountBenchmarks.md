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
|                          Linq_Array |                     Array |   100 |   198.220 ns |  0.6773 ns |  0.6336 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |    10.184 ns |  0.0197 ns |  0.0164 ns |  0.05 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    15.412 ns |  0.0319 ns |  0.0283 ns |  0.08 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   790.965 ns |  2.4941 ns |  2.2110 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   761.327 ns |  2.2745 ns |  1.7758 ns |  0.96 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   146.856 ns |  0.2308 ns |  0.2046 ns |  0.19 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   791.787 ns |  2.1413 ns |  1.8982 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   806.411 ns |  3.3071 ns |  2.9317 ns |  1.02 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    16.205 ns |  0.0335 ns |  0.0314 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   388.335 ns |  1.5311 ns |  1.4322 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|               StructLinq_List_Value |                List_Value |   100 |    10.448 ns |  0.0232 ns |  0.0206 ns |  0.03 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     9.561 ns |  0.0320 ns |  0.0283 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 8,558.331 ns | 30.3258 ns | 28.3667 ns |  1.00 | 0.0458 |     - |     - |     104 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,207.574 ns |  2.9260 ns |  2.4434 ns |  0.14 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   550.957 ns |  2.0793 ns |  1.9450 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   547.387 ns |  3.0914 ns |  2.8917 ns |  0.99 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   259.798 ns |  0.8359 ns |  0.6980 ns |  0.47 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   597.908 ns |  1.6524 ns |  1.5457 ns | 1.000 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   545.517 ns |  1.9988 ns |  1.8697 ns | 0.912 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     4.182 ns |  0.0329 ns |  0.0292 ns | 0.007 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   431.165 ns |  1.2621 ns |  0.9854 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   534.272 ns |  2.3511 ns |  2.0842 ns |  1.24 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     9.931 ns |  0.0424 ns |  0.0354 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 8,927.773 ns | 35.8253 ns | 33.5110 ns |  1.00 | 0.0458 |     - |     - |     104 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,797.694 ns |  4.0443 ns |  3.5852 ns |  0.20 | 0.0191 |     - |     - |      40 B |
