## WhereSingleBenchmarks

### Source
[WhereSingleBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereSingleBenchmarks.cs)

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
|                         Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |   594.5 ns |  5.05 ns |  4.72 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq_Array |                     Array |   100 |   189.5 ns |  2.34 ns |  1.95 ns |  0.32 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |   717.0 ns |  3.46 ns |  3.07 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   261.6 ns |  4.08 ns |  4.00 ns |  0.37 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |   784.2 ns |  5.06 ns |  4.73 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |   269.9 ns |  1.43 ns |  1.27 ns |  0.34 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |          |          |       |         |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |   754.6 ns |  3.91 ns |  3.06 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|           Hyperlinq_List_Value |                List_Value |   100 |   751.4 ns |  3.06 ns |  2.86 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |          |          |       |         |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,727.5 ns |  5.56 ns |  4.92 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   756.5 ns |  2.78 ns |  2.46 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   775.9 ns |  7.57 ns |  6.71 ns |  1.03 |    0.01 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |   730.3 ns |  6.58 ns |  6.15 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   880.0 ns | 17.50 ns | 39.87 ns |  1.20 |    0.04 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |          |          |       |         |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |   780.9 ns |  3.25 ns |  2.88 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 | 1,351.5 ns | 24.31 ns | 22.74 ns |  1.73 |    0.03 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |          |          |       |         |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,721.3 ns |  5.21 ns |  4.87 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
