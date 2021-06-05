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
  Job-SUCOWF : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |         Mean |      Error |     StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|-----------:|-----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   219.711 ns |  4.1739 ns |  3.9042 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |    10.184 ns |  0.0370 ns |  0.0328 ns |  0.05 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    15.418 ns |  0.0369 ns |  0.0345 ns |  0.07 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   812.967 ns |  5.9923 ns |  5.3121 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   784.076 ns |  4.0677 ns |  3.6059 ns |  0.96 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   144.744 ns |  0.2739 ns |  0.2562 ns |  0.18 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   801.510 ns |  5.9916 ns |  5.3114 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   769.218 ns |  4.4604 ns |  3.9541 ns |  0.96 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    16.540 ns |  0.0370 ns |  0.0328 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   402.821 ns |  0.5863 ns |  0.4895 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|               StructLinq_List_Value |                List_Value |   100 |    10.144 ns |  0.0241 ns |  0.0225 ns |  0.03 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     4.959 ns |  0.0321 ns |  0.0268 ns |  0.01 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,802.309 ns | 15.9078 ns | 14.8802 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   786.096 ns |  1.0756 ns |  1.0061 ns |  0.10 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   779.795 ns |  5.2856 ns |  4.9441 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   755.027 ns |  3.7415 ns |  3.1243 ns |  0.97 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   373.832 ns |  3.4209 ns |  2.6708 ns |  0.48 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   764.223 ns |  3.1207 ns |  2.7664 ns | 1.000 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   785.206 ns |  4.3773 ns |  3.8804 ns | 1.027 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     4.343 ns |  0.0194 ns |  0.0172 ns | 0.006 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   414.345 ns |  3.3147 ns |  2.9384 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   754.097 ns |  2.5777 ns |  2.1525 ns |  1.82 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     4.476 ns |  0.0161 ns |  0.0143 ns |  0.01 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,958.364 ns | 21.2835 ns | 17.7727 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,428.854 ns |  6.0499 ns |  5.3631 ns |  0.21 | 0.0153 |     - |     - |      32 B |
