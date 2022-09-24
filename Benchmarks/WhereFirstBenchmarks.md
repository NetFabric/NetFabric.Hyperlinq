## WhereFirstBenchmarks

### Source
[WhereFirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereFirstBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   628.3 ns |  3.00 ns |  2.50 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                     Hyperlinq_Array |                     Array |   100 |   211.0 ns |  1.17 ns |  0.97 ns |  0.34 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   767.4 ns |  3.83 ns |  3.39 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   250.9 ns |  1.17 ns |  0.98 ns |  0.33 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   784.0 ns |  4.45 ns |  3.71 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   242.3 ns |  1.46 ns |  1.30 ns |  0.31 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   781.3 ns |  6.06 ns |  5.37 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   788.1 ns |  6.22 ns |  5.19 ns |  1.01 |    0.01 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,770.2 ns |  3.54 ns |  3.14 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,585.5 ns |  5.39 ns |  4.78 ns |  1.46 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   767.2 ns |  2.33 ns |  1.95 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   840.7 ns |  2.43 ns |  2.15 ns |  1.10 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   781.4 ns |  5.11 ns |  4.53 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   751.5 ns | 10.10 ns |  8.95 ns |  0.96 |    0.01 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   807.9 ns |  2.84 ns |  2.51 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   785.2 ns | 12.49 ns | 11.68 ns |  0.97 |    0.02 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,782.2 ns |  2.93 ns |  2.60 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,878.4 ns |  4.70 ns |  3.67 ns |  1.61 |    0.00 | 0.0458 |     - |     - |      96 B |
