## FirstBenchmarks

### Source
[FirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/FirstBenchmarks.cs)

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
|                              Method |                Categories | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  22.02 ns | 0.200 ns | 0.187 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  13.20 ns | 0.042 ns | 0.038 ns |  0.60 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |  27.38 ns | 0.087 ns | 0.073 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  16.20 ns | 0.039 ns | 0.035 ns |  0.59 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  26.56 ns | 0.153 ns | 0.136 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  18.73 ns | 0.053 ns | 0.047 ns |  0.71 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  12.36 ns | 0.055 ns | 0.046 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  22.47 ns | 0.132 ns | 0.117 ns |  1.82 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 109.50 ns | 0.948 ns | 0.887 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  62.59 ns | 0.160 ns | 0.141 ns |  0.57 |    0.01 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  25.50 ns | 0.148 ns | 0.139 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  18.66 ns | 0.147 ns | 0.123 ns |  0.73 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  26.59 ns | 0.091 ns | 0.076 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  18.75 ns | 0.119 ns | 0.105 ns |  0.71 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  12.40 ns | 0.064 ns | 0.060 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  23.48 ns | 0.499 ns | 0.594 ns |  1.88 |    0.06 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 106.75 ns | 0.246 ns | 0.219 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  68.68 ns | 0.392 ns | 0.367 ns |  0.64 |    0.00 | 0.0153 |     - |     - |      32 B |
