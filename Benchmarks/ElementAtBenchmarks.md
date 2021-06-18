## ElementAtBenchmarks

### Source
[ElementAtBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/ElementAtBenchmarks.cs)

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
|                              Method |                Categories | Count |         Mean |     Error |    StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-------------:|----------:|----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |    16.456 ns | 0.0966 ns | 0.0904 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |    12.952 ns | 0.0361 ns | 0.0320 ns |  0.79 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   321.772 ns | 2.7943 ns | 2.6138 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   131.436 ns | 0.4074 ns | 0.3611 ns |  0.41 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   320.549 ns | 5.2212 ns | 4.6284 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   136.995 ns | 0.5484 ns | 0.4861 ns |  0.43 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |     9.673 ns | 0.0693 ns | 0.0648 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |   330.177 ns | 2.9100 ns | 2.5796 ns | 34.15 |    0.38 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,620.433 ns | 4.6504 ns | 4.1224 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |   805.497 ns | 3.5011 ns | 3.1036 ns |  0.50 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   322.075 ns | 1.6159 ns | 1.4324 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   335.420 ns | 2.7009 ns | 2.2554 ns |  1.04 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   319.994 ns | 3.3920 ns | 3.0069 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   364.654 ns | 1.4024 ns | 1.2432 ns |  1.14 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |     9.695 ns | 0.0674 ns | 0.0527 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   328.172 ns | 1.9735 ns | 1.6480 ns | 33.84 |    0.28 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |              |           |           |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,627.227 ns | 6.8413 ns | 6.0646 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,412.723 ns | 7.4225 ns | 6.5799 ns |  0.87 |    0.00 | 0.0153 |     - |     - |      32 B |
