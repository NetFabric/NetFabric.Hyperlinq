## FirstBenchmarks

### Source
[FirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/FirstBenchmarks.cs)

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
|                              Method |                Categories | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  19.24 ns | 0.078 ns | 0.073 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  13.26 ns | 0.034 ns | 0.032 ns |  0.69 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |  25.00 ns | 0.127 ns | 0.112 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  15.57 ns | 0.040 ns | 0.033 ns |  0.62 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  28.18 ns | 0.592 ns | 1.127 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  18.92 ns | 0.061 ns | 0.054 ns |  0.68 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  12.44 ns | 0.050 ns | 0.039 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  22.00 ns | 0.120 ns | 0.172 ns |  1.77 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 103.75 ns | 0.487 ns | 0.432 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  61.99 ns | 0.117 ns | 0.098 ns |  0.60 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  26.59 ns | 0.528 ns | 0.468 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  17.38 ns | 0.114 ns | 0.101 ns |  0.65 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  25.97 ns | 0.191 ns | 0.178 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  20.63 ns | 0.114 ns | 0.095 ns |  0.79 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  12.52 ns | 0.091 ns | 0.081 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  20.87 ns | 0.104 ns | 0.093 ns |  1.67 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 103.68 ns | 2.016 ns | 2.071 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  70.01 ns | 1.326 ns | 1.240 ns |  0.67 |    0.02 | 0.0153 |     - |     - |      32 B |
