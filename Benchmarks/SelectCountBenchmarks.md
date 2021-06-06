## SelectCountBenchmarks

### Source
[SelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectCountBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.4.21253.7
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1023 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.4.21255.9
  [Host]     : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   225.909 ns |  0.4993 ns |  0.3898 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |    10.203 ns |  0.0223 ns |  0.0198 ns |  0.05 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    15.432 ns |  0.0342 ns |  0.0320 ns |  0.07 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   802.029 ns |  2.6396 ns |  2.3399 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   761.393 ns |  3.4969 ns |  3.2710 ns |  0.95 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   144.689 ns |  0.3393 ns |  0.3174 ns |  0.18 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   827.683 ns |  4.5779 ns |  3.8227 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   762.567 ns |  1.9828 ns |  1.6557 ns |  0.92 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    16.523 ns |  0.0372 ns |  0.0329 ns |  0.02 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   445.413 ns |  1.9880 ns |  1.7623 ns |  1.00 |    0.00 | 0.0267 |     - |     - |      56 B |
|               StructLinq_List_Value |                List_Value |   100 |    10.183 ns |  0.0367 ns |  0.0343 ns |  0.02 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     4.708 ns |  0.0297 ns |  0.0278 ns |  0.01 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 6,929.070 ns | 28.1569 ns | 23.5123 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   788.419 ns |  2.0581 ns |  1.8244 ns |  0.11 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   776.714 ns |  4.4453 ns |  3.9406 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   754.998 ns |  4.7763 ns |  3.9884 ns |  0.97 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   394.936 ns |  1.9683 ns |  1.5367 ns |  0.51 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   767.129 ns |  4.2155 ns |  3.7370 ns | 1.000 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   789.990 ns |  5.2898 ns |  4.9481 ns | 1.031 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     4.680 ns |  0.0220 ns |  0.0184 ns | 0.006 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   406.865 ns |  2.2082 ns |  2.0656 ns |  1.00 |    0.00 | 0.0267 |     - |     - |      56 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   786.466 ns |  7.8552 ns |  6.5595 ns |  1.93 |    0.02 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     4.550 ns |  0.0163 ns |  0.0144 ns |  0.01 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,970.239 ns | 23.5447 ns | 19.6609 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,397.486 ns |  3.5906 ns |  3.1830 ns |  0.20 |    0.00 | 0.0153 |     - |     - |      32 B |
