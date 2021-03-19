## AnyPredicateBenchmarks

### Source
[AnyPredicateBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/AnyPredicateBenchmarks.cs)

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
|                              Method |                Categories | Count |        Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |------------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   591.00 ns | 1.814 ns | 1.608 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                     Hyperlinq_Array |                     Array |   100 |   192.91 ns | 1.138 ns | 1.065 ns |  0.33 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   751.43 ns | 3.851 ns | 6.844 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   227.78 ns | 1.197 ns | 1.120 ns |  0.30 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   751.53 ns | 3.422 ns | 3.201 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   207.85 ns | 1.383 ns | 1.155 ns |  0.28 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   749.40 ns | 4.345 ns | 3.628 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   612.27 ns | 2.321 ns | 2.057 ns |  0.82 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,869.98 ns | 7.385 ns | 6.908 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |    77.90 ns | 0.339 ns | 0.283 ns |  0.04 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   725.02 ns | 2.412 ns | 2.256 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   784.85 ns | 2.119 ns | 1.878 ns |  1.08 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   751.31 ns | 2.980 ns | 2.327 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   739.72 ns | 3.044 ns | 2.542 ns |  0.98 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   750.60 ns | 5.104 ns | 4.775 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   618.04 ns | 1.425 ns | 1.264 ns |  0.82 |      - |     - |     - |         - |
|                                     |                           |       |             |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,845.41 ns | 8.015 ns | 7.497 ns |  1.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |    81.29 ns | 0.305 ns | 0.270 ns |  0.04 | 0.0153 |     - |     - |      32 B |
