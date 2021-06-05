## WhereFirstBenchmarks

### Source
[WhereFirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereFirstBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   607.3 ns |  2.67 ns |  2.37 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                     Hyperlinq_Array |                     Array |   100 |   213.5 ns |  3.27 ns |  3.06 ns |  0.35 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   776.9 ns |  3.00 ns |  2.81 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   243.3 ns |  4.84 ns |  5.76 ns |  0.32 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   763.9 ns |  2.67 ns |  2.37 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   241.3 ns |  1.59 ns |  1.41 ns |  0.32 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   797.4 ns |  6.86 ns |  5.36 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   790.3 ns |  2.20 ns |  2.06 ns |  0.99 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,770.0 ns |  5.42 ns |  4.81 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,607.4 ns |  7.50 ns |  6.65 ns |  1.47 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   747.5 ns |  3.38 ns |  2.99 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   753.7 ns |  2.27 ns |  2.12 ns |  1.01 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   751.1 ns | 11.02 ns | 10.30 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   768.9 ns |  2.22 ns |  1.97 ns |  1.02 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   742.8 ns | 10.66 ns |  9.45 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   767.8 ns |  3.95 ns |  3.29 ns |  1.03 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,745.1 ns |  6.89 ns |  6.11 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,868.8 ns | 13.30 ns | 11.79 ns |  1.64 | 0.0458 |     - |     - |      96 B |
