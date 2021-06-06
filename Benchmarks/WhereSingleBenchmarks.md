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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                         Method |                Categories | Count |       Mean |   Error |  StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------- |-------------------------- |------ |-----------:|--------:|--------:|------:|-------:|------:|------:|----------:|
|                     Linq_Array |                     Array |   100 |   581.4 ns | 3.08 ns | 2.73 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                Hyperlinq_Array |                     Array |   100 |   206.9 ns | 0.43 ns | 0.36 ns |  0.36 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|          Linq_Enumerable_Value |          Enumerable_Value |   100 |   772.8 ns | 3.58 ns | 2.99 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |   272.4 ns | 3.12 ns | 2.92 ns |  0.35 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|          Linq_Collection_Value |          Collection_Value |   100 |   768.0 ns | 4.02 ns | 3.56 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|     Hyperlinq_Collection_Value |          Collection_Value |   100 |   266.1 ns | 4.52 ns | 4.01 ns |  0.35 | 0.0305 |     - |     - |      64 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|                Linq_List_Value |                List_Value |   100 |   782.0 ns | 4.00 ns | 3.55 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|           Hyperlinq_List_Value |                List_Value |   100 |   774.0 ns | 2.94 ns | 2.61 ns |  0.99 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|     Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 1,741.8 ns | 5.26 ns | 4.67 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|      Linq_Enumerable_Reference |      Enumerable_Reference |   100 |   779.5 ns | 2.88 ns | 2.69 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |   763.2 ns | 3.25 ns | 2.88 ns |  0.98 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|      Linq_Collection_Reference |      Collection_Reference |   100 |   795.6 ns | 3.08 ns | 2.73 ns |  1.00 | 0.0458 |     - |     - |      96 B |
| Hyperlinq_Collection_Reference |      Collection_Reference |   100 |   749.0 ns | 2.92 ns | 2.59 ns |  0.94 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
|            Linq_List_Reference |            List_Reference |   100 |   807.1 ns | 5.97 ns | 5.29 ns |  1.00 | 0.0458 |     - |     - |      96 B |
|       Hyperlinq_List_Reference |            List_Reference |   100 |   824.7 ns | 3.38 ns | 3.00 ns |  1.02 | 0.0458 |     - |     - |      96 B |
|                                |                           |       |            |         |         |       |        |       |       |           |
| Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 1,714.4 ns | 2.55 ns | 1.99 ns |  1.00 | 0.0458 |     - |     - |      96 B |
