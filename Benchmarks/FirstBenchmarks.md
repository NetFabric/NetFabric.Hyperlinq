## FirstBenchmarks

### Source
[FirstBenchmarks.cs](../NetFabric.Hyperlinq.Benchmarks/Benchmarks/FirstBenchmarks.cs)

### References:
- Linq: 5.0.3
- System.Linq.Async: [5.0.0](https://www.nuget.org/packages/System.Linq.Async/5.0.0)
- System.Interactive: [5.0.0](https://www.nuget.org/packages/System.Interactive/5.0.0)
- System.Interactive.Async: [5.0.0](https://www.nuget.org/packages/System.Interactive.Async/5.0.0)
- StructLinq: [0.25.3](https://www.nuget.org/packages/StructLinq/0.25.3)
- NetFabric.Hyperlinq: [3.0.0-beta44](https://www.nuget.org/packages/NetFabric.Hyperlinq/3.0.0-beta44)

### Results:
``` ini

BenchmarkDotNet=v0.12.1, OS=Windows 10.0.19043
Intel Core i7-7567U CPU 3.50GHz (Kaby Lake), 1 CPU, 4 logical and 2 physical cores
.NET Core SDK=6.0.100-preview.1.21103.13
  [Host]        : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT
  .NET Core 5.0 : .NET Core 5.0.3 (CoreCLR 5.0.321.7212, CoreFX 5.0.321.7212), X64 RyuJIT

Job=.NET Core 5.0  Runtime=.NET Core 5.0  

```
|                              Method |                Categories | Count |      Mean |    Error |   StdDev | Ratio | RatioSD |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|---------:|---------:|------:|--------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  21.81 ns | 0.085 ns | 0.071 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  13.40 ns | 0.035 ns | 0.033 ns |  0.61 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |  24.64 ns | 0.105 ns | 0.093 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  15.55 ns | 0.029 ns | 0.025 ns |  0.63 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  25.32 ns | 0.090 ns | 0.075 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  18.55 ns | 0.030 ns | 0.028 ns |  0.73 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  12.96 ns | 0.172 ns | 0.144 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  22.25 ns | 0.075 ns | 0.066 ns |  1.72 |    0.02 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 119.08 ns | 0.366 ns | 0.325 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  75.23 ns | 0.256 ns | 0.226 ns |  0.63 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  20.84 ns | 0.134 ns | 0.118 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  15.79 ns | 0.077 ns | 0.064 ns |  0.76 |    0.01 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  21.51 ns | 0.090 ns | 0.084 ns |  1.00 |    0.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  15.61 ns | 0.084 ns | 0.070 ns |  0.73 |    0.00 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  12.89 ns | 0.022 ns | 0.018 ns |  1.00 |    0.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  21.34 ns | 0.056 ns | 0.044 ns |  1.66 |    0.00 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |         |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 112.02 ns | 0.289 ns | 0.256 ns |  1.00 |    0.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  77.45 ns | 0.186 ns | 0.174 ns |  0.69 |    0.00 | 0.0191 |     - |     - |      40 B |
