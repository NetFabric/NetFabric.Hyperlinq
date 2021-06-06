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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |       Mean |    Error |   StdDev |     Median | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |-----------:|---------:|---------:|-----------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |   627.5 ns |  2.33 ns |  2.18 ns |   627.3 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                     Hyperlinq_Array |                     Array |   100 |   212.0 ns |  2.89 ns |  5.49 ns |   208.9 ns |  0.34 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |   797.9 ns |  5.80 ns |  5.14 ns |   798.9 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   251.0 ns |  1.11 ns |  1.04 ns |   251.2 ns |  0.31 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |   765.5 ns |  3.23 ns |  2.87 ns |   765.3 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |   241.9 ns |  1.58 ns |  1.48 ns |   242.0 ns |  0.32 |    0.00 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |   783.9 ns |  2.64 ns |  2.21 ns |   784.0 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq_List_Value |                List_Value |   100 |   793.4 ns |  2.14 ns |  1.79 ns |   793.6 ns |  1.01 |    0.00 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,766.1 ns |  2.88 ns |  2.41 ns | 1,766.1 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 2,584.0 ns | 10.26 ns |  9.09 ns | 2,582.8 ns |  1.46 |    0.01 | 0.0305 |     - |     - |      64 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   797.4 ns |  2.49 ns |  2.33 ns |   796.7 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   792.2 ns | 15.30 ns | 13.56 ns |   789.9 ns |  0.99 |    0.02 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |   782.5 ns |  2.91 ns |  2.58 ns |   782.5 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   786.7 ns | 13.69 ns | 31.46 ns |   779.0 ns |  1.05 |    0.07 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |   785.6 ns |  2.36 ns |  2.09 ns |   785.7 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
|            Hyperlinq_List_Reference |            List_Reference |   100 |   718.2 ns |  4.76 ns |  4.22 ns |   716.3 ns |  0.91 |    0.01 | 0.0458 |     - |     - |      96 B |
|                                     |                           |       |            |          |          |            |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,759.0 ns |  2.68 ns |  2.38 ns | 1,758.9 ns |  1.00 |    0.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 2,868.9 ns |  5.06 ns |  4.22 ns | 2,869.9 ns |  1.63 |    0.00 | 0.0458 |     - |     - |      96 B |
