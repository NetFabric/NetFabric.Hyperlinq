## CountBenchmarks

### Source
[CountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/CountBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.2.21154.6
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1.1521-nightly, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.2.21155.3
  [Host]     : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT
  Job-KXCEYC : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |          Mean |      Error |    StdDev |  Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |--------------:|-----------:|----------:|-------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    11.2255 ns |  0.0273 ns | 0.0228 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|                    StructLinq_Array |                     Array |   100 |     0.9603 ns |  0.0093 ns | 0.0087 ns |   0.09 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |     7.9730 ns |  0.0152 ns | 0.0127 ns |   0.71 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |           |        |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   355.4883 ns |  1.6482 ns | 1.4611 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   603.7159 ns |  2.1824 ns | 1.9346 ns |   1.70 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   158.3521 ns |  0.2623 ns | 0.2454 ns |   0.45 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |           |        |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |     4.6527 ns |  0.0269 ns | 0.0251 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   605.6038 ns |  3.7534 ns | 3.5109 ns | 130.17 |    1.10 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |     7.7639 ns |  0.0187 ns | 0.0175 ns |   1.67 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |            |           |        |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     5.4788 ns |  0.0126 ns | 0.0098 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|               StructLinq_List_Value |                List_Value |   100 |     2.0882 ns |  0.0132 ns | 0.0110 ns |   0.38 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     1.6687 ns |  0.0630 ns | 0.0647 ns |   0.30 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |               |            |           |        |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,821.3896 ns |  3.9189 ns | 3.4740 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   939.0860 ns |  3.5278 ns | 3.2999 ns |   0.52 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |           |        |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   348.7667 ns |  1.4129 ns | 1.2525 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   603.3495 ns |  2.1976 ns | 1.9481 ns |   1.73 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   365.2241 ns |  1.1188 ns | 0.9918 ns |   1.05 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |               |            |           |        |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |     4.6612 ns |  0.0173 ns | 0.0153 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   606.8740 ns |  2.6887 ns | 2.3835 ns | 130.20 |    0.71 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     1.5391 ns |  0.0104 ns | 0.0087 ns |   0.33 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |           |        |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     5.5106 ns |  0.0544 ns | 0.0482 ns |   1.00 |    0.00 |      - |     - |     - |         - |
|           StructLinq_List_Reference |            List_Reference |   100 |   610.2956 ns | 12.0029 ns | 9.3710 ns | 110.85 |    2.17 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     1.6216 ns |  0.0127 ns | 0.0119 ns |   0.29 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |               |            |           |        |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,819.4181 ns |  4.6820 ns | 4.1505 ns |   1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,589.0589 ns |  4.1811 ns | 3.4914 ns |   0.87 |    0.00 | 0.0153 |     - |     - |      32 B |
