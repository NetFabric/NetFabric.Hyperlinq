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
|                              Method |                Categories | Count |      Mean |    Error |   StdDev | Ratio |  Gen 0 | Gen 1 | Gen 2 | Allocated |
|------------------------------------ |-------------------------- |------ |----------:|---------:|---------:|------:|-------:|------:|------:|----------:|
|                          Linq_Array |                     Array |   100 |  22.30 ns | 0.106 ns | 0.099 ns |  1.00 |      - |     - |     - |         - |
|                     Hyperlinq_Array |                     Array |   100 |  13.64 ns | 0.063 ns | 0.059 ns |  0.61 |      - |     - |     - |         - |
|                      Hyperlinq_Span |                     Array |   100 |  12.78 ns | 0.031 ns | 0.027 ns |  0.57 |      - |     - |     - |         - |
|                    Hyperlinq_Memory |                     Array |   100 |  14.96 ns | 0.052 ns | 0.043 ns |  0.67 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|               Linq_Enumerable_Value |          Enumerable_Value |   100 |  25.67 ns | 0.134 ns | 0.112 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Enumerable_Value |          Enumerable_Value |   100 |  16.08 ns | 0.084 ns | 0.079 ns |  0.63 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|               Linq_Collection_Value |          Collection_Value |   100 |  26.62 ns | 0.151 ns | 0.134 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|          Hyperlinq_Collection_Value |          Collection_Value |   100 |  19.39 ns | 0.068 ns | 0.061 ns |  0.73 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|                     Linq_List_Value |                List_Value |   100 |  13.53 ns | 0.075 ns | 0.059 ns |  1.00 |      - |     - |     - |         - |
|                Hyperlinq_List_Value |                List_Value |   100 |  22.67 ns | 0.125 ns | 0.117 ns |  1.68 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|          Linq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 | 120.66 ns | 0.577 ns | 0.511 ns |  1.00 | 0.0191 |     - |     - |      40 B |
|     Hyperlinq_AsyncEnumerable_Value |     AsyncEnumerable_Value |   100 |  78.47 ns | 0.365 ns | 0.341 ns |  0.65 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|           Linq_Enumerable_Reference |      Enumerable_Reference |   100 |  22.36 ns | 0.170 ns | 0.159 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Enumerable_Reference |      Enumerable_Reference |   100 |  15.19 ns | 0.134 ns | 0.125 ns |  0.68 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|           Linq_Collection_Reference |      Collection_Reference |   100 |  23.21 ns | 0.167 ns | 0.156 ns |  1.00 | 0.0153 |     - |     - |      32 B |
|      Hyperlinq_Collection_Reference |      Collection_Reference |   100 |  16.89 ns | 0.092 ns | 0.082 ns |  0.73 | 0.0153 |     - |     - |      32 B |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|                 Linq_List_Reference |            List_Reference |   100 |  13.52 ns | 0.097 ns | 0.086 ns |  1.00 |      - |     - |     - |         - |
|            Hyperlinq_List_Reference |            List_Reference |   100 |  22.36 ns | 0.075 ns | 0.059 ns |  1.65 |      - |     - |     - |         - |
|                                     |                           |       |           |          |          |       |        |       |       |           |
|      Linq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 | 116.18 ns | 0.593 ns | 0.495 ns |  1.00 | 0.0191 |     - |     - |      40 B |
| Hyperlinq_AsyncEnumerable_Reference | AsyncEnumerable_Reference |   100 |  78.56 ns | 0.363 ns | 0.322 ns |  0.68 | 0.0191 |     - |     - |      40 B |
