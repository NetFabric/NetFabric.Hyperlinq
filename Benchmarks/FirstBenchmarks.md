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
  Job-FXRHUT : .NET 6.0.0 (6.0.21.25307), X64 RyuJIT

Runtime=.NET 6.0  

```
|                              Method |                Categories | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  19.32 ns | 0.133 ns | 0.118 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  13.15 ns | 0.025 ns | 0.024 ns |  0.68 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |  25.19 ns | 0.109 ns | 0.091 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  15.61 ns | 0.051 ns | 0.045 ns |  0.62 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  26.26 ns | 0.145 ns | 0.121 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  19.36 ns | 0.038 ns | 0.033 ns |  0.74 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  12.29 ns | 0.079 ns | 0.070 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  21.07 ns | 0.107 ns | 0.100 ns |  1.72 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 101.36 ns | 0.383 ns | 0.320 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  60.98 ns | 0.182 ns | 0.170 ns |  0.60 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  26.33 ns | 0.555 ns | 1.001 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  18.44 ns | 0.142 ns | 0.126 ns |  0.71 |    0.02 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  26.37 ns | 0.280 ns | 0.248 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  18.35 ns | 0.109 ns | 0.102 ns |  0.70 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  12.28 ns | 0.036 ns | 0.032 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  23.76 ns | 0.498 ns | 0.611 ns |  1.92 |    0.06 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 103.29 ns | 0.420 ns | 0.372 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  67.61 ns | 0.145 ns | 0.121 ns |  0.65 |    0.00 | 0.0153 |     - |     - |      32 B |
