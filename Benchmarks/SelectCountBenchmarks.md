## SelectCountBenchmarks

### Source
[SelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectCountBenchmarks.cs)

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
  Job-XHOKQA : .NET 6.0.0 (6.0.21.15406), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |         Mean |      Error |     StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|-----------:|-----------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   195.967 ns |  0.6597 ns |  0.5848 ns |  1.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |    10.188 ns |  0.0342 ns |  0.0320 ns |  0.05 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    15.532 ns |  0.0697 ns |  0.0582 ns |  0.08 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   771.437 ns |  4.7738 ns |  4.2319 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   763.172 ns |  2.2538 ns |  2.1082 ns |  0.99 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   162.321 ns |  0.1898 ns |  0.1682 ns |  0.21 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   775.472 ns |  2.9631 ns |  2.7717 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   802.103 ns |  6.4102 ns |  5.3528 ns |  1.03 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    16.077 ns |  0.0369 ns |  0.0327 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   482.164 ns |  0.8969 ns |  0.7951 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|               StructLinq_List_Value |                List_Value |   100 |    10.268 ns |  0.0340 ns |  0.0302 ns |  0.02 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     9.873 ns |  0.0109 ns |  0.0085 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,523.203 ns | 22.8359 ns | 20.2434 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   947.472 ns |  1.2425 ns |  1.1015 ns |  0.13 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   820.965 ns |  4.0317 ns |  3.7713 ns |  1.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   764.338 ns |  3.4927 ns |  2.9166 ns |  0.93 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   368.547 ns |  1.3929 ns |  1.1631 ns |  0.45 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   809.920 ns |  2.3646 ns |  1.9745 ns | 1.000 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   767.365 ns |  2.4976 ns |  2.0856 ns | 0.947 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     4.228 ns |  0.0221 ns |  0.0184 ns | 0.005 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   420.192 ns |  2.0857 ns |  1.9509 ns |  1.00 | 0.0267 |     - |     - |      56 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   767.197 ns |  5.1913 ns |  4.6020 ns |  1.83 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     9.831 ns |  0.2176 ns |  0.2234 ns |  0.02 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 7,586.118 ns | 32.0225 ns | 28.3871 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,630.690 ns | 31.2243 ns | 30.6665 ns |  0.22 | 0.0153 |     - |     - |      32 B |
