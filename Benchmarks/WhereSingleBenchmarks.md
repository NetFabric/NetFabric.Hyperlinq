## WhereSingleBenchmarks

### Source
[WhereSingleBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSingleBenchmarks.cs)

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
|                         Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |   607.0 ns |  9.12 ns |  8.09 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq_Array |                     Array |   100 |   208.4 ns |  0.67 ns |  0.52 ns |  0.34 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |          |          |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |   761.0 ns |  4.33 ns |  3.84 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   267.5 ns |  1.15 ns |  1.02 ns |  0.35 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |          |          |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |   778.2 ns |  2.81 ns |  2.49 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |   262.0 ns |  1.08 ns |  1.01 ns |  0.34 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |          |          |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |   762.9 ns |  1.55 ns |  1.30 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|           Hyperlinq_List_Value |                List_Value |   100 |   798.4 ns |  3.46 ns |  2.89 ns |  1.05 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |          |          |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,746.6 ns |  4.35 ns |  4.06 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |          |          |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   725.9 ns |  7.94 ns |  7.04 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   751.0 ns |  3.70 ns |  3.28 ns |  1.03 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |          |          |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |   724.8 ns |  9.52 ns |  8.91 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   758.4 ns |  2.32 ns |  1.94 ns |  1.04 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |          |          |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |   716.9 ns |  3.26 ns |  2.89 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |   828.8 ns |  4.47 ns |  3.97 ns |  1.16 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |          |          |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,726.4 ns | 13.14 ns | 12.29 ns |  1.00 | 0.0458 |     - |     - |      96 B |
