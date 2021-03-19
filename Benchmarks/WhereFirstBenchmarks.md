## WhereFirstBenchmarks

### Source
[WhereFirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/WhereFirstBenchmarks.cs)

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
|                              Method |                Categories | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   585.0 ns |  3.10 ns |  2.75 ns |   584.7 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                     Hyperlinq_Array |                     Array |   100 |   211.1 ns |  0.79 ns |  0.74 ns |   211.1 ns |  0.36 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   755.3 ns |  4.54 ns |  4.03 ns |   754.5 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   219.2 ns |  0.84 ns |  0.75 ns |   219.4 ns |  0.29 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   752.8 ns |  4.13 ns |  3.87 ns |   752.1 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   225.7 ns |  0.79 ns |  0.70 ns |   225.6 ns |  0.30 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   753.9 ns |  2.72 ns |  2.41 ns |   753.9 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   670.8 ns |  2.08 ns |  1.74 ns |   670.9 ns |  0.89 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,914.6 ns |  4.18 ns |  3.49 ns | 1,915.0 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,934.7 ns |  7.32 ns |  6.84 ns | 2,933.2 ns |  1.53 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   796.3 ns |  3.15 ns |  2.79 ns |   796.3 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   775.8 ns |  2.32 ns |  2.06 ns |   776.4 ns |  0.97 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   792.5 ns |  2.01 ns |  1.78 ns |   792.1 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   793.4 ns |  2.35 ns |  2.08 ns |   793.3 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   816.9 ns | 16.29 ns | 32.15 ns |   801.4 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   676.6 ns |  2.79 ns |  2.61 ns |   676.2 ns |  0.83 |    0.03 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,918.5 ns |  7.27 ns |  6.07 ns | 1,919.1 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 3,241.0 ns | 21.98 ns | 18.35 ns | 3,236.1 ns |  1.69 |    0.01 | 0.0458 |     - |     - |      96 B |
