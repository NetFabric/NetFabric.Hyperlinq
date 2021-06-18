## SelectCountBenchmarks

### Source
[SelectCountBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/SelectCountBenchmarks.cs)

### References:
- Linq: 6.0.0-preview.5.21301.5
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.26.0](https://www.nuget.org/packages/StructLinq/0.26.0)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.13.0.1555-nightly, OS=Windows 10.0.19043.1055 (21H1/May2021Update)
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET SDK=6.0.100-preview.5.21302.13
  [Host]     : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT
  Job-UNTOJZ : .NET 6.0.0 (6.0.21.30105), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |         Mean |      Error |     StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|-----------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   196.867 ns |  1.2466 ns |  1.1051 ns |  1.00 |    0.00 | 0.0229 |     - |     - |      48 B |
|                    StructLinq_Array |                     Array |   100 |    10.218 ns |  0.0308 ns |  0.0273 ns |  0.05 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    15.495 ns |  0.0355 ns |  0.0314 ns |  0.08 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   817.248 ns |  4.7910 ns |  4.0007 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Enumerable_Value |          Enumerable_Value |   100 |   763.890 ns |  5.3349 ns |  4.7292 ns |  0.94 |    0.01 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   146.331 ns |  0.3951 ns |  0.3696 ns |  0.18 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   809.252 ns |  4.1536 ns |  3.6821 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|         StructLinq_Collection_Value |          Collection_Value |   100 |   736.884 ns |  1.7281 ns |  1.6165 ns |  0.91 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |    16.493 ns |  0.0749 ns |  0.0625 ns |  0.02 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   439.698 ns |  2.2291 ns |  2.0851 ns |  1.00 |    0.00 | 0.0267 |     - |     - |      56 B |
|               StructLinq_List_Value |                List_Value |   100 |    10.504 ns |  0.0398 ns |  0.0372 ns |  0.02 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |     4.450 ns |  0.0275 ns |  0.0244 ns |  0.01 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 7,285.015 ns | 19.6921 ns | 17.4565 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   790.400 ns |  2.4782 ns |  2.1968 ns |  0.11 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   809.637 ns |  4.1360 ns |  3.8688 ns |  1.00 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Enumerable_Reference |      Enumerable_Reference |   100 |   761.509 ns |  3.4922 ns |  3.2666 ns |  0.94 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   397.099 ns |  1.3983 ns |  1.2395 ns |  0.49 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   809.793 ns |  6.4629 ns |  5.3968 ns | 1.000 |    0.00 | 0.0420 |     - |     - |      88 B |
|     StructLinq_Collection_Reference |      Collection_Reference |   100 |   738.381 ns |  2.5787 ns |  2.1533 ns | 0.912 |    0.01 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |     4.726 ns |  0.0338 ns |  0.0299 ns | 0.006 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   430.338 ns |  4.9343 ns |  4.1204 ns |  1.00 |    0.00 | 0.0267 |     - |     - |      56 B |
|           StructLinq_List_Reference |            List_Reference |   100 |   765.248 ns |  5.5823 ns |  4.9486 ns |  1.78 |    0.03 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |     4.693 ns |  0.0246 ns |  0.0230 ns |  0.01 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |            |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 6,910.703 ns | 32.3418 ns | 30.2525 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,432.868 ns |  2.7418 ns |  2.5647 ns |  0.21 |    0.00 | 0.0153 |     - |     - |      32 B |
